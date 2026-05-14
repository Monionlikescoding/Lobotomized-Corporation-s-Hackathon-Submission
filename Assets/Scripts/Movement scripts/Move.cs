using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed; // Speed is multiplied by 100
    public float accel;
    public int RoomId;
    InputAction moveAction;
    public InputActionProperty click;
    public Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public work workScript;
    public float body = 10f;
    public float bodyMAX = 15f;

    public float mind = 15f;
    public float mindMAX = 15f;

    public float soul=15f;
    public float soulMAX=15f;

    public bool[] Favors; // This is the array that has the boolean values for whether special work is available
    public int[] enkephalin;

    public bool currentlyWorking = false;


    public Slider progressBarH;
    public float targetProgressH;
    public Slider progressBarM;
    public float targetProgressM;
    public float fillSpeed = 3f;
    public float atkCDMAX = 0.6f;
    public float atkCD = 0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        workScript = GetComponent<work>();
        click.action.Enable();

        // Sets speed to default value
        if(speed == 0) {
            speed = 6;
        }

        playerRb.linearDamping = 20f;
    }

	private void Update() {


        UpdateProgressH((float) (body / bodyMAX));
        UpdateProgressM((float) (mind / mindMAX));

        Vector2 posBar1 = gameObject.transform.position;
        posBar1.y += 0.9f;
        progressBarH.transform.position = posBar1;

        Vector2 posBar2 = gameObject.transform.position;
        posBar2.x -= 0.1548f;
        posBar2.y += 0.744f;
        progressBarM.transform.position = posBar2;

        if(soul > soulMAX) {
            soul = soulMAX;
        }
        if(mind > mindMAX) {
            mind = mindMAX;
        }
        if(body > bodyMAX) {
            body = bodyMAX;
        }

        if (click.action.ReadValue<float>() > 0) {
            OnClik();
        }
        atkCD += Time.deltaTime;
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
            if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name=="swipe"){
                vel.x = Mathf.Clamp(vel.x, -speed/33, speed/33);
            }
            playerRb.linearVelocity = vel;
            anim.SetBool("working", false);
            Transform atkHB = transform.Find("Attack HitBox");
            if(moveValue.x != 0) {
                anim.SetBool("walking", true);
            

            }
            else {
                anim.SetBool("walking", false);
            }

            if(moveValue.x < 0) {
                transform.localScale = new Vector2(-1, 1);
                atkHB.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }
            else if(moveValue.x > 0) {
                transform.localScale = new Vector2(1, 1);
                atkHB.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

        }
        else {
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("working", true);
        }


    }

    public void UpdateProgressH(float value)
    {
        // Ensure value is between 0 and 1 (or your min/max)
        progressBarH.value = value;
    }

    public void UpdateProgressM(float value)
    {
        progressBarM.value = value;
    }

    public void OnClik() {
        if(atkCD >= atkCDMAX && !currentlyWorking) {
            GameObject.Find("Canvas").transform.Find("WorkUI").GetComponent<WorkTypeScripts>();
			// Optional: Get the screen position of the mouse at the moment of click
			Vector2 mousePosition = Mouse.current.position.ReadValue();
            if (!EventSystem.current.IsPointerOverGameObject()){
                anim.SetTrigger("swipe");
                Debug.Log("attacked");
            }
			atkCD = 0f;
        }
    }

            

}
