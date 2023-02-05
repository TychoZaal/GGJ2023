using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGrid : MonoBehaviour
{
    [SerializeField] List<Collider> obstacles = new List<Collider>();

    [SerializeField] public int columns = 10;
    [SerializeField] public int rows = 15;

    [HideInInspector] public CarrotPoint[,] carrotPoints;

    private float posy;

    //TEMP
    private float gizmoSize = .1f;


    public static CarrotGrid Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        GameObject walkableArea = GameEnvironment.Instance.ground;
        Renderer r = walkableArea.GetComponent<Renderer>();
        float width = r.bounds.size.z - 4f;
        float height = r.bounds.size.x - 4f;

        posy = walkableArea.transform.position.y;

        carrotPoints = new CarrotPoint[columns, rows];

        CreateGrid(width, height);

    }

    private bool CheckObstacleOverlap(Vector3 pos)
    {
        foreach(Collider c in obstacles)
        {
            Vector3 checkPos = new Vector3(pos.x, c.bounds.center.y, pos.z);
            if (c.bounds.Contains(checkPos))
            {
                return false;
            }
        }
        return true;
    }

    private void CreateGrid(float width, float height)
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                float posx = ((height / (float)columns) / 2f) + ((height / (float)columns) * i);
                posx -= height / 2f;
                float posz = ((width / (float)rows) / 2f) + ((width / (float)rows) * j);
                posz -= width / 2f;

                Vector3 pos = new Vector3(posx, posy, posz);
                bool isAvailable = CheckObstacleOverlap(pos);

                carrotPoints[i, j] = new CarrotPoint(pos, isAvailable);
            }
        }

    }

    private void OnDrawGizmos()
    {
        if (carrotPoints == null) return;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Gizmos.color = carrotPoints[i, j].availability ?  Color.cyan : Color.red;
                Gizmos.DrawCube(carrotPoints[i, j].pos, new Vector3(gizmoSize, gizmoSize, gizmoSize));
            }
        }
    }
}

public class CarrotPoint
{
    public Vector3 pos = default;
    public bool availability = true;

    public CarrotPoint(Vector3 pos, bool availability)
    {
        this.pos = pos;
        this.availability = availability;
    }
}

