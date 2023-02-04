using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5, acceleration = 3, decceleration = 2, velPower = 1;

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
        moveDirection = moveDirection * speed;

        Vector2 speedDiff = new Vector2(moveDirection.x - rb.velocity.x, moveDirection.z - rb.velocity.z);
        Vector2 accelerate = new Vector2((Mathf.Abs(moveDirection.x) > 0.01f) ? acceleration : decceleration, (Mathf.Abs(moveDirection.z) > 0.01f) ? acceleration : decceleration);
        float movementX = Mathf.Pow(Mathf.Abs(speedDiff.x) * accelerate.x, velPower) * Mathf.Sign(speedDiff.x);
        float movementZ = Mathf.Pow(Mathf.Abs(speedDiff.y) * accelerate.y, velPower) * Mathf.Sign(speedDiff.y);
        Vector3 movement = new Vector3(movementX, 0, movementZ);

        rb.AddForce(movement);
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
