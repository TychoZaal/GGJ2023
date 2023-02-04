using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnolSpawner : MonoBehaviour
{
    [SerializeField] GameObject radijsPrefab;
    [SerializeField] GameObject wortelPrefab;
    [SerializeField] GameObject bosuiPrefab;

    public delegate void PutDownAction(Vector3 pos);
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
        switch (knolType)
        {
            case KNOLTYPE.radijsje:
                Instantiate(radijsPrefab, spawnPos, spawnRot, null);
                if (!isInitialSpawn)
                {
                    if (OnPutDown != null)
                        OnPutDown(spawnPos);
                }
                break;
            case KNOLTYPE.wortel:
                Instantiate(wortelPrefab, spawnPos, spawnRot, null);
                if (!isInitialSpawn)
                {
                    if (OnPutDown != null)
                        OnPutDown(spawnPos);
                }
                break;
            case KNOLTYPE.bosui:
                Instantiate(bosuiPrefab, spawnPos, spawnRot, null);
                if (!isInitialSpawn)
                {
                    if (OnPutDown != null)
                        OnPutDown(spawnPos);
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
