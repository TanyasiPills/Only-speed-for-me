using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suspension : MonoBehaviour
{
    public float springConstant = 1000f; 
    public float equilibriumPosition = 1f; 
    public float dampingFactor = 100f;

    private Vector3 previousVelocity;
    private float previousDisplacement;

    public Rigidbody rb;

    private void FixedUpdate() {
        float displacement = transform.localPosition.y - equilibriumPosition;
        Vector3 springForce = -springConstant * displacement * transform.up;
        Vector3 dampingForce = -dampingFactor * (rb.velocity - previousVelocity);
        rb.AddForce(springForce + dampingForce);
        previousVelocity = rb.velocity;
        previousDisplacement = displacement;
    }
}
