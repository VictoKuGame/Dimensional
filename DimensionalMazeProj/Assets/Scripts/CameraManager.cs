using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform targetTransfrom; //*The object the camera should follow.
    public Transform cameraPivot; //*The object that the camera uses to look up and down.
    public Transform cameraTransform; //*The actual location of the camera in the scene.
    public LayerMask collisionLayers;//*The layers that the camera should collide with .
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;
    public float cameraCollisionOffSet = 0.2f; // *How much the camera should make a jump off from objects in case of collision .
    public float minimumCollisionOffSet = 0.2f;
    public float cameraCollisionRadius = 2; //* CHANGE TO 0.2F .
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2;
    public float cameraPivotSpeed = 2;
    public float lookAngle;//*Camera down-up perspective.
    public float pivotAngle;//*Camera left-right perspective.
    public float minimumPivotAngle = -35;
    public float maximumPivotAngle = 35;
    private void Awake()
    {
        inputManager = FindObjectOfType(typeof(InputManager)) as InputManager;
        //*targetTransform = gameObject.GetComponent<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }
    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransfrom.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }
    private void RotateCamera()
    {
        lookAngle += (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle -= (inputManager.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minimumPivotAngle, maximumPivotAngle);
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
    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        /* RaycastHit hit;
         Vector3 direction = cameraTransform.position - cameraPivot.position;
         direction.Normalize();
         if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers)){
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            }
           */
        targetPosition = (-0.1f - cameraCollisionOffSet);
        if (Mathf.Abs(targetPosition) < minimumCollisionOffSet)
        {
            targetPosition -= minimumCollisionOffSet;
        }
        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.1f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}


