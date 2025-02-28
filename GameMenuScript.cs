using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    [SerializeField] private Button singleplayerButton;
    [SerializeField] private Button multiplayerButton;
    [SerializeField] private Button backButton;
    void Start()
    {
        Button button1 = singleplayerButton.GetComponent<Button>();
        button1.onClick.AddListener(singleplayerButtonClicked);
        Button button2 = multiplayerButton.GetComponent<Button>();
        button2.onClick.AddListener(multiplayerButtonClicked);
        Button button3 = backButton.GetComponent<Button>();
        button3.onClick.AddListener(backButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void singleplayerButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 2;
        MainMenuScript.instance.menuUpdate = true;
    }
    void multiplayerButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 3;
        MainMenuScript.instance.menuUpdate = true;
    }
    void backButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 0;
        MainMenuScript.instance.menuUpdate = true;
    }
}
