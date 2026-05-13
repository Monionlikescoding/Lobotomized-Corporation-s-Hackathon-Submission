using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ElevatorDoor : MonoBehaviour, IDoor
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // (OnEnable is just start but slightly different)
    private GameObject player;
    public InputActionProperty EAction;
    public float cd = 0;
    public GameObject targetDoor;
    public int roomID;


    private void Start()
    {
        player=GameObject.Find("Bongbong");
        EAction.action.Enable();
        transform.Find("InteractButton").gameObject.SetActive(false);
        
	}

    private void Update() {
        cd -= Time.deltaTime;
    }

    public void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (EAction.action.ReadValue<float>() > 0 && targetDoor.GetComponent<ElevatorDoor>().cd < 0 && cd < 0) {
                Debug.Log(player.GetComponent<Move>());
                OnEClicked();
            }

            Transform button = transform.Find("InteractButton");
            if (button != null)
                button.gameObject.SetActive(true);
        }

        if (collision.CompareTag("Employee")) {
            if (collision.gameObject.GetComponent<EmployeeMove>().wantToGoDownElevator && targetDoor.GetComponent<ElevatorDoor>().cd < 0 && cd < 0) {
                MoveEmployee(collision.gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Transform button = transform.Find("InteractButton");
            if (button != null)
                button.gameObject.SetActive(false);
        }
    }

    private void OnEClicked() {
        player.GetComponent<Move>().RoomId = targetDoor.GetComponent<ElevatorDoor>().roomID;
        targetDoor.GetComponent<ElevatorDoor>().cd = 1;
        cd = 1;
        Vector2 pos = targetDoor.transform.position;
        pos.y -= 0.5f;
        pos.x -= 0.5f;
        player.transform.position = pos;
    }

    private void MoveEmployee(GameObject employe) {
        employe.GetComponent<EmployeeMove>().RoomId = targetDoor.GetComponent<ElevatorDoor>().roomID;
        targetDoor.GetComponent<ElevatorDoor>().cd = 1;
        cd = 1;
        Vector2 pos = targetDoor.transform.position;
        pos.y -= 0.5f;
        pos.x -= 0.5f;
        employe.transform.position = pos;
    }

    public int getOtherDoorID() {
        return targetDoor.GetComponent<ElevatorDoor>().roomID;
    }

    public int RoomID 
    { 
        get => roomID;
        set => roomID = value;
    }

    public GameObject Exit 
    { 
        get => targetDoor;
        set => targetDoor = value;
    }
}
