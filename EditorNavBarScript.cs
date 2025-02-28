using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorNavBarScript : MonoBehaviour
{
    public static EditorNavBarScript instance { get; private set;}

    public int EditorNavMenuState = 0;
    [SerializeField] private Button terrainButton;
    [SerializeField] private Button textureButton;
    [SerializeField] private Button objectButton;

    public GameObject terrainPanel;
    public GameObject texturePanel;
    public GameObject objectPanel;

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
        Button button1 = terrainButton.GetComponent<Button>();
        button1.onClick.AddListener(terrainButtonClicked);
        Button button2 = textureButton.GetComponent<Button>();
        button2.onClick.AddListener(textureButtonClicked);
        Button button3 = objectButton.GetComponent<Button>();
        button3.onClick.AddListener(objectButtonClicked);

        //Default Terrain Panel
        terrainPanel.SetActive(true);
        texturePanel.SetActive(false);
        objectPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void terrainButtonClicked()
    {
        EditorNavMenuState = 0;
        Debug.Log("Changed to terrain panel");

        terrainPanel.SetActive(true);
        texturePanel.SetActive(false);
        objectPanel.SetActive(false);
    }
    void textureButtonClicked()
    {
        EditorNavMenuState = 1;
        Debug.Log("Changed to texture panel");
        terrainPanel.SetActive(false);
        texturePanel.SetActive(true);
        objectPanel.SetActive(false);
    }
    void objectButtonClicked()
    {
        EditorNavMenuState = 2;
        Debug.Log("Changed to object panel");

        terrainPanel.SetActive(false);
        texturePanel.SetActive(false);
        objectPanel.SetActive(true);
    }
}
