using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminePlayer : MonoBehaviour
{
    public GameObject player1, player2;
    public Transform model1, model2;

    private void Awake() {

        if (PlayerManager._instance.player1 == null) {
            player1.SetActive(true);
            player2.SetActive(false);
            PlayerManager._instance.player1 = gameObject;
            player1.transform.position = PlayerManager._instance.spawnPosition1.position;
            model1.LookAt(Camera.main.transform.position);   
        }

        else if (PlayerManager._instance.player2 == null){
            player1.SetActive(false);
            player2.SetActive(true);
            PlayerManager._instance.player2 = gameObject;
            player2.transform.position = PlayerManager._instance.spawnPosition2.position;
            model2.LookAt(Camera.main.transform.position);
        }

        else Destroy(gameObject);
    }

    public Transform GetModel()
    {
        return player1.activeInHierarchy ? model1 : model2;
    }
}
