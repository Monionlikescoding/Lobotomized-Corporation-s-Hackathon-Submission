using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EmployeeMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed; // Speed is multiplied by 100
    public float accel;
    public int RoomId;
    public Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;
    public GameObject currRoom;
    Animator anim;
    public GameManager gameObjectScript;

    public float body = 10f;
    public float bodyMAX = 15f;

    public float mind = 15f;
    public float mindMAX = 15f;

    public float soul=15f;
    public float soulMAX=15f;

    public bool wantToGoDownElevator = true;


    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        

        // Sets speed to default value
        if(speed == 0) {
            speed = 6;
        }

        playerRb.linearDamping = 20f;
    }

	private void Update() {

        currRoom = gameObjectScript.rooms[RoomId];

        if(soul > soulMAX) {
            soul = soulMAX;
        }
        if(mind > mindMAX) {
            mind = mindMAX;
        }
        if(body > bodyMAX) {
            body = bodyMAX;
        }
        
	}
	// Fixed update is constant time, (this is needed for applying forces & velocity management as many devices run on different framerates)
	void FixedUpdate()
    {
        Vector2 moveValue = new Vector2(1,0);
        //playerRb.AddForce(moveValue * speed * 500 * Time.deltaTime);
        Vector2 vel = playerRb.linearVelocity;


        vel.x = Mathf.Clamp(vel.x, -speed, speed); // clamping x-velocity to speed
        playerRb.linearVelocity = vel;
        anim.SetBool("working", false);
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


}
