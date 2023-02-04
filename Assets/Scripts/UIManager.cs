using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text tomatoText;
    [SerializeField] private TMP_Text cucumberText;

    public static UIManager Instance { get; private set; }

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

    public void UpdateScore(int tomatoScore, int cucumberScore)
    {
        tomatoText.text = tomatoScore.ToString();
        cucumberText.text = cucumberScore.ToString();
    }
}
