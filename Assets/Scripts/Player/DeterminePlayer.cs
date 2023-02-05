using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeterminePlayer : MonoBehaviour
{
    public GameObject playerRigidbody;
    public Transform playerModel;

    public Transform hatPlayer1, hatPlayer2;

    private void Awake()
    {
        playerRigidbody.transform.position = PlayerManager._instance.spawnPosition1.position;
        if (PlayerManager._instance.isPlayerOne())
        {
            hatPlayer1.gameObject.SetActive(true);
            hatPlayer2.gameObject.SetActive(false);
        }
        else
        {
            hatPlayer1.gameObject.SetActive(false);
            hatPlayer2.gameObject.SetActive(true);
        }
    }
}
