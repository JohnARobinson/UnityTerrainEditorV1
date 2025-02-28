using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorMenuPanelScript : MonoBehaviour
{
    [SerializeField] private Button newMapButton;
    [SerializeField] private Button loadMapButton;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject editorUI;
    void Start()
    {
        Button button1 = newMapButton.GetComponent<Button>();
        button1.onClick.AddListener(newMapButtonClicked);
        Button button2 = loadMapButton.GetComponent<Button>();
        button2.onClick.AddListener(loadMapButtonClicked);
        Button button3 = backButton.GetComponent<Button>();
        button3.onClick.AddListener(backButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void newMapButtonClicked()
    {
        Debug.Log("Generate New Map In Editor");
        StateManagerScript.instance.gameState = 5;
        mainMenu.SetActive(false);
        editorUI.SetActive(true);
    }
    void loadMapButtonClicked()
    {
        Debug.Log("Load Map In Editor");
    }
    void backButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 0;
        MainMenuScript.instance.menuUpdate = true;
    }
}
