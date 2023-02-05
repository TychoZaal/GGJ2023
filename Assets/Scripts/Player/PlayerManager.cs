using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager _instance;

    public GameObject player1, player2;

    public Transform spawnPosition1, spawnPosition2;

    public int playersSpawned = 0;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    public Transform GetSpawnPosition()
    {
        var pos = playersSpawned == 0 ? spawnPosition1 : spawnPosition2;
        playersSpawned++;

        if (playersSpawned == 1) WaveManager.Instance.GoToNextWave();
        return pos;
    }

    public bool isPlayerOne()
    {
        return playersSpawned == 1;
    }
}
