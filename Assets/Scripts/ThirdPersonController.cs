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
        Debug.Log(speed);
        /*
        if (Input.GetKeyDown("up")){
            speed += 1;
   
            if (speed > 10){
                speed = 10;
            }
            Debug.Log ("Up Arrow Pressed and Speed is " + speed);
        }
        else if (Input.GetKeyDown("down")) {
            speed -= 1;
   
            if (speed < 0) {
                speed = 0;
            }
            Debug.Log ("Down  Arrow Pressed and Speed is " + speed);
        }
        skele.GetComponent<Animator>().SetInteger ("speed", speed);

    }

    void FixedUpdate() {
        skele.GetComponent<Rigidbody>().velocity = skele.transform.forward * (speed * 0.1f);
    }
    */

        if (Input.GetKey(KeyCode.Mouse1)){
            speed = 5;
            /*speed += 1;

            if (speed > 10){
                speed = 10;
            }*/

            playerCharacter.velocity = transform.forward * speed;
            anim.SetBool("Walking", true);
        } else {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKey("w")){
            speed = 12;
      
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