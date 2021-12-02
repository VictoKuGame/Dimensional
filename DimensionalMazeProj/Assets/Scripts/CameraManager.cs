using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform targetTransfrom; //*The object the camera should follow.
    public Transform cameraPivot;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;
    public float lookAngle;//*Camera down-up perspective.
    public float pivotAngle;//*Camera left-right perspective.
    private void Awake()
    {
        inputManager = FindObjectOfType(typeof(InputManager)) as InputManager;
        //*targetTransform = gameObject.GetComponent<PlayerManager>().transform;
    }
    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransfrom.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }
    private void RotateCamera()
    {
        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);


        //*Should make the camera turn accordingly to the player rotation .
        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }
}
