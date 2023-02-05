using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironment : MonoBehaviour
{
    [SerializeField] public GameObject ground;
    [SerializeField] public List<Moestuintje> moestuintjes = new List<Moestuintje>();
    [SerializeField] public GameObject knollenParent;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;


    public static GameEnvironment Instance { get; private set; }

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

        GameObject walkableArea = ground;
        Renderer r = walkableArea.GetComponent<Renderer>();
        float width = r.bounds.size.z;
        minZ = r.bounds.center.z - width / 2f;
        maxZ = r.bounds.center.z + width / 2f;
        float height = r.bounds.size.x;
        minX = r.bounds.center.x - height / 2f;
        maxX = r.bounds.center.x + height / 2f;

    }
}
