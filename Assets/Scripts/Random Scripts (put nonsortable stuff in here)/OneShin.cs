using UnityEngine;
public class OneShin : MonoBehaviour, IAbno
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float[] playerStats;
    public int dmgType = 1;
    public int dmgAmnt = 1;
    public bool canEscape = false;
    public bool hasAngerMeter = false;
    public int maxAngerCount = 0;
    public int angerCount = 0;
    public int threatLevel = 0;
    public float chanceToGetGift = 0.05f;
    public float chanceToGetEnkH = 0.3f;
    public float chanceToGetEnkM = 0.6f;
    public float chanceToGetEnkS = 0.05f;
    public float workTime = 1;
    public int amountOfWorks = 10;
    public float egoGiftID;
    public int id = 1;

    // Update is called once per frame
    public void Start() {
        player = GameObject.Find("Bongbong");
        Move playerScript = player.GetComponent<Move>();
        playerStats = new float[4];
        playerStats[0] = playerScript.bodyMAX; // use max stat
        playerStats[1] = playerScript.mindMAX;
        playerStats[2] = playerScript.soulMAX;
        if(playerScript.Favors[id-1]) {
            playerStats[3] = 1;
        }
        else {
            playerStats[3] = 0;
        }
        
    }

    public void onBadWorkResult() {

    }

    public void onNormalWorkResult() {

    }

    public void onGoodWorkResult() {

    }

    public void onEmployeeDeath() {

    }

    public void getEgoGift() {

    }

    





    public GameObject Player 
    { 
        get => player; 
        set => player = value;
    }

    public float[] PlayerStats
    { 
        get => playerStats; 
        set => playerStats = value;
    }
    public int DmgType 
    { 
        get => dmgType; 
        set => dmgType = value;
    }
    public int DmgAmnt 
    { 
        get => dmgAmnt; 
        set => dmgAmnt = value;
    }
    public bool CanEscape 
    { 
        get => canEscape; 
        set => canEscape = value;
    }
    public bool HasAngerMeter 
    { 
        get => hasAngerMeter; 
        set => hasAngerMeter = value;
    }
    public int MaxAngerCount 
    { 
        get => maxAngerCount; 
        set => maxAngerCount = value;
    }
    public int AngerCount 
    { 
        get => angerCount; 
        set => angerCount = value;
    }

    public int ThreatLevel 
    { 
        get => threatLevel; 
        set => threatLevel = value;
    }

    public float ChanceToGetGift 
    { 
        get => chanceToGetGift; 
        set => chanceToGetGift = value;
    }

    public float WorkTime 
    { 
        get => workTime; 
        set => workTime = value;
    }
    
    public int Id 
    { 
        get => id;
        set => id = value;
    }

    public int AmountOfWorks 
    { 
        get => amountOfWorks;
        set => amountOfWorks = value;
    }

    public float ChanceToGetEnkH 
    { 
        get => chanceToGetEnkH;
        set => chanceToGetEnkH = value;
    }

    public float ChanceToGetEnkM 
    { 
        get => chanceToGetEnkM;
        set => chanceToGetEnkM = value;
    }

    public float ChanceToGetEnkS 
    { 
        get => chanceToGetEnkS;
        set => chanceToGetEnkS = value;
    }

}
