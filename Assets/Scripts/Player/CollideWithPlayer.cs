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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerMovement.ChangePlayerState(PlayerMovement.State.STUNNED);
            playerMovement.Invoke("ResetPlayerState", bounceDuration);
            rb.AddForce(collision.contacts[0].normal * bumpIntensity);
        }
    }
}
