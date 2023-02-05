using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironment : MonoBehaviour
{
    [SerializeField] public GameObject ground;
    [SerializeField] public List<Moestuintje> moestuintjes = new List<Moestuintje>();
    [SerializeField] public GameObject knollenParent;

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
    }
}
