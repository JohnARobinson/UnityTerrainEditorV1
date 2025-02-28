using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using UnityEditor.Build.Content;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


public class FileManagerScript : MonoBehaviour
{
    public static FileManagerScript instance { get; private set;}
    int prevState;

    public GameObject dataManager;
    public GameObject meshManager;
    public GameObject inputManager;
    public GameObject shaderManager;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject editorUI;
    [SerializeField] private GameObject editorSaveUI;
    private EditorSaveScript saveInEditor;
    

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

    }

    // Update is called once per frame
    void Update()
    {
        //start editor
        if(prevState == 2)
        {
            if(StateManagerScript.instance.gameState == 5)
            {
                startEditor();
            }
        }

        //start editor
        if(prevState == 5)
        {
            if(StateManagerScript.instance.gameState == 2)
            {
                exitEditor();  
            }
        }

        if(prevState == 5)
        {
            if(StateManagerScript.instance.gameState == 7)
            {
                //Debug.Log("saving");
                //saveEditor();
                //StateManagerScript.instance.gameState = 5;
            }
        }

        prevState = StateManagerScript.instance.gameState;
    }

    void startEditor()
    {
        dataManager.SetActive(true);
        meshManager.SetActive(true);
        inputManager.SetActive(true);
        shaderManager.SetActive(true);

        //MapDataScript.instance.resetData();
        //CliffDataScript.instance.resetData();
        //MeshManagementScript.instance.reInitializeMeshes();

    }

    void exitEditor()
    {
        StartCoroutine(MapDataScript.instance.resetData());
        StartCoroutine(CliffDataScript.instance.resetData());

        dataManager.SetActive(false);
        meshManager.SetActive(false);
        inputManager.SetActive(false);
        shaderManager.SetActive(false);

        mainMenu.SetActive(true);
        editorUI.SetActive(false);
        MainMenuScript.instance.mainMenuState = 0;

    }
    public void saveEditor(string title)
    {
        
        Debug.Log("start saving");
        //CreateTextFile(title);
        CreateWorldCoordinateDataFile(title);
        Debug.Log("done saving");
        AssetDatabase.Refresh();
        StateManagerScript.instance.gameState = 5;
    }

    void CreateTextFile(string title)
    {

        saveInEditor = editorSaveUI.GetComponent<EditorSaveScript>();
        //string path = Application.dataPath + "/log.txt";
        string path = Application.dataPath + "/TextFile/" + title + ".txt";

        if(!File.Exists(path))
        {
            File.WriteAllText(path, title);
        }
        string content = "Test123";
        File.AppendAllText(path, content);
    }

    public void CreateWorldCoordinateDataFile(string title)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        //string path = Application.persistentDataPath + "/Assets/DataFiles" + title + ".world";
        string path = Application.dataPath + "/DataFiles/" + title + ".dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        CurrentMapData data = new CurrentMapData();
        formatter.Serialize(stream, data);
        stream.Close();

        
    }


    //[Serializable]
    [System.Serializable]
    public class CurrentMapData
    {
        float[] verticies = MapDataScript.instance.SerializeVector3Data();
        //float[] uv = MapDataScript.instance.SerializeUVData();
        //int[] triangles = MapDataScript.instance.triangles;
    }

}
