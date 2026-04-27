using UnityEngine;
using UnityEngine.UIElements;

public class Abnobuttonscripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // (OnEnable is just start but slightly different)
    public VisualTreeAsset inf;
    private GameObject abnoInfo;
    private Info scr;
    private void Start()
    {
        // 1. Get the root VisualElement from the UIDocument component
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; // Gets the root element

        // 2. Find the button by name
        Button myButton = root.Q<Button>("ClicktoWork"); // Gets the button

        // 3. Assign the function to the 'clicked' event
        if (myButton != null)
        {
            myButton.clicked += OnButtonClick;
        }
        abnoInfo = GameObject.Find("AbnoInfo");
        scr=abnoInfo.GetComponent<Info>();
        abnoInfo.SetActive(false);
    }

    private void OnButtonClick()
    {
        Debug.Log("[On Click] : Murder");
        abnoInfo.SetActive(false);
        scr.showInfo(inf);
    }
}
