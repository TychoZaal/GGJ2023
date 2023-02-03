using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager _instance;

    public GameObject player1, player2;

    private void Awake(){
        if (_instance == null) _instance = this;
        else Destroy(this);
    }
}
