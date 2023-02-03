using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    [SerializeField]
    private float dumpIntensity = 1.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody otherPlayer = collision.gameObject.GetComponent<Rigidbody>();
            // otherPlayer.AddExplosionForce(dumpIntensity);
        }
    }
}
