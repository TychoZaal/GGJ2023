using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text tomatoText;
    [SerializeField] private TMP_Text cucumberText;
    [SerializeField] private TMP_Text waveText;

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

    public void SetWaveText(int waveNumber)
    {
        waveText.text = "Oh no! More veggies are escaping...";

        if (waveNumber <= 1)
            waveText.text = "Oh oh! The veggies are escaping...";

        waveText.gameObject.SetActive(true);
    }

    public void SetTextToTime(string text)
    {
        waveText.text = text;
        waveText.gameObject.SetActive(true);
    }

    public void FinalizeGame()
    {
        string winner = ScoreManager.Instance.scoreTomato > ScoreManager.Instance.scoreCucumber ? "Red" : "Blue";
        waveText.text = "Player " + winner + " won!";
        waveText.gameObject.SetActive(true);
        Invoke("ResetScene", 10.0f);
    }

    public void WaitingForPlayer()
    {
        waveText.text = "Waiting for both players...";
        waveText.gameObject.SetActive(true);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene("Lisa");
    }

        public void DisableWaveText()
    {
        waveText.gameObject.SetActive(false);
    }
}
