using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnolSpawner : MonoBehaviour
{
    [SerializeField] GameObject radijsPrefab;
    [SerializeField] GameObject wortelPrefab;
    [SerializeField] GameObject bosuiPrefab;

    [SerializeField] GameObject radijsPrefabPlanted;
    [SerializeField] GameObject wortelPrefabPlanted;
    [SerializeField] GameObject bosuiPrefabPlanted;

    public delegate void PutDownAction(KNOLTYPE knolType, Vector3 pos);
    public static event PutDownAction OnPutDown;

    public static KnolSpawner Instance { get; private set; }

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

    private void Start()
    {
    }

    public void SpawnWortel()
    {
        int f = 0;

        while (f < 100)
        {
            int c = Random.Range(0, CarrotGrid.Instance.columns - 1);
            int r = Random.Range(0, CarrotGrid.Instance.rows - 1);

            if (CarrotGrid.Instance.carrotPoints[c, r].availability)
            {
                Debug.Log("instantiate carrot");
                GameObject w = Instantiate(wortelPrefab, CarrotGrid.Instance.carrotPoints[c, r].pos, default, GameEnvironment.Instance.knollenParent.transform);
                WortelJumpingBehavior wjb = w.GetComponent<WortelJumpingBehavior>();

                wjb.currentColumn = c;
                wjb.currentRow = r;
                wjb.Jump();
                f = 200;

            }
            f++;
        }
    }

    public void SpawnWortelOpnieuw(Vector3 spawnPos)
    {
        float distance = -1f;
        int c = 0;
        for (int i = 0; i < CarrotGrid.Instance.columns; i++)
        {
            float dis = Vector3.Distance(spawnPos, CarrotGrid.Instance.carrotPoints[i, 0].pos);
            if (distance < 0 || dis < distance)
            {
                distance = dis;
                c = i;
            }
        }
        distance = -1f;
        int r = 0;
        for (int i = 0; i < CarrotGrid.Instance.rows; i++)
        {
            float dis = Vector3.Distance(spawnPos, CarrotGrid.Instance.carrotPoints[0, i].pos);
            if (distance < 0 || dis < distance)
            {
                distance = dis;
                r = i;
            }
        }
        // int c = Random.Range(0, CarrotGrid.Instance.columns - 1);
        //int r = Random.Range(0, CarrotGrid.Instance.rows - 1);

        if (CarrotGrid.Instance.carrotPoints[c, r].availability)
        {
            Debug.Log("instantiate carrot");
            GameObject w = Instantiate(wortelPrefab, CarrotGrid.Instance.carrotPoints[c, r].pos, default, GameEnvironment.Instance.knollenParent.transform);
            WortelJumpingBehavior wjb = w.GetComponent<WortelJumpingBehavior>();

            wjb.currentColumn = c;
            wjb.currentRow = r;
            wjb.Invoke("Jump", 1f);
        }
        else
        {
            List<Vector2Int> movePos = new List<Vector2Int>() { new Vector2Int(-1, -1), new Vector2Int(-1, 0), new Vector2Int(-1, 1), new Vector2Int(0, -1), new Vector2Int(0, 1), new Vector2Int(1, -1), new Vector2Int(1, 0), new Vector2Int(1, 1) };
            foreach(Vector2Int m in movePos)
            {
                int cc = c + m.x;
                int rr = r + m.y;

                if (cc < 0 || rr < 0 || cc >= CarrotGrid.Instance.columns || rr >= CarrotGrid.Instance.rows) continue;
                if (CarrotGrid.Instance.carrotPoints[cc, rr].availability)
                {
                    GameObject ww = Instantiate(wortelPrefab, CarrotGrid.Instance.carrotPoints[cc, rr].pos, default, GameEnvironment.Instance.knollenParent.transform);
                    CarrotGrid.Instance.carrotPoints[cc, rr].availability = false;
                    WortelJumpingBehavior wjbb = ww.GetComponent<WortelJumpingBehavior>();

                    wjbb.currentColumn = cc;
                    wjbb.currentRow = rr;
                    
                    wjbb.Invoke("Jump", 1f);
                    return;
                }

            }
            GameObject w = Instantiate(wortelPrefab, CarrotGrid.Instance.carrotPoints[c, r].pos, default, GameEnvironment.Instance.knollenParent.transform);
            WortelJumpingBehavior wjb = w.GetComponent<WortelJumpingBehavior>();

            wjb.currentColumn = c;
            wjb.currentRow = r;
            wjb.Invoke("Jump", 1f);
        }

    }

    public void SpawnBosui()
    {
        Instantiate(bosuiPrefab, default, default, GameEnvironment.Instance.knollenParent.transform);
    }

    public void SpawnRadijs()
    {
        Instantiate(radijsPrefab, default, default, GameEnvironment.Instance.knollenParent.transform);
    }

    public void SpawnKnol(KNOLTYPE knolType, Vector3 spawnPos, bool fallingFromHands = false, Quaternion spawnRot = default)
    {
        if (fallingFromHands)
        {
            CreateKnolInstance(knolType, spawnPos, false);
        }
        else
        {

            foreach (Moestuintje m in GameEnvironment.Instance.moestuintjes)
            {
                bool isPlanting = m.CheckOverlap(spawnPos);
                if (isPlanting)
                {
                    CreateKnolInstance(knolType, spawnPos, true);
                    WaveManager.Instance.PutKnolDown();
                    return;
                }
            }
            CreateKnolInstance(knolType, spawnPos, false);
        }
        //switch (knolType)
        //{
        //    case KNOLTYPE.radijsje:
        //        if (isInitialSpawn)
        //        {
        //            Instantiate(radijsPrefab, spawnPos, spawnRot, null);
        //        }
        //        else
        //        {
        //            if (OnPutDown != null)
        //                OnPutDown(knolType, spawnPos);
        //        }
        //        break;
        //    case KNOLTYPE.wortel:
        //        Instantiate(wortelPrefab, spawnPos, spawnRot, null);
        //        if (!isInitialSpawn)
        //        {
        //            if (OnPutDown != null)
        //                OnPutDown(knolType, spawnPos);
        //        }
        //        break;
        //    case KNOLTYPE.bosui:
        //        Instantiate(bosuiPrefab, spawnPos, spawnRot, null);
        //        if (!isInitialSpawn)
        //        {
        //            if (OnPutDown != null)
        //                OnPutDown(knolType, spawnPos);
        //        }
        //        break;
        //    default:
        //        Debug.Log("CANNOT SPAWN ANYTHING!!");
        //        break;
        //}
    }

    public void CreateKnolInstance(KNOLTYPE knolType, Vector3 pos, bool isBeingPlanted)
    {
        switch (knolType)
        {
            case KNOLTYPE.radijsje:
                if (isBeingPlanted)
                {
                    Instantiate(radijsPrefabPlanted, pos, default, GameEnvironment.Instance.knollenParent.transform);
                }
                else
                {
                    Instantiate(radijsPrefab, pos, default, GameEnvironment.Instance.knollenParent.transform);
                }
                break;
            case KNOLTYPE.wortel:
                if (isBeingPlanted)
                {
                    Instantiate(wortelPrefabPlanted, pos, default, GameEnvironment.Instance.knollenParent.transform);
                }
                else
                {
                    KnolSpawner.Instance.SpawnWortelOpnieuw(pos);
                }
                break;
            case KNOLTYPE.bosui:
                if (isBeingPlanted)
                {
                    Instantiate(bosuiPrefabPlanted, pos, default, GameEnvironment.Instance.knollenParent.transform);
                }
                else
                {
                    Instantiate(bosuiPrefab, pos, default, GameEnvironment.Instance.knollenParent.transform);
                }
                break;
            default:
                Debug.Log("CANNOT SPAWN ANYTHING!!");
                break;
        }
    }
}

public enum KNOLTYPE
{
    radijsje,
    bosui,
    wortel
}
