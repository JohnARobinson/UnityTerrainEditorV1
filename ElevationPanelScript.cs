using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElevationPanelScript : MonoBehaviour
{
    public static ElevationPanelScript instance { get; private set;}
    public int elevationToggle;
    [SerializeField] protected Toggle[] toggles;
    [SerializeField] private Toggle raiseToggle;
    [SerializeField] private Toggle lowerToggle;
    [SerializeField] private Toggle flattenToggle;
    [SerializeField] private Toggle zeroToggle;
    [SerializeField] private Toggle cliffToggle;
    [SerializeField] private TextMeshProUGUI tileIndex;
    [SerializeField] private TextMeshProUGUI xPos;
    [SerializeField] private TextMeshProUGUI yPos;
    [SerializeField] private TextMeshProUGUI zPos;

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
        Toggle toggle1 = raiseToggle.GetComponent<Toggle>();
        toggle1.onValueChanged.AddListener(delegate {
                RaiseToggleValueChanged(toggle1);
            });
        Toggle toggle2 = lowerToggle.GetComponent<Toggle>();
        toggle2.onValueChanged.AddListener(delegate {
                LowerToggleValueChanged(toggle2);
            });
        Toggle toggle3 = flattenToggle.GetComponent<Toggle>();
        toggle3.onValueChanged.AddListener(delegate {
                FlattenToggleValueChanged(toggle3);
            });
        Toggle toggle4 = zeroToggle.GetComponent<Toggle>();
        toggle4.onValueChanged.AddListener(delegate {
                ZeroToggleValueChanged(toggle4);
            });
        Toggle toggle5 = cliffToggle.GetComponent<Toggle>();
        toggle5.onValueChanged.AddListener(delegate {
                CliffToggleValueChanged(toggle5);
            });



    }

    // Update is called once per frame
    void Update()
    {

        if(EditorNavBarScript.instance.EditorNavMenuState == 0)
        {
            tileIndex.text = (selectorDataScript.instance.selectedIndex/4).ToString();
            //xPos.text = "X: " + tileSelection.selectedTilePosition.x.ToString();
            xPos.text = "X: " + MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x.ToString();
            //yPos.text = "Y: " + tileSelection.selectedTilePosition.y.ToString();
            yPos.text = "Y: " + MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].y.ToString();
            //zPos.text = "Z: " + tileSelection.selectedTilePosition.z.ToString();
            zPos.text = "Z: " + MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z.ToString();
        }
        
        
    }

    private void OnEnable() {
        elevationToggle = 0;
        raiseToggle.isOn = false;
        lowerToggle.isOn = false;
        flattenToggle.isOn = false;
        zeroToggle.isOn = false;
        cliffToggle.isOn = false;
        
    }

    void RaiseToggleValueChanged(Toggle toggle)
    {
        
        if(toggle.isOn)
        {
            elevationToggle = 1;

        }
        else
        {
            elevationToggle = 0;
        }
    }
    void LowerToggleValueChanged(Toggle toggle)
    {
        if(toggle.isOn)
        {
            elevationToggle = 2;
            
        }
        else
        {
            elevationToggle = 0;
        }
    }
    void FlattenToggleValueChanged(Toggle toggle)
    {
        if(toggle.isOn)
        {
            elevationToggle = 3;
            
        }
        else
        {
            elevationToggle = 0;
        }
        
    }
    void ZeroToggleValueChanged(Toggle toggle)
    {
        if(toggle.isOn)
        {
            elevationToggle = 4;
            
        }
        else
        {
            elevationToggle = 0;
        }
        
    }
    void CliffToggleValueChanged(Toggle toggle)
    {
        if(toggle.isOn)
        {
            elevationToggle = 5;
            
        }
        else
        {
            elevationToggle = 0;
        }
        
    }
}
