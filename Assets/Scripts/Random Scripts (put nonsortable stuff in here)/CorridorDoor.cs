using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Hierarchy;


public class CorridorDoor : MonoBehaviour
{
    Animator anim;
    Transform AnimationRunner;
    private bool opening;
    private int openState;
    public int roomid;
    public int corridorRoomId;
    public List<Sprite> openSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AnimationRunner = transform.Find("AnimationRunner");
        opening=false;
        openState=0;
        openSprites=GameObject.Find("Game Manager").GetComponent<variableScript>().doorSpritesCorridor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(opening&&openState<12){
            openState++;
        }
        else if(!opening&&openState>2){
            openState--;
        }
        //Debug.Log(openSprites[(openState/3)]);
        gameObject.GetComponent<SpriteRenderer>().sprite = openSprites[openState/3];
    }

    void OnTriggerEnter2D(Collider2D other)
    {    
        // Use tags to identify what entered the zone
        if (other.CompareTag("Player"))
        {
            opening=true;
            if (other.IsTouching(AnimationRunner.GetComponent<Collider2D>()))
            {
                
            }
        }
    }
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player"))
        {
            opening=false;
        }
	}
    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player") && opening==false)
        {
            opening=true;
        }

    }
}
