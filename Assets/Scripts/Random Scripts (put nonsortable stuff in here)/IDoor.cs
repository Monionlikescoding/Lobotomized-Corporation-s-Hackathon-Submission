using UnityEngine;

public interface IDoor {

    int RoomID{ get; set; } 

    public int getOtherDoorID();
    
}