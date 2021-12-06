using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    CameraManager cameraManager; 
    [SerializeField] Slider HP;
    private void Awake()
    {
        inputManager = gameObject.GetComponent<InputManager>();
        cameraManager = FindObjectOfType(typeof(CameraManager)) as CameraManager;
        playerLocomotion = gameObject.GetComponent<PlayerLocomotion>();
    }
    private void Update()
    {
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovements();
    }
    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
           SceneManager.LoadScene("Loader");
        }
    }
}












