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

    public void SpawnKnol(KNOLTYPE knolType, Vector3 spawnPos, bool isInitialSpawn = false, Quaternion spawnRot = default)
    {
        if (isInitialSpawn)
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
                    Instantiate(radijsPrefabPlanted, pos, default, null);
                }
                else
                {
                    Instantiate(radijsPrefab, pos, default, null);
                }
                break;
            case KNOLTYPE.wortel:
                if (isBeingPlanted)
                {
                    Instantiate(wortelPrefabPlanted, pos, default, null);
                }
                else
                {
                    Instantiate(wortelPrefab, pos, default, null);
                }
                break;
            case KNOLTYPE.bosui:
                if (isBeingPlanted)
                {
                    Instantiate(bosuiPrefabPlanted, pos, default, null);
                }
                else
                {
                    Instantiate(bosuiPrefab, pos, default, null);
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
