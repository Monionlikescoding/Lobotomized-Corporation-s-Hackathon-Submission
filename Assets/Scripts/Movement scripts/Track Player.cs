using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour
{
    public int roomid;
    public ArrayList roomIds;
    public GameManager gameObjectScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomIds = new ArrayList();
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
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
        roomIds = new ArrayList();

        /*
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            // This only gets immediate children. 
            // To get children of children, you'd need a recursive loop.
        }
        */
    }
}
