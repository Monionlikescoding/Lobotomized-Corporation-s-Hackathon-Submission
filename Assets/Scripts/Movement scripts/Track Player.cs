using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour
{
    public int Roomid;
    public GameObject[] roomIds;
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
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
    }

    // Update is called once per frame
    void Update()
    {   
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
        doors = new ArrayList();
        target = null;
        currRoom = gameObjectScript.rooms[Roomid];
        
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
            if(players[i].GetComponent<Move>().RoomId == Roomid) {
                target=players[i];
            }
        }
        if(target != null) {
            Vector2 direction = (target.transform.position - gameObject.transform.position).normalized;
            direction.y = 0;
            transform.Translate(direction*Time.deltaTime*0.5f);
        }
    }
    public void resetDir(){
        //dir='n';
    }
}
