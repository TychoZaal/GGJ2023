using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminePlayer : MonoBehaviour
{
    public GameObject player1, player2;

    private void Awake() {

        if (PlayerManager._instance.player1 == null) {
            player1.SetActive(true);
            player2.SetActive(false);
            PlayerManager._instance.player1 = gameObject;
        }

        else if (PlayerManager._instance.player2 == null){
            player1.SetActive(false);
            player2.SetActive(true);
            PlayerManager._instance.player2 = gameObject;
        }

        else Destroy(gameObject);
    }
}
