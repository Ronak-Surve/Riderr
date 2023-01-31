using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    private bool move = false;
    private bool isGrounded = false;

    public Rigidbody2D rb;

    public float speed = 20f;

    public float rotationSpeed = 2f;

    private void Update(){
        if (Input.GetButtonDown ("Fire1")) { // Mouse left click button pressed
            move = true;
        }
        if (Input.GetButtonUp ("Fire1")) { // Mouse left click button released
            move = false;
        }
    }



    private void FixedUpdate(){
        if (move == true) {

            if (isGrounded) {
                rb.AddForce ( transform.right * speed * Time.fixedDeltaTime * 100f , ForceMode2D.Force);
            } else {
                rb.AddTorque (rotationSpeed * rotationSpeed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
        }
    }


    private void OnCollisionEnter2D(){
        isGrounded = true;
    }

    private void OnCollisionExit2D(){
        isGrounded = false;
        
    }
        
}

