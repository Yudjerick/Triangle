using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float currSpeed;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool crouching = false;
    private bool lerpCrouch = false;
    private float crouchTimer = 0;
    private bool sprinting = false;
    public float speed = 5f;
    public float gravity = -9.8f;

    public float jumpHeight = 3f;

    public float weaponAnimationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = controller.isGrounded;
        if (lerpCrouch){
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);
            if (p>1){
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
        weaponAnimationSpeed = currSpeed * speed;
        Debug.Log(controller.velocity.magnitude / (currSpeed));
        Debug.Log("Curr speed: " + currSpeed);



        if (weaponAnimationSpeed > 1)
        {
            weaponAnimationSpeed = 1;
        }
        if (!isGrounded)
        {
            weaponAnimationSpeed = 0;
        }
    }
    //recieve the inputs for our InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;


        if (isGrounded && playerVelocity.y<0)
            playerVelocity.y= -2f;
        controller.Move(playerVelocity*Time.deltaTime);
        currSpeed = transform.TransformDirection(moveDirection).magnitude * speed * Time.deltaTime;
    }
    public void Jump(){
        if (isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight* -3.0f * gravity);
        }
    }

    public void Crouch(){
        crouching = !crouching;
        speed = 3f;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }
}
