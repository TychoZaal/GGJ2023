using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnolSpawner : MonoBehaviour
{
    [SerializeField] GameObject radijsPrefab;
    [SerializeField] GameObject wortelPrefab;
    [SerializeField] GameObject bosuiPrefab;

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

    public void SpawnKnol(KNOLTYPE knolType, Vector3 spawnPos, Quaternion spawnRot = default)
    {
        switch (knolType)
        {
            case KNOLTYPE.radijsje:
                Instantiate(radijsPrefab, spawnPos, spawnRot, null);
                break;
            case KNOLTYPE.wortel:
                Instantiate(wortelPrefab, spawnPos, spawnRot, null);
                break;
            case KNOLTYPE.bosui:
                Instantiate(bosuiPrefab, spawnPos, spawnRot, null);
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
