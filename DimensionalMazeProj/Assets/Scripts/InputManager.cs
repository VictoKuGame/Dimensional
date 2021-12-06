using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InputManager : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    public Vector2 movementInput;
    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;
    public bool bInput;
    public bool sInput;
    public bool pInput;
    private GameObject environmentTypeR1;
    private GameObject environmentTypeQ1;
    public Maze1 maze1;





    [SerializeField] Slider scaleSliderS;
    [SerializeField] Slider scaleSliderP;
    private void Awake()
    {
        animatorManager = gameObject.GetComponent<AnimatorManager>();
        playerLocomotion = gameObject.GetComponent<PlayerLocomotion>();
        environmentTypeR1 = GameObject.FindGameObjectWithTag("EnvironmentTypeR1");
        environmentTypeQ1 = GameObject.FindGameObjectWithTag("EnvironmentTypeQ1");
        environmentTypeQ1.SetActive(false);
    }
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.B.performed += i => bInput = true;
            playerControls.PlayerActions.B.canceled += i => bInput = false;
            playerControls.PlayerActions.S.performed += i => sInput = true;
            playerControls.PlayerActions.S.canceled += i => sInput = false;
            playerControls.PlayerActions.P.performed += i => pInput = true;
            playerControls.PlayerActions.P.canceled += i => pInput = false;
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleVisionInput();
    }
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }
    private void HandleSprintingInput()
    {
        playerLocomotion.isSprinting = (bInput && moveAmount > 0.5f);
        if (bInput && !sInput && !pInput)
        {
            scaleSliderS.value += 1;
            scaleSliderP.value += 1;
        }
    }
    private void HandleVisionInput()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "SampleScene")
        {
            if (sInput && scaleSliderS.value > 0)
            {
                environmentTypeR1.SetActive(false);
                environmentTypeQ1.SetActive(true);
                maze1.generateAnotherOne(true, false);
                scaleSliderS.value -= 1;
            }
            else if (pInput && scaleSliderP.value > 0)
            {
                environmentTypeR1.SetActive(true);
                environmentTypeQ1.SetActive(false);
                maze1.generateAnotherOne(false, true);
                scaleSliderP.value -= 1;
            }
            else
            {
                environmentTypeR1.SetActive(true);
                environmentTypeQ1.SetActive(true);
            }
        }
        else
        {
            if (sInput && scaleSliderS.value > 0)
            {
                environmentTypeR1.SetActive(false);
                environmentTypeQ1.SetActive(true);
                scaleSliderS.value -= 1;
            }
            else if (pInput && scaleSliderP.value > 0)
            {
                environmentTypeR1.SetActive(false);
                environmentTypeQ1.SetActive(true);
                scaleSliderP.value -= 1;
            }
            else
            {
                environmentTypeR1.SetActive(true);
                environmentTypeQ1.SetActive(false);
            }
        }
    }
}







