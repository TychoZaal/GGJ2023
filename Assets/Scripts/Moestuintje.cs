using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moestuintje : MonoBehaviour
{
    [SerializeField] private PLAYERCLASS playerclass;

    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    //void OnEnable()
    //{
    //    KnolSpawner.OnPutDown += CheckOverlap;
    //}

    //void OnDisable()
    //{
    //    KnolSpawner.OnPutDown -= CheckOverlap;
    //}

    public bool CheckOverlap(Vector3 pos)
    {
        Vector3 checkPos = new Vector3(pos.x, transform.position.y, pos.z);

        if (col.bounds.Contains(checkPos))
        {
            Debug.Log("Plant die zaadje in de moestuin");
            ScoreManager.Instance.AddScore(1, playerclass);
                return true;
          //  KnolSpawner.Instance.CreateKnolInstance(knolType, pos, false);
        }
        else
        {
            return false;
           // KnolSpawner.Instance.CreateKnolInstance(knolType, pos, false);
        }
    }
}
