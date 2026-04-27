using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed; // Speed is multiplied by 100
    public float accel;
    public int RoomId;
    InputAction moveAction;
    public Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public work workScript;
    public float body = 15f;
    public float bodyMAX = 15f;

    public float mind = 15f;
    public float mindMAX = 15f;

    public float soul=15f;
    public float soulMAX=15f;

    public bool[] Favors; // This is the array that has the boolean values for whether special work is available
    public int[] enkephalin;

    public bool currentlyWorking = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        workScript = GetComponent<work>();

        // Sets speed to default value
        if(speed == 0) {
            speed = 6;
        }

        playerRb.linearDamping = 20f;
    }

	private void Update() {
        //transform.Find("HealthBar").localScale=transform.localScale;
        //transform.Find("MindBar").localScale=transform.localScale;
        if(transform.localScale.x==-1){
            transform.Find("HealthBar").position=new Vector3(-0.5f,0,0)+transform.position;
            transform.Find("MindBar").position=new Vector3(-0.9f,0,0)+transform.position;
        }
        else{
            transform.Find("HealthBar").position=new Vector3(0.5f,0,0)+transform.position;
            transform.Find("MindBar").position=new Vector3(0.9f,0,0)+transform.position;
        }
        
	}
	// Fixed update is constant time, (this is needed for applying forces & velocity management as many devices run on different framerates)
	void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>(); // no need to divide it by accel
        moveValue.y=0; // you can only move in the x-direction
        if(!currentlyWorking) {
            playerRb.AddForce(moveValue * speed * 500 * Time.deltaTime);
        

        Vector2 vel = playerRb.linearVelocity;

        // Currently trying to fix accel so it uses linear damping instead of hardcoding it
        // Test the code, uncomment this out if it doesn't work. Also, linear dampening should be at 10 rn, and speed at 6
        /*
        if(moveValue.y==0){ //if the player doesn't hold a direction key, automatic deceleration happens
            if(vel.x>0){
                vel.x-=speed/400;
            }
            else if(vel.x<0){
                vel.x+=speed/400;
            }
            if(Math.Abs(vel.x)<speed/400){
                vel.x=0;
            }
        }
        */

        vel.x = Mathf.Clamp(vel.x, -speed, speed); // clamping x-velocity to speed
        playerRb.linearVelocity = vel;

        if(moveValue.x != 0) {
            anim.SetBool("walking", true);
        }
        else {
            anim.SetBool("walking", false);
        }

        if(moveValue.x < 0) {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(moveValue.x > 0) {
            transform.localScale = new Vector2(1, 1);
        }

        }
        else {
            transform.localScale = new Vector2(-1,1);
        }


    }

}
