using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanelScript : MonoBehaviour
{
    [SerializeField] private Button gameButton;
    [SerializeField] private Button editorButton;
    [SerializeField] private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        Button button1 = gameButton.GetComponent<Button>();
        button1.onClick.AddListener(gameButtonClicked);
        Button button2 = editorButton.GetComponent<Button>();
        button2.onClick.AddListener(editorButtonClicked);
        Button button3 = exitButton.GetComponent<Button>();
        button3.onClick.AddListener(exitButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void gameButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 1;
        MainMenuScript.instance.menuUpdate = true;
    }
    void editorButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 4;
        MainMenuScript.instance.menuUpdate = true;
    }
    void exitButtonClicked()
    {
        Application.Quit();
    }
}
