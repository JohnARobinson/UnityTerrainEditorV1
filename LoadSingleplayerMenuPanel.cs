using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSingleplayerMenuPanel : MonoBehaviour
{
    [SerializeField] private Button backButton;
    void Start()
    {
        Button button3 = backButton.GetComponent<Button>();
        button3.onClick.AddListener(backButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void backButtonClicked()
    {
        MainMenuScript.instance.mainMenuState = 1;
        MainMenuScript.instance.menuUpdate = true;
    }
}
