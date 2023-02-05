using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5, acceleration = 3, decceleration = 2, velPower = 1, rotationSpeed = 1.0f;

    [SerializeField]
    private Rigidbody rb;

    private Vector2 movementInput;

    [SerializeField]
    private Transform model;

    private Vector3 lastLookAtPosition;

    public enum State { MOVING, IDLE, STUNNED, WAITING };
    [SerializeField]
    public State playerState = State.WAITING;

    private Vector3 waitPosition;

    [SerializeField]
    private Transform square, joystick;

    private void Start()
    {
        waitPosition = PlayerManager._instance.GetSpawnPosition().position;

        Vector3 lookAtPosition = transform.position + Vector3.one;
        lookAtPosition.y -= 1;
        rb.transform.LookAt(lookAtPosition);

        StartCoroutine(ToggleImage(joystick, 0.0f, 3.0f));
        Invoke("ResetPlayerState", 0.5f);
    }

    private IEnumerator ToggleImage(Transform transformObj, float waitTime, float uptime)
    {
        Vector3 originalScale = transformObj.localScale;
        yield return new WaitForSeconds(waitTime);

        transformObj.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        yield return new WaitForSeconds(uptime);

        transformObj.localScale = originalScale;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    public void ChangePlayerState(State newState)
    {
        this.playerState = newState;
    }

    public void ResetPlayerState()
    {
        this.playerState = State.IDLE;
        rb.isKinematic = false;
    }

    private void MovePlayer()
    {
        if (playerState == State.STUNNED) return;
        if (playerState == State.WAITING)
        {
            rb.transform.position = waitPosition;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            model.LookAt(model.position + new Vector3(movementInput.x, 0, movementInput.y));

            return;
        }

        if (playerState == State.IDLE) ChangePlayerState(State.MOVING);

        Vector3 moveDirection = rb.transform.forward * movementInput.y + rb.transform.right * movementInput.x;
        moveDirection = moveDirection * speed;

        Vector2 speedDiff = new Vector2(moveDirection.x - rb.velocity.x, moveDirection.z - rb.velocity.z);
        Vector2 accelerate = new Vector2((Mathf.Abs(moveDirection.x) > 0.01f) ? acceleration : decceleration, (Mathf.Abs(moveDirection.z) > 0.01f) ? acceleration : decceleration);
        float movementX = Mathf.Pow(Mathf.Abs(speedDiff.x) * accelerate.x, velPower) * Mathf.Sign(speedDiff.x);
        float movementZ = Mathf.Pow(Mathf.Abs(speedDiff.y) * accelerate.y, velPower) * Mathf.Sign(speedDiff.y);
        Vector3 movement = new Vector3(movementX, 0, movementZ);

        rb.AddForce(movement);

        Vector3 desiredRotation = lastLookAtPosition;

        if (rb.velocity.sqrMagnitude > 0.01f)
            desiredRotation = rb.transform.position + rb.velocity;

        Vector3 actualRotation = Vector3.Lerp(lastLookAtPosition, desiredRotation, rotationSpeed);

        model.LookAt(actualRotation);

        lastLookAtPosition = actualRotation;
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
}
