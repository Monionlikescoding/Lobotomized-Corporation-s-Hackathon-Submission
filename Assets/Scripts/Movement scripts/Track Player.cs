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
    public char dir;
    private float targetValue; // Basically, how valuable is the target, is it 0 : a door, 0.45 : person already chosen, 0.5 : a door leading to a player/employee, 1 : an employee, 1.5 : a close employee (within the hit boundary (always prioritizes player)), 2 : a player, 3 : a player inside the hit detection collider (not added yet)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomIds = GameObject.Find("Game Manager").GetComponent<GameManager>().rooms;
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        dir='n';
        players=GameObject.FindGameObjectsWithTag("Player");
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
    }

    // Update is called once per frame
    void Update()
    {
        doors = new ArrayList();
        target = null;
        currRoom = roomIds[Roomid];
        
        if(dir=='n'){
            foreach (Transform child in currRoom.transform)
            {
                if(child.gameObject.tag == "DoorL") {
                    if(child.gameObject.GetComponent<Door>().exit.GetComponent<Door>().RoomID==players[0].GetComponent<Move>().RoomId){
                        dir='l';
                        break;
                    }
			    }
                else if(child.gameObject.tag == "DoorR") {
                    if(child.gameObject.GetComponent<Door>().exit.GetComponent<Door>().RoomID==players[0].GetComponent<Move>().RoomId){
                        dir='r';
                        break;
				    }
			    }
            }
        }
        //ill finish this later or whatever
        if(dir=='l'){
            transform.Translate(Vector3.left*Time.deltaTime*0.5f);
        }
        else if(dir=='r'){
            transform.Translate(Vector3.right*Time.deltaTime*0.5f);
		}
        
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
        dir='n';
    }
}
