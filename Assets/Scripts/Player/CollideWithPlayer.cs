using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    [SerializeField]
    private float bumpIntensity = 1.0f;

    [SerializeField]
    private float bounceDuration = 1.0f;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private EmotionManager emotionManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (playerMovement.playerState == PlayerMovement.State.STUNNED || playerMovement.playerState == PlayerMovement.State.WAITING) return;

            playerMovement.ChangePlayerState(PlayerMovement.State.STUNNED);
            playerMovement.Invoke("ResetPlayerState", bounceDuration);
            rb.AddForce(collision.contacts[0].normal * bumpIntensity);
            emotionManager.BeAngry();
            rb.GetComponent<EmotionManager>().BeAngry();
        }

        if (collision.collider.CompareTag("Obstacle"))
        {
            if (playerMovement.playerState == PlayerMovement.State.STUNNED || playerMovement.playerState == PlayerMovement.State.WAITING) return;

            playerMovement.ChangePlayerState(PlayerMovement.State.STUNNED);
            playerMovement.Invoke("ResetPlayerState", bounceDuration);
            rb.AddForce(collision.contacts[0].normal * bumpIntensity);
            emotionManager.BeSad();
        }
    }
}
