using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor.TerrainTools;

public class GameManager : MonoBehaviour
{
    //public GameObject[] doors;
    public Dictionary<string, string[]> abnoInfo; // Literally just a map but in c#
    public GameObject[] rooms;
    public GameObject player;
    public Camera mainCam;
    private ProgressBar health;
    private ProgressBar mind;
    private Move scr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
		scr =player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 roomPos = rooms[player.GetComponent<Move>().RoomId].transform.position;
        roomPos.z -= 10;
        mainCam.transform.position = roomPos;
    }
}
