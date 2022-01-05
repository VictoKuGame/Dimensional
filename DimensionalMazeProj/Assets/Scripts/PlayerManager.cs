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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (collision.gameObject.CompareTag("Finish"))
        {
            if (sceneName != "Tutorial")
            {
                GameControlManage.level++;
                GameControlManage.enemyHealth++;
                if (GameControlManage.height > GameControlManage.width)
                {
                    GameControlManage.width++;
                }
                else
                {
                    if (GameControlManage.level % 5 == 0)
                    {
                        GameControlManage.enemyHealth = 1;
                        GameControlManage.height++;
                        GameControlManage.numOfEnemiesAtSpawn++;
                    }
                }
            }
            SceneManager.LoadScene("Loader");
        }
    }
    private void Hit()
    {
        if (HP.value >= 25)
        {
            HP.value -= 25;
        }
        else
        {
            GameControlManage.punched = true;
            SceneManager.LoadScene("Loader");
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Hit();
        }
    }
}











