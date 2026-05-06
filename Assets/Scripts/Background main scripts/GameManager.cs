using UnityEngine;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public GameObject[] doors;
    public Dictionary<string, string[]> abnoInfo; // Literally just a map but in c#
    public GameObject[] rooms;
    public GameObject player;
    public Camera mainCam;
    private Move scr;

    public Slider healingBar1;
    public float timeMax = 5f;
    public float time = 1f;
    public float fillSpeed = 3f;
    public float healingAmnt = 3;
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
        if(time < timeMax) {
            time += Time.deltaTime;
        }

        healingBar1.value = time / timeMax;

        if(time >= timeMax) {
            if(player.GetComponent<Move>().RoomId == 0) {
                if(player.GetComponent<Move>().body <= (player.GetComponent<Move>().bodyMAX - healingAmnt)) {
                    player.GetComponent<Move>().body += healingAmnt;
                }
                else {
                    player.GetComponent<Move>().body = player.GetComponent<Move>().bodyMAX;
                }

                if(player.GetComponent<Move>().mind <= (player.GetComponent<Move>().mindMAX - healingAmnt) && player.GetComponent<Move>().mind != 0) {
                    player.GetComponent<Move>().mind += healingAmnt;
                }
                else if(player.GetComponent<Move>().mind != 0){
                    player.GetComponent<Move>().mind = player.GetComponent<Move>().mindMAX;
                }
            }
            time = 0;
        }

    }
}
