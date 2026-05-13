using UnityEngine;

public interface IDoor {

    int RoomID{ get; set; } 
    GameObject Exit {get; set;}

    public int getOtherDoorID();
    
}