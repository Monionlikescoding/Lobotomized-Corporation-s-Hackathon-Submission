using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Hierarchy;


public class Door : MonoBehaviour, IDoor
{
    Animator anim;
    public GameObject exit;
    public int size;
    Transform AnimationRunner;
    Transform GoThroughRunner;
    //public bool fullyOpen = false;
    private bool opening;
    private int openState;
    public int roomid;
    public List<Sprite> openSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        AnimationRunner = transform.Find("AnimationRunner");
        GoThroughRunner = transform.Find("GoThroughRunner");
        opening=false;
        openState=0;

        switch (size) {
            case 1: // smol
                openSprites=GameObject.Find("Game Manager").GetComponent<variableScript>().doorSprites;
                break;
            case 0: // norm
                openSprites=GameObject.Find("Game Manager").GetComponent<variableScript>().doorSpritesNORMAL;
                break;
            case 2: // corridor
                openSprites=GameObject.Find("Game Manager").GetComponent<variableScript>().doorSpritesCorridor;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(opening&&openState<15){
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
        if (other.CompareTag("Player")||other.CompareTag("AbnoEscaped"))
        {
            opening=true;
            exit.GetComponent<Door>().opening=true;
            if (other.IsTouching(GoThroughRunner.GetComponent<Collider2D>()))
            {
                Transform exitPoint = exit.transform.Find("Exit");
                other.gameObject.transform.position = exitPoint.position;
                foreach(GameObject ab in GameObject.FindGameObjectsWithTag("AbnoEscaped")){
                    ab.GetComponent<TrackPlayer>().resetDir();
                }
                if(other.CompareTag("Player")){
                    other.GetComponent<Move>().RoomId = exit.GetComponent<Door>().roomid;
                }
                else{
                    other.GetComponent<TrackPlayer>().Roomid = exit.GetComponent<Door>().roomid;
                }
                
            }
        }

        if (other.CompareTag("Employee"))
        {
            opening=true;
            exit.GetComponent<Door>().opening=true;
            if (other.IsTouching(GoThroughRunner.GetComponent<Collider2D>()))
            {
                Transform exitPoint = exit.transform.Find("Exit");
                other.gameObject.transform.position = exitPoint.position;
                other.GetComponent<EmployeeMove>().RoomId = exit.GetComponent<Door>().roomid;
            }
        }

        if (other.CompareTag("EscapedAbno"))
        {
            opening=true;
            exit.GetComponent<Door>().opening=true;
            if (other.IsTouching(GoThroughRunner.GetComponent<Collider2D>()))
            {
                Transform exitPoint = exit.transform.Find("Exit");
                other.gameObject.transform.position = exitPoint.position;
                other.GetComponent<TrackPlayer>().roomid = exit.GetComponent<Door>().roomid;
            }
        }
    }
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")||other.CompareTag("AbnoEscaped"))
        {
            opening=false;
            exit.GetComponent<Door>().opening=false;
        }
	}
    void OnTriggerStay2D(Collider2D other){
        if ((other.CompareTag("Player")||other.CompareTag("AbnoEscaped"))&&opening==false)
        {
            opening=true;
            exit.GetComponent<Door>().opening=true;
        }

    }
    /*public void openDoor() {
        switch(size) {
            case 0: anim.SetBool("open",true); break;
            case 1: anim.SetBool("openSMALL", true); break;
        }
    }
    public void closeDoor() {
        switch(size) {
            case 0: anim.SetBool("open",false); break;
            case 1: anim.SetBool("openSMALL", false); break;
        }
    }*/

    /*
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if(exitPoint != null) {
            otherDoorScript = exitPoint.GetComponentInParent<Door>();
        }
        else {
            Debug.Log("No exit point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stateOfOpening == 1) {
            if(fullyOpen) {
                switch(size) {
                    case 0: anim.SetBool("open",false); break;
                    case 1: anim.SetBool("openSMALL", false); break;
                }
                stateOfOpening = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Use tags to identify what entered the zone
        if (other.CompareTag("Player"))
        {
            anim.SetBool("open",true);
            exit.GetComponent<Door>().anim.SetBool("open",true);
        }
        
    }

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player") && stateOfOpening != 1)
        {
            switch(size) {
                case 0: anim.SetBool("open",false); break;
                case 1: anim.SetBool("openSMALL", false); break;
            }
        }
	}

    public void openThisDoor() {
        switch(size) {
            case 0: anim.SetBool("open",true); break;
            case 1: anim.SetBool("openSMALL", true); break;
        }
        stateOfOpening = 1;
    }

    public void UseDoor(GameObject player) {
        if (exitPoint != null && fullyOpen && !calledAlready)
        {   
            otherDoorScript.openThisDoor();
            calledAlready = true;
            StartCoroutine(teleportPlayer(0.15f, player)); // first param is seconds, second param is player
        }
    }

    IEnumerator teleportPlayer(float delayTime, GameObject player)
    {
        yield return new WaitForSeconds(delayTime);
        player.transform.position = exitPoint.transform.position;
        calledAlready = false;
    }
    */
    /*public void OnDoorOpened()
    {
        fullyOpen = true;
    }

    public void OnDoorClosed()
    {
        fullyOpen = false;
    }*/

    public int getOtherDoorID() {
        return exit.GetComponent<Door>().roomid;
    }

    public int RoomID 
    { 
        get => roomid;
        set => roomid = value;
    }
    public GameObject Exit 
    { 
        get => exit;
        set => exit = value;
    }
}
