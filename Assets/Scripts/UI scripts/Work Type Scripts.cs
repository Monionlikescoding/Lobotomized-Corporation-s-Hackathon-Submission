using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WorkTypeScripts : MonoBehaviour
{
    private GameObject player;
    public int workTime;
    private Move move;
    private GameObject viewPoint;
    public Workbuttonscripts buttonScript;
    public bool Using = false;
    public Button body;
    public Button mind;
    public Button soul;
    public Button special;
    public int mindPercent;
    public int bodyPercent;
    public int soulPercent;
    public int specialPercent;


    private void Start()
    {
        move=GameObject.Find("Bongbong").GetComponent<Move>();
        body=transform.Find("HealthButton").GetComponent<Button>();
        body.onClick.AddListener(OnBodyButtonClick);
		mind=transform.Find("MindButton").GetComponent<Button>();
        mind.onClick.AddListener(OnMindButtonClick);
		soul=transform.Find("SoulButton").GetComponent<Button>();
        soul.onClick.AddListener(OnSoulButtonClick);
		special=transform.Find("SpecialButton").GetComponent<Button>();
        special.onClick.AddListener(OnSpecialButtonClick);
        gameObject.SetActive(false);
	}
	private void Update() {
        if(buttonScript != null) {
            if(buttonScript.abnoIF != null) {
                bodyPercent = (int) ((buttonScript.abnoIF.ChanceToGetEnkH + move.bodyMAX*0.005)*100);
                mindPercent = (int) ((buttonScript.abnoIF.ChanceToGetEnkM + move.mindMAX*0.005)*100);
                soulPercent = (int) ((buttonScript.abnoIF.ChanceToGetEnkS + move.soulMAX*0.005)*100);
                specialPercent = (int) ((1)*100);            
            }
        }
        body.GetComponentInChildren<TextMeshProUGUI>().text = bodyPercent + "%";
        mind.GetComponentInChildren<TextMeshProUGUI>().text = mindPercent + "%";
        soul.GetComponentInChildren<TextMeshProUGUI>().text = soulPercent + "%";
        special.GetComponentInChildren<TextMeshProUGUI>().text = specialPercent + "%";
	}

	private void OnBodyButtonClick()
    {   
        Debug.Log("[On Hit] : Murder");
        buttonScript.start("Body");
	}
    private void OnMindButtonClick()
    {   
        Debug.Log("[On Think] : Murder");
        buttonScript.start("Mind");
	}
    private void OnSoulButtonClick()
    {   
        Debug.Log("[On Ego] : Murder");
        buttonScript.start("Soul");
	}
    private void OnSpecialButtonClick()
    {   
        Debug.Log("[On Special Work] : Murder");
        buttonScript.start("Special");
	}
    
}
