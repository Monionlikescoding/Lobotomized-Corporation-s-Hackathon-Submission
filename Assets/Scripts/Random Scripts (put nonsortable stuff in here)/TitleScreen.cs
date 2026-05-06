using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Button newGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newGame=transform.Find("New Game").GetComponent<Button>();
        newGame.onClick.AddListener(NewGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NewGame(){
        SceneManager.LoadScene("GameScene");
    }
}
