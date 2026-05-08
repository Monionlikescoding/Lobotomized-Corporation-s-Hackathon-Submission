using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class SodaMachine : MonoBehaviour, IAbno
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float[] playerStats;
    public int dmgType = 0;
    public int dmgAmnt = 1;
    public bool canEscape = false;
    public bool hasAngerMeter = false;
    public int maxAngerCount = 0;
    public int angerCount = 0;
    public int threatLevel = 0;
    public float chanceToGetGift = 0.05f;
    public float chanceToGetEnkH = 0.65f;
    public float chanceToGetEnkM = 0.65f;
    public float chanceToGetEnkS = 0.55f;
    public float workTime = 0.8f;
    public int workType;
    public int amountOfWorks = 9;
    public int good=8;
    public int bad=4;
    public float egoGiftID;
    public int workResult;
    public float cooldown=10f;
    private float currentCD=-1f;
    public int id = 2;
    private GameObject cd;
    private GameObject result;
    private variableScript mang; 
    private ArrayList tem;

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
        currentCD=-1;
        cd=transform.parent.Find("Enk WorldSpace").Find("WorkResultUI").Find("WorkCoolDown").gameObject;
        cd.GetComponent<TextMeshProUGUI>().text = "";
        result=transform.parent.Find("Enk WorldSpace").Find("WorkResultUI").Find("WorkResult").gameObject;
        result.GetComponent<Image>().enabled=false;
        mang=GameObject.Find("Game Manager").GetComponent<variableScript>();

		Transform parentTransform = transform.parent;
        
        if (parentTransform != null)
        {
            Transform worldSpace = parentTransform.Find("Enk WorldSpace");
            if (worldSpace != null)
            {
                Transform textChild = worldSpace.Find("Enk Text");
                
                if (textChild != null)
                {
                    textChild.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }
    }
    
	public void FixedUpdate() {
		if(currentCD>0){
            currentCD--;
            cd.GetComponent<TextMeshProUGUI>().text = ((int)currentCD/60).ToString();
            
            switch(workResult) {
                case 0: cd.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); break; // RGB Alpha
                case 1: cd.GetComponent<TextMeshProUGUI>().color = new Color32(255, 168, 0, 255); break;
                case 2: cd.GetComponent<TextMeshProUGUI>().color = new Color32(0, 255, 0, 255); break;
            }

		}
        if(currentCD==0){
            foreach (GameObject item in tem)
            {
                Destroy(item);
            }
            currentCD--;
            cd.GetComponent<TextMeshProUGUI>().text = "";
            result.GetComponent<Image>().enabled=false;
            transform.parent.Find("Enk WorldSpace").Find("Enk Text").gameObject.GetComponent<TextMeshProUGUI>().enabled=false;
        }
	}

    public void finished(int enke){
        currentCD=cooldown*60;
        result.GetComponent<Image>().enabled=true;
        tem=player.GetComponent<work>().temps;
        if(enke<=bad){
            result.GetComponent<Image>().sprite=mang.bad;
            onBadWorkResult();
            workResult = 0;
        }
        else if(enke>=good){
            result.GetComponent<Image>().sprite=mang.good;
            onGoodWorkResult();
            workResult = 2;
        }
        else{
            result.GetComponent<Image>().sprite=mang.norm;
            onNormalWorkResult();
            workResult = 1;
		}
	}

	public void onBadWorkResult() {
        player.GetComponent<Move>().body -= 8;
    }

    public void onNormalWorkResult() {

    }

    public void onGoodWorkResult() {
        switch(workType) {
            case 0 : player.GetComponent<Move>().body += 10; break;
            case 1 : player.GetComponent<Move>().mind += 10; break;
            case 2 : player.GetComponent<Move>().soul += 3; break;
            case 3 : player.GetComponent<Move>().mind += 5; player.GetComponent<Move>().body += 8; break;
        }
        
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

    public int Good 
    { 
        get => good;
        set => good = value;
    }

    public int Bad 
    { 
        get => bad;
        set => bad = value;
    }

    public int AmountOfWorks 
    { 
        get => amountOfWorks;
        set => amountOfWorks = value;
    }

    public int WorkType 
    { 
        get => workType;
        set => workType = value;
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

    public float Cooldown 
    { 
        get => cooldown;
        set => cooldown = value;
    }

    public float CurrentCD 
    { 
        get => currentCD;
        set => currentCD = value;
    }

}
