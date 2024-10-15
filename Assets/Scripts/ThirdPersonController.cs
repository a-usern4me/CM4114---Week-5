using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour{
    [Header("Variables")]
    public Rigidbody playerCharacter;
    public GameObject skele;
    private int speed;
    public bool worldSpace;
    public bool isGrounded;
    public Vector3 jump;
    public float jumpForce = 1.0f;
    private Animator anim;
  
    void Start(){
        playerCharacter = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        speed = 0;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    

    void Update(){
        //Debug.Log(speed);
        
        if (Input.GetKey(KeyCode.Mouse1)){
            speed = 5;

            playerCharacter.velocity = transform.forward * speed;
            anim.SetBool("Walking", true);
        } else {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey("w")){
            speed += 1;
            if (speed < 12){
                anim.SetBool("Walking", true);
            } else {
                anim.SetBool("Walking", false);
            }

            if (speed > 12){
                speed = 12;
                anim.SetBool("Running", true);
            }
      
            playerCharacter.velocity = transform.forward * speed;
            anim.SetBool("Running", true);
        } else {
            anim.SetBool("Running", false);
        }

        if (Input.GetKey("a")){
            transform.Rotate(new Vector3(0, -1, 0) * Time.fixedDeltaTime * speed, Space.World);
        }

        if (Input.GetKey("s")){
            speed = 1;
            playerCharacter.velocity = -transform.forward * speed; 
        }

        if (Input.GetKey("d")){
            transform.Rotate(new Vector3(0, 1, 0) * Time.fixedDeltaTime * speed, Space.World);
        }

        if (Input.GetKey("space") && (isGrounded == true)){
            playerCharacter.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }

    void OnCollisionStay(Collision Terrain){
        isGrounded = true;
    }
    
}