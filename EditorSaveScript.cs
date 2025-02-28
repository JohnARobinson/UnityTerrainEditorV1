using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class EditorSaveScript : MonoBehaviour
{
    DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/DataFiles/");
    FileInfo[] info;

    
    public Scrollbar saveScrollBar;
    //public InputField saveInputField;
    public TMP_InputField saveInputField;
    public Button saveButton;
    public Button exitButton;
    public String saveInputFieldText;

    //**********************************
    public TextMeshProUGUI saveTitleText;
    public GameObject saveButtonPrefab;
    public GameObject saveButtonPrefabParent;
    public GameObject newSave;
    int fileCount = 0;
    int prevFileCount = 0;

    public List<string> saveList;
    void Start()
    {
        saveList = new List<string>();
        fileCount = 0;
        prevFileCount = 2;

        Button button1 = saveButton.GetComponent<Button>();
        button1.onClick.AddListener(saveButtonClicked);

        Button button2 = exitButton.GetComponent<Button>();
        button2.onClick.AddListener(exitButtonClicked);
        reloadDatFiles();
    }

    // Update is called once per frame
    void Update()
    {   
        initialize();
        checkForNewDatFiles();
        //Debug.Log(fileCount + " vs " + prevFileCount);
        if(fileCount != prevFileCount)
        {
            reloadDatFiles();
        }
        prevFileCount = fileCount;
    }

    //string array to check for dupes
    void initialize()
    {
        info = dir.GetFiles("*.dat");
        foreach (FileInfo f in info)
        {
            saveList.Add(f.Name);
        }
    }

    void saveButtonClicked()
    {
        saveInputFieldText = saveInputField.text;
        bool duplicateCheck = false;
        for(int i = 0; i < saveList.Count; i++)
        {
            Debug.Log(saveList[i] );
            if(saveList[i] == saveInputFieldText)
            {
                duplicateCheck = true;
            }
        }

        if(duplicateCheck == false)
        {
            FileManagerScript.instance.saveEditor(saveInputFieldText);
            gameObject.SetActive(false);
        }
        else{
            Debug.Log("File Already Exists, Please enter something else");
        }
    }

    void exitButtonClicked()
    {
        StateManagerScript.instance.gameState = 5;
        loadDatFiles();
        gameObject.SetActive(false);
    }

    void loadDatFiles()
    {
        Debug.Log("Exit Save Interface");
    }

    void checkForNewDatFiles()
    {
        info = dir.GetFiles("*.dat");
        fileCount = 0;
        foreach (FileInfo f in info)
        {
            fileCount++;
        }
    }
    void reloadDatFiles()
    {
        bool duplicateCheck;
        info = dir.GetFiles("*.dat");
        foreach (FileInfo f in info)
        {
            duplicateCheck = false;
            for(int i = 0; i < saveList.Count; i++)
            {
                if(saveList[i] == f.Name)
                {
                    duplicateCheck = true;
                }
            }
            if(duplicateCheck == false)
            {
                newSave = Instantiate(saveButtonPrefab, saveButtonPrefabParent.transform);
                //newSave.transform.parent = saveButtonPrefabParent.transform;
                //newSave.GetComponentInChildren<Text>().text = f.Name;
                saveTitleText = newSave.GetComponentInChildren<TextMeshProUGUI>();
                saveTitleText.text = f.Name;
            }
            
        }
    }
}
