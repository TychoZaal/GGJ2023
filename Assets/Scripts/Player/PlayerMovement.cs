using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    private Rigidbody rb;

    private Vector2 movementInput;

    private void Start()
    {
        var detPlayer = GetComponent<DeterminePlayer>();
        rb = detPlayer.player1.activeInHierarchy ? detPlayer.player1.GetComponent<Rigidbody>() : detPlayer.player2.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var moveDirection = rb.transform.forward * movementInput.y + rb.transform.right * movementInput.x;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
