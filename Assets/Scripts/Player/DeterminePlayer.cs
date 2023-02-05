using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeterminePlayer : MonoBehaviour
{
    public GameObject playerRigidbody;
    public Transform playerModel;

    private void Awake()
    {
        playerRigidbody.transform.position = PlayerManager._instance.spawnPosition1.position;
    }
}
