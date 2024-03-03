using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Transform lookTarget;
    public float positionSmoothTime = 0.2f;
    public float rotationSmoothTime = 12f;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x,transform.position.y,target.position.z), ref velocity, positionSmoothTime);
            transform.position = targetPosition;

            Quaternion targetRotation = Quaternion.LookRotation(lookTarget.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothTime * Time.deltaTime);
        }
    }
}
