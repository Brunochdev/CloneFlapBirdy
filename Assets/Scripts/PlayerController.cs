using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody birdyRigidbody;
    public float jumpPower = 6f;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        birdyRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool IsGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && IsGameActive;

        if (canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if(jumpInput){
                Jump();
            }
        }

        birdyRigidbody.useGravity = IsGameActive;
    }


    void OnCollisionEnter(Collision other){
        OnCustomCollisionTriggerEnter(other.gameObject);
    }
    void OnTriggerEnter(Collider other){
        OnCustomCollisionTriggerEnter(other.gameObject);
    }

    private void OnCustomCollisionTriggerEnter(GameObject other){
        bool isSensor = other.CompareTag("Sensor");
        if(isSensor){
            GameManager.Instance.points++;
            Debug.Log("Score: " + GameManager.Instance.points+"!");
        }else{
            GameManager.Instance.EndGame(); 
        }
    }

    private void Jump(){
        jumpCooldown = jumpInterval;

        birdyRigidbody.velocity = Vector3.zero;
        birdyRigidbody.AddForce(new Vector3(0, jumpPower ,0), ForceMode.Impulse);
    }
}
