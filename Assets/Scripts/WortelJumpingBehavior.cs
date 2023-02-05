using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WortelJumpingBehavior : MonoBehaviour
{
    [SerializeField] private float minJumpheight;
    [SerializeField] private float maxJumpheight;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private float minJumpWaitTime;
    [SerializeField] private float maxJumpWaitTime;

    [SerializeField] private float wortelHeightOffset = 0.1f;

    public float wortelHeight = 0f;

    private float t = 0f;
    private Vector3 startPos;
    private Vector3 targetPos;
    private Vector3 curveHandle;

    bool isJumping = false;

    public int currentColumn;
    public int currentRow;

    private void Awake()
    {
        Collider col = GetComponent<Collider>();
        if (GameEnvironment.Instance != null)
        {
            wortelHeight = GameEnvironment.Instance.ground.transform.position.y - col.bounds.size.y / 2f;
            wortelHeight += wortelHeightOffset;
        }

        transform.position = new Vector3(transform.position.x, wortelHeight, transform.position.z);
    }

    void FixedUpdate()
    {
        //if (Vector3.Distance(player.position, transform.position) <= 0.5f && !isJumping)
        //{
        //    isJumping = true;
        //    startPos = transform.position;
        //    targetPos = dest.position;
        //    curveHandle = (startPos + targetPos) / 2f;
        //    curveHandle = new Vector3(curveHandle.x, jumpheight, curveHandle.z);
        //}

        if (isJumping)
        {
            transform.position = BezierPos();
            t += jumpSpeed * Time.deltaTime;

            //Debug.Log(Vector3.Distance(transform.position, targetPos));
            if (Vector3.Distance(transform.position, targetPos) <= 0.1f || transform.position.y < wortelHeight - 2f)
            {
                t = 0f;
                isJumping = false;
                float waitTime = Random.Range(minJumpWaitTime, maxJumpWaitTime);
                Invoke("Jump", waitTime);
            }

        }
    }

    public void Jump()
    {
        Debug.Log("Jump");
        List<Vector2Int> movePos = new List<Vector2Int>() { new Vector2Int(-1, -1), new Vector2Int(-1, 0), new Vector2Int(-1, 1), new Vector2Int(0, -1), new Vector2Int(0, 1), new Vector2Int(1, -1), new Vector2Int(1, 0), new Vector2Int(1, 1) };

        List<Vector2Int> availablePos = new List<Vector2Int>();
        foreach (Vector2Int m in movePos)
        {
            int c = currentColumn + m.x;
            int r = currentRow + m.y;

            if (c < 0 || r < 0 || c >= CarrotGrid.Instance.columns || r >= CarrotGrid.Instance.rows) continue;

            if (CarrotGrid.Instance.carrotPoints[c, r].availability)
            {
                availablePos.Add(m);
            }
        }
        if (availablePos.Count == 0)
        {
            Debug.Log("no available position to go for carrot");
            return;
        }

        int index = Random.Range(0, availablePos.Count - 1);

        CarrotGrid.Instance.carrotPoints[currentColumn, currentRow].availability = true;

        currentColumn += availablePos[index].x;
        currentRow += availablePos[index].y;

        CarrotGrid.Instance.carrotPoints[currentColumn, currentRow].availability = false;

        startPos = transform.position;
        targetPos = CarrotGrid.Instance.carrotPoints[currentColumn, currentRow].pos;
        targetPos = new Vector3(targetPos.x, wortelHeight, targetPos.z);
        curveHandle = (startPos + targetPos) / 2f;
        float jumpheight = Random.Range(minJumpheight, maxJumpheight);
        curveHandle = new Vector3(curveHandle.x, wortelHeight + jumpheight, curveHandle.z);
        isJumping = true;
    }

    Vector3 BezierPos()
    {
        return Mathf.Pow(1f - t, 2f) * startPos + 2 * t * (1 - t) * curveHandle + Mathf.Pow(t, 2) * targetPos;
    }
}
