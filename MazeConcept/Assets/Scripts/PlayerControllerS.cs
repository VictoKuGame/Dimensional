using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerControllerS : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool buttonIsPressed = false;
    private GameObject ATypeWall;
    private GameObject AlternativeTypeWall;
    private GameObject FinishScr;
    void Start()
    {
        ATypeWall= GameObject.FindGameObjectWithTag("ATypeWall");
        AlternativeTypeWall= GameObject.FindGameObjectWithTag("AlternativeTypeWall");
        AlternativeTypeWall.SetActive(false);
        FinishScr = GameObject.FindGameObjectWithTag("FinishScr");
        FinishScr.SetActive(false);
    }
    //* Updates every frame.
    void Update()
    {
        ProcessInputs();
    }
    //* Updates every fixed amount of frames.
    void FixedUpdate()
    {
        Move();
    }
    //* Calculating the changes for the position and swaps the image of the players image by X axis respectivly.
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //* (.normalized) was added so the movement in 2 axis simultaneously wont double the speed . 
        moveDirection = new Vector2(moveX, moveY).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonIsPressed = true;
            ATypeWall.SetActive(false);
            AlternativeTypeWall.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            buttonIsPressed = false;
            ATypeWall.SetActive(true);
            AlternativeTypeWall.SetActive(false);
        }
    }
    //*Calculates the velocity of the the player using its position and Unity added speed.
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            FinishScr.SetActive(true);
        }
    }
    //* Function for replay button correct workflow.
    public void Replay()
    {
        SceneManager.LoadScene("Game1");
    }
}




