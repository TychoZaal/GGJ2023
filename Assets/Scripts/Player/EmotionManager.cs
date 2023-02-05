using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionManager : MonoBehaviour
{
    private Animator expressionPlayer;

    [SerializeField]
    private Image emoteImage;

    [SerializeField]
    private Sprite angry, sad;

    private void Awake()
    {
        expressionPlayer = GetComponent<Animator>();    
    }

    public void BeAngry()
    {
        emoteImage.sprite = angry;
        expressionPlayer.SetTrigger("Emote");
    }

    public void BeSad()
    {
        emoteImage.sprite = sad;
        expressionPlayer.SetTrigger("Emote");
    }   
}
