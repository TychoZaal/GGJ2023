using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBounds : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("checkBounds");
        Vector3 pos = transform.position;
        float x = Mathf.Clamp(pos.x, GameEnvironment.Instance.minX, GameEnvironment.Instance.maxX);
        float z = Mathf.Clamp(pos.z, GameEnvironment.Instance.minZ, GameEnvironment.Instance.maxZ);
        transform.position = new Vector3(x, pos.y, z);
    }
}
