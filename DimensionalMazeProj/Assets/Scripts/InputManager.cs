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
    public bool sInput = false;
    public int sInputSwp = 0;
    public bool mInput;
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
            playerControls.PlayerActions.Shift.performed += i => bInput = true;
            playerControls.PlayerActions.Shift.canceled += i => bInput = false;
            playerControls.PlayerActions.Space.performed += i => sInput = true;
            playerControls.PlayerActions.Map.performed += i => mInput = true;
            playerControls.PlayerActions.Map.canceled += i => mInput = false;
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
        if (bInput)
        {
            scaleSliderP.value -= 1;
        }
    }
    private void HandleVisionInput()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "SampleScene")
        {
            if (sInput)
            {
                sInputSwp++;
                if (sInputSwp <= 2)
                {
                    maze1.generateAnotherOne(sInputSwp % 2 == 0, sInputSwp % 2 != 0);
                }
                if (scaleSliderS.value > 20)
                {
                    environmentTypeR1.SetActive(sInputSwp % 2 == 0);
                    environmentTypeQ1.SetActive(sInputSwp % 2 != 0);
                    scaleSliderS.value -= 20;
                    sInput = false;
                }
                else
                {
                    environmentTypeR1.SetActive(true);
                    environmentTypeQ1.SetActive(true);
                }
            }
        }
        else
        {
            if (sInput)
            {
                sInputSwp++;
                if (scaleSliderS.value > 20)
                {
                    environmentTypeR1.SetActive(sInputSwp % 2 == 0);
                    environmentTypeQ1.SetActive(sInputSwp % 2 != 0);
                    scaleSliderS.value -= 20;
                    sInput = false;
                }
            }
        }
    }
}





























