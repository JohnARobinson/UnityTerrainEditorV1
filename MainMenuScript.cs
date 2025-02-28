using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public static MainMenuScript instance { get; private set;}
    public int mainMenuState;
    public bool menuUpdate;

    //0
    public GameObject mainMenuPanel;

    //1
    public GameObject gameMenuPanel;

    //2
    public GameObject singleplayerPanel;

    //5
    public GameObject singleplayerLoadPanel;

    //3
    public GameObject multiplayerPanel;

    //4
    public GameObject editorPanel;

    private void Awake() 
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        mainMenuState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateMainMenu();
    }
    void updateMainMenu()
    {
        if(mainMenuState == 0)
        {
            mainMenuPanel.SetActive(true);
            gameMenuPanel.SetActive(false);
            singleplayerPanel.SetActive(false);
            multiplayerPanel.SetActive(false);
            editorPanel.SetActive(false);
            singleplayerLoadPanel.SetActive(false);
        }

        if(mainMenuState == 1)
        {
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(true);
            singleplayerPanel.SetActive(false);
            multiplayerPanel.SetActive(false);
            editorPanel.SetActive(false);
            singleplayerLoadPanel.SetActive(false);
        }

        if(mainMenuState == 2)
        {
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(false);
            singleplayerPanel.SetActive(true);
            multiplayerPanel.SetActive(false);
            editorPanel.SetActive(false);
            singleplayerLoadPanel.SetActive(false);
        }

        if(mainMenuState == 3)
        {
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(false);
            singleplayerPanel.SetActive(false);
            multiplayerPanel.SetActive(true);
            editorPanel.SetActive(false);
            singleplayerLoadPanel.SetActive(false);
        }
        //editor Menu
        if(mainMenuState == 4)
        {
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(false);
            singleplayerPanel.SetActive(false);
            multiplayerPanel.SetActive(false);
            editorPanel.SetActive(true);
            singleplayerLoadPanel.SetActive(false);
        }
        if(mainMenuState == 5)
        {
            mainMenuPanel.SetActive(false);
            gameMenuPanel.SetActive(false);
            singleplayerPanel.SetActive(false);
            multiplayerPanel.SetActive(false);
            editorPanel.SetActive(false);
            singleplayerLoadPanel.SetActive(true);
        }
    }   
}
