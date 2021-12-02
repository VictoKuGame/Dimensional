using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransfrom; //*The object the camera should follow.
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float cameraFollowSpeed = 0.2f;
    /*private void Awake()
    {
       //*targetTransform = gameObject.GetComponent<PlayerManager>().transform;
    }*/
    public void FollowTarget()
    {
       Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransfrom.position, ref cameraFollowVelocity,cameraFollowSpeed);
        transform.position = targetPosition;
    }
    
}
