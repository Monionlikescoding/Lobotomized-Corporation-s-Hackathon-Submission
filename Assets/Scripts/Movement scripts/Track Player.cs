using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour
{
    public int roomid;
    public ArrayList roomIds;
    public GameObject[] players;
    public GameObject[] employees;
    public ArrayList doors;
    public GameManager gameObjectScript;
    private GameObject currRoom;
    private GameObject target;
    //private char dir;
    private float targetValue; // Basically, how valuable is the target, is it 0 : a door, 0.45 : person already chosen, 0.5 : a door leading to a player/employee, 1 : an employee, 1.5 : a close employee (within the hit boundary (always prioritizes player)), 2 : a player, 3 : a player inside the hit detection collider (not added yet)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomIds = new ArrayList();
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
    }

    // Update is called once per frame

    // Ok, so how i want this to work is that this enemy will check the room its in, and the adjacent rooms
    // This is cuz you can get the adjacent rooms from the room ids of the doors in the current room, but it will take a lot of
    // computing power to check all rooms, so adjacent room detection seems like the best option rn
    // Iterate through all child objects of the room the enemy is currently in, check if each object has the IDoor component and get its roomid ("GetComponent<IDoor>().RoomID)'
    // Now with those ids, iterate through all player characters and check whether their room ids are the same to any in the arraylist
    // If the roomid of the enemy and the player are the same, just make the enemy move towards the player
    // Otherwise, make it go through the doors by editing the door scripts to allow the enemy to also go through doors, maybe use a function here to decide whether the enemy wants to move through the doors
    void Update()
    {   
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
        roomIds = new ArrayList(); // excludes current room id
        doors = new ArrayList();
        target = null;
        currRoom = gameObjectScript.rooms[roomid];
        
            foreach (Transform child in currRoom.transform)
            {
                bool found = false;
                if(child.gameObject.tag == "Door") {
                    foreach (GameObject P in players) {
                        if(child.gameObject.GetComponent<IDoor>().Exit.GetComponent<IDoor>().RoomID == P.GetComponent<Move>().RoomId){
                            //dir='l';
                            found = true;
                            target = child.gameObject;
                            break;
                        }
                    }
			    }
                if(found) {
                    break;
                }
            }
        //ill finish this later or whatever

        
        //Debug.Log(players.Length);
        
        for(int i = 0; i < players.Length; i++) {
            if(players[i].GetComponent<Move>().RoomId == roomid) {
                target=players[i];
            }
        }
        if(target != null) {
            Vector2 direction = (target.transform.position - gameObject.transform.position).normalized;
            direction.y = 0;
            transform.Translate(direction*Time.deltaTime*0.5f);
        }
    }

}
