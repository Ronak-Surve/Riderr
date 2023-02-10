using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private bool move = false;
    private bool isGrounded = false;
    private bool isDead = false; // added flag to check if the rider is dead
    private bool isFlipping = false;

    public Rigidbody2D rb;

    public float speed = 200f;

    public float rotationSpeed = 20f;

    private int score = 0;
    private int highScore = 0;

    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetButtonDown("Fire1")) // Mouse left click button pressed
            {
                move = true;
            }
            if (Input.GetButtonUp("Fire1")) // Mouse left click button released
            {
                move = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (move == true && isGrounded)
            {
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            else if (move == true)
            {
                rb.AddTorque(rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D()
    {
        isGrounded = true;
        if (transform.up.y < 0)
            {
            isDead = true;
            Debug.Log("You died!");
            DisplayScore();
            }
    }

    // private void OnCollisionExit2D()
    // {
    //     isGrounded = false;
    //     if (rb.velocity.y > 0 && !isGrounded && !isDead && !isFlipping) // Check if the car is flipping up
    //     {
    //         score += 3; // Add 3 points to the score
    //         isFlipping = true;

    //         Debug.Log("Score: " + score);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            if (!isDead)
            {
                score += 1;
                Debug.Log("Coin collected! Current score: " + score);
            }
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFlipping = false;
        }
    }

    private void DisplayScore()
    {
    Debug.Log("Final Score: " + score);
    if (score > highScore)
        {
        highScore = score;
        Debug.Log("New high score achieved: " + highScore);
        }
    else
        {
        Debug.Log("High score: " + highScore);
        }
    }
}