using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int currentWave = -1;

    public int amountOfKnollenLeft = 0;

    public static WaveManager Instance { get; private set; }

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

    public void SpawnAllKnollen()
    {
        UIManager.Instance.DisableWaveText();
        float waitTime = 0f;
        float waitTimeAdd = 0.2f;
        for(int i = 0; i < waves[currentWave].wortelAmount; i++)
        {
            KnolSpawner.Instance.Invoke("SpawnWortel", waitTime);
            waitTime += waitTimeAdd;
            amountOfKnollenLeft++;
        }

        waitTimeAdd = 0.4f;
        for (int i = 0; i < waves[currentWave].bosuiAmount; i++)
        {
            KnolSpawner.Instance.Invoke("SpawnBosui", waitTime);
            waitTime += waitTimeAdd;
            amountOfKnollenLeft++;
        }
        for (int i = 0; i < waves[currentWave].radijsAmount; i++)
        {
            KnolSpawner.Instance.Invoke("SpawnRadijs", waitTime);
            waitTime += waitTimeAdd;
            amountOfKnollenLeft++;
        }
    }

    public void GoToNextWave()
    {
        currentWave++;

        if (currentWave >= 4)
        {
            UIManager.Instance.FinalizeGame();
            return;
        }

        UIManager.Instance.SetWaveText(currentWave + 1);
        Invoke("SpawnAllKnollen", 3f);
    }

    public void PutKnolDown()
    {
        amountOfKnollenLeft--;

        if(amountOfKnollenLeft <= 0)
        {
            GoToNextWave();
        }
    }
}
