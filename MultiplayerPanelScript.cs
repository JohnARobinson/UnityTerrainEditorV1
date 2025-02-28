using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerPanelScript : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;
    [SerializeField] private Button backButton;
    void Start()
    {
        Button button1 = newGameButton.GetComponent<Button>();
        button1.onClick.AddListener(newGameButtonClicked);
        Button button2 = loadGameButton.GetComponent<Button>();
        button2.onClick.AddListener(loadGameButtonClicked);
        Button button3 = backButton.GetComponent<Button>();
        button3.onClick.AddListener(backButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void newGameButtonClicked()
    {
        Debug.Log("New Multiplayer Game");
    }
    void loadGameButtonClicked()
    {
        Debug.Log("Load Multiplayer Game");
    }
    void backButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 1;
        MainMenuScript.instance.menuUpdate = true;
    }
}
