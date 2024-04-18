using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Pad = collision.gameObject;
        Rigidbody rb = Pad.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1500);
    }
}
