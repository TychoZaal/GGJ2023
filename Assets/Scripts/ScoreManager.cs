using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int scoreTomato = 0;
    public int scoreCucumber = 0;

    public static ScoreManager Instance { get; private set; }

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

    public void AddScore(int amount, PLAYERCLASS player)
    {
        switch (player)
        {
            case PLAYERCLASS.tomato:
                scoreTomato += amount;
                break;
            case PLAYERCLASS.cucumber:
                scoreCucumber += amount;
                break;
        }
        UIManager.Instance.UpdateScore(scoreTomato, scoreCucumber);
    }
}

public enum PLAYERCLASS
{
    tomato,
    cucumber
}
