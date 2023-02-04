using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WortelJumpingBehavior : MonoBehaviour
{
    //[SerializeField] private Transform dest;
    //[SerializeField] private Transform player;
    //[SerializeField] private float jumpheight;
    //[SerializeField] private float jumpSpeed;

    //private float t = 0f;
    //private Vector3 startPos;
    //private Vector3 targetPos;
    //private Vector3 curveHandle;

    //bool isJumping = false;

    //void FixedUpdate()
    //{
    //    if (Vector3.Distance(player.position, transform.position) <= 0.5f && !isJumping)
    //    {
    //        isJumping = true;
    //        startPos = transform.position;
    //        targetPos = dest.position;
    //        curveHandle = (startPos + targetPos) / 2f;
    //        curveHandle = new Vector3(curveHandle.x, jumpheight, curveHandle.z);
    //    }

    //    if (isJumping)
    //    {

    //        transform.position = BezierPos();
    //        t += jumpSpeed * Time.deltaTime;

    //        //Debug.Log(Vector3.Distance(transform.position, targetPos));
    //        if (Vector3.Distance(transform.position, targetPos) <= 0.1f)
    //        {
    //            t = 0f;
    //            isJumping = false;
    //        }

    //    }
    //}

    //Vector3 BezierPos()
    //{
    //    return Mathf.Pow(1f - t, 2f) * startPos + 2 * t * (1 - t) * curveHandle + Mathf.Pow(t, 2) * targetPos;
    //}
}
