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
    public static Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;
    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;
    public bool bInput = false;
    public bool sInput = false;
    public int sInputSwp = 0;
    public bool rInput = false;
    public bool aim = false;
    public bool shoot = false;
    private GameObject environmentTypeR1;
    private GameObject environmentTypeQ1;
    public Maze1 maze1;
    //*public NavMeshSurface surface;
    public Text visionEmpty;
    public Image visionEmptyBackground;
    [SerializeField] Slider scaleSliderS;
    [SerializeField] Slider scaleSliderP;
    public GameObject fireball;
    public Transform spawnFireball;
    public bool wasAiming = false;
    public Transform visionWavePulse;
    public GameObject pauseMenu;
    public bool pause = false;
    private void Awake()
    {
        bInput = false;
        sInput = false;
        sInputSwp = 0;
        rInput = false;
        visionEmpty.enabled = false;
        visionEmptyBackground.enabled = false;
        pauseMenu.SetActive(false);
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
            playerControls.PlayerActions.R.performed += i => rInput = true;
            playerControls.PlayerActions.Aim.performed += i => aim = true;
            playerControls.PlayerActions.Aim.canceled += i => aim = false;
            playerControls.PlayerActions.Shoot.performed += i => shoot = (aim) ? true : false;
            playerControls.PlayerActions.Shoot.canceled += i => shoot = false;
            playerControls.PlayerActions.Pause.performed += i => pause = !pause;
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInputs()
    {
        if (pause)
        {
            Time.timeScale = 0f;
            playerControls.Disable();
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            playerControls.Enable();
            pauseMenu.SetActive(false);
        }
        HandleMovementInput();
        HandleSprintingInput();
        HandleVisionInput();
        HandleShootingInput();
    }
    private void HandleMovementInput()
    {
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
        if (aim)
        {
            /*Ray ray = Camera.main.ScreenPointToRay(cameraInput);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var projectile =
                Instantiate(fireball, spawnFireball.position, transform.rotation);
                projectile.transform.LookAt(hit.point);
                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * 10;

            }*/
            transform.LookAt(Camera.main.ScreenToWorldPoint(cameraInput));
            transform.rotation *= Quaternion.Euler(-90, 180, 0);
            verticalInput = 0;
            horizontalInput = 0;
            wasAiming = true;
            animatorManager.UpdateAnimatorShoot(7f);
            if (shoot && scaleSliderP.value > 0)
            {
                Instantiate(fireball, spawnFireball.position, transform.rotation);
                scaleSliderP.value -= 1;
                shoot = false;
            }
        }
        else
        {
            verticalInput = movementInput.y;
            horizontalInput = movementInput.x;
            animatorManager.UpdateAnimatorShoot(0f);
            wasAiming = false;
        }
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
        if (sceneName == "MainGame1")
        {
            if (sInput)
            {
                sInputSwp++;
                if (scaleSliderS.value >= 20)
                {
                    Instantiate(visionWavePulse, transform.position, transform.rotation).transform.SetParent(transform);
                    animatorManager.UpdateAnimatorVision();
                    //*Vision();
                    environmentTypeR1.SetActive(sInputSwp % 2 == 0);
                    environmentTypeQ1.SetActive(sInputSwp % 2 != 0);
                    //*surface.BuildNavMesh();
                    scaleSliderS.value -= 20;
                    sInput = false;
                }
                else
                {
                    environmentTypeR1.SetActive(true);
                    environmentTypeQ1.SetActive(true);
                    visionEmpty.enabled = true;
                    visionEmptyBackground.enabled = true;
                    if (rInput)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
            }
        }
        else
        {
            if (sInput)
            {
                sInputSwp++;
                if (scaleSliderS.value >= 20)
                {
                    Instantiate(visionWavePulse, transform.position, transform.rotation).transform.SetParent(transform);
                    animatorManager.UpdateAnimatorVision();
                    environmentTypeR1.SetActive(sInputSwp % 2 == 0);
                    environmentTypeQ1.SetActive(sInputSwp % 2 != 0);
                    scaleSliderS.value -= 20;
                    sInput = false;
                }
                else
                {
                    visionEmpty.enabled = true;
                    visionEmptyBackground.enabled = true;
                    if (rInput)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                }
            }
        }
    }
    private void HandleShootingInput()
    {
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void Resume()
    {
        pause = false;
    }
    private IEnumerator Vision()
    {
        yield return new WaitForSeconds(0.567f);
    }
}






























