using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Workbuttonscripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // (OnEnable is just start but slightly different)
    private GameObject player;
    public InputActionProperty EAction;
    public IAbno abnoIF;
    public GameObject cell;
    public GameObject abno;
    public GameObject workObject;
    public float workTime;
    //public VisualTreeAsset inf;
    public VisualElement workUI;
    public UIDocument doc;

    private work wok;
    public int roomID;


    private void Start()
    {
        // 1. Get the root VisualElement from the UIDocument component
        player=GameObject.Find("Bongbong");
        wok=GameObject.Find("Bongbong").GetComponent<work>();
        workObject=GameObject.Find("WorkUI");
        doc=GetComponent<UIDocument>();
        EAction.action.Enable();
        transform.Find("InteractButton").gameObject.SetActive(false);
        
	}

	private void Update() {
	}
    
	public void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            if(EAction.action.IsPressed()) {
                OnEClicked();
                Debug.Log("Yep");
            }
            transform.Find("InteractButton").gameObject.SetActive(true);
        }
    }
	public void OnTriggerExit2D(Collider2D collision) {
		if(collision.CompareTag("Player")) {
            if(workObject.activeSelf==true) workObject.SetActive(false);
            transform.Find("InteractButton").gameObject.SetActive(false);
		}
	}

	private void OnEClicked()
    {   
        if(abno.GetComponent<OneShin>().CurrentCD<0){
            abnoIF = abno.GetComponent<IAbno>();
            workTime = abnoIF.WorkTime;
            workObject.SetActive(true);
            workObject.GetComponent<WorkTypeScripts>().buttonScript = gameObject.GetComponent<Workbuttonscripts>();
        }
        //change work time based on another stat later
    }

    public void start(string workType){
        workObject.SetActive(false);
        Vector2 pos = cell.transform.position;
        pos.y -= 1.3f;
        pos.x += 0.75f;
        player.transform.position = pos;
        player.GetComponent<Move>().RoomId = roomID;
        GameObject AbNo = cell.transform.Find("Abnormality").gameObject;
        wok.Work(AbNo, workTime, AbNo.GetComponent<IAbno>().AmountOfWorks, gameObject, workType);
        Debug.Log("Something happened");
    }
}
