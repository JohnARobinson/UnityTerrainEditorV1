using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fileEditorTopTabScript : MonoBehaviour
    //, IPointerEnterHandler
    //, IPointerExitHandler
{
    
    /*
    [SerializeField] private GameObject imageSave;
    [SerializeField] private GameObject imageLoad;
    [SerializeField] private GameObject imageQuit;
    [SerializeField] private GameObject save;
    [SerializeField] private GameObject load;
    [SerializeField] private GameObject quit;

    private GameObject selectedGameObject;

    //public GameObject editorCanvas;
    GraphicRaycaster m_Raycaster;
    public PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    */

    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameObject savePanel;
    


    void Start()
    {
        Button button1 = saveButton.GetComponent<Button>();
        button1.onClick.AddListener(saveButtonClicked);
        Button button2 = loadButton.GetComponent<Button>();
        button2.onClick.AddListener(loadButtonClicked);
        Button button3 = quitButton.GetComponent<Button>();
        button3.onClick.AddListener(quitButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if(EventSystem.current.IsPointerOverGameObject())
        {
            rayCastUI();
        }
        else
        {

        }
        */

    }

    void rayCastUI()
    {

        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, maxDistance:1000, 5))
        {
            Debug.Log(hit.transform.gameObject);
            selectedGameObject = hit.transform.gameObject;

            hoverOverFileTabEditor();


            if(selectedGameObject.tag == "saveButton")
            {
                Debug.Log("saving");
            }

        }
        else{
            stopHoverOverFileTabEditor();
            Debug.Log("click");
        }
        */
    }

    void saveButtonClicked()
    {
        StateManagerScript.instance.gameState = 7;
        savePanel.SetActive(true);
    }
    void loadButtonClicked()
    {
        
    }
    void quitButtonClicked()
    {
        StateManagerScript.instance.gameState = 2;
    }















    void hoverOverFileTabEditor()
    {
        //Debug.Log("file");
        //fileImage.rectTransform.sizeDelta = new Vector2(200,240);
        //imageSave.SetActive(true);
        //imageLoad.SetActive(true);
        //imageQuit.SetActive(true);

        //save.SetActive(true);
        //load.SetActive(true);
        //quit.SetActive(true);
    }

    void stopHoverOverFileTabEditor()
    {
        //fileImage.rectTransform.sizeDelta = new Vector2(200,90);
        //imageSave.SetActive(false);
        //imageLoad.SetActive(false);
        //imageQuit.SetActive(false);
            
        //save.SetActive(false);
       // load.SetActive(false);
       // quit.SetActive(false);
    }
    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        imageFile.rectTransform.sizeDelta = new Vector2(300,1240);
        Debug.Log("Name: " + eventData.pointerCurrentRaycast.gameObject.name);
        hoverOverFileTabEditor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        stopHoverOverFileTabEditor();
    }
    */


}
