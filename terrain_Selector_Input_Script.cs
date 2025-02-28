using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class terrain_Selector_Input_Script : MonoBehaviour
{
    int prevSelectedIndex;
    int selectedIndex;
    float selectedIndexHeight;
    float x,y,z;
    
    Ray ray;
    RaycastHit hit;
    [SerializeField] protected int raiseAmount = 25;
    [SerializeField] protected int lowerAmount = 25;


    void Start()
    {
        
    }

    void Update()
    {   
        if(StateManagerScript.instance.gameState == 5)
        {
            if(EditorNavBarScript.instance.EditorNavMenuState == 0 || EditorNavBarScript.instance.EditorNavMenuState == 1)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                

                if(Input.GetMouseButtonDown(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        //Debug.Log("Clicked on the UI");
                        //tileHit = false;
                    }
                    else
                    {
                        mouseSelectionClick();
                    }

                }

                if(Input.GetMouseButton(0))
                {
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        //Debug.Log("Clicked on the UI");
                        //tileHit = false;
                    }
                    else
                    {
                        mouseSelectionHold();
                    }
                }
            }
        }
        

    }



    void mouseSelectionHold()
    {

        if(Physics.Raycast(ray, out hit, float.PositiveInfinity))
        {
            x = Mathf.Floor(hit.point.x / 100f) * 100;
            y = Mathf.Floor(hit.point.y / 100f) * 100;
            z = Mathf.Floor(hit.point.z / 100f) * 100;

                        //Debug.Log(x + " " + y + " " +z);
            selectedIndex = ((int)x / 100*MapDataScript.instance.tileSize + (int)z /100)*4;
            selectorDataScript.instance.selectedIndex = selectedIndex;
            changeElevation();
        }
        else
        {
            //Debug.Log("hitnothing");
        }
    }
    void mouseSelectionClick()
    {
        if(Physics.Raycast(ray, out hit, float.PositiveInfinity))
        {
            x = Mathf.Floor(hit.point.x / 100f) * 100;
            y = Mathf.Floor(hit.point.y / 100f) * 100;
            z = Mathf.Floor(hit.point.z / 100f) * 100;

            selectedIndex = ((int)x / 100*MapDataScript.instance.tileSize + (int)z /100)*4;
            selectorDataScript.instance.selectedIndex = selectedIndex;
        }
    
        if(ElevationPanelScript.instance.elevationToggle == 1 || ElevationPanelScript.instance.elevationToggle == 5)  
        {
            //find lowest
            selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].y;
            if(selectedIndexHeight < MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y;
            }
            if(selectedIndexHeight < MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y;
            }
            if(selectedIndexHeight < MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y;
            }
            selectedIndexHeight = selectedIndexHeight + raiseAmount;
        }

        if(ElevationPanelScript.instance.elevationToggle == 2)
        {
            //find highest
            selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].y;
            if(selectedIndexHeight > MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y;
            }
            if(selectedIndexHeight > MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y;
            }
            if(selectedIndexHeight > MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y;
            }
            selectedIndexHeight = selectedIndexHeight - lowerAmount;
        }
        if(ElevationPanelScript.instance.elevationToggle == 3)
        {
            //find highest
            selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].y;
            if(selectedIndexHeight > MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y;
            }
            if(selectedIndexHeight > MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y;
            }
            if(selectedIndexHeight > MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y)
            {
                selectedIndexHeight = MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y;
            }
        }
        if(ElevationPanelScript.instance.elevationToggle == 4)
        {
            selectedIndexHeight = 0;
        }
       
    
    }

    private void changeElevation()
    {
        //Debug.Log(ElevationPanelScript.instance.elevationToggle);
        int maxMapSize = MapDataScript.instance.tileCount-MapDataScript.instance.xCount;
        if(ElevationPanelScript.instance.elevationToggle > 0 && ElevationPanelScript.instance.elevationToggle < 5)
        {
            MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].y = selectedIndexHeight;
            MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y = selectedIndexHeight;
            MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y = selectedIndexHeight;
            MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y = selectedIndexHeight;
            //skip right & top tile edits
            if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x > 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z > 0)
            {
                if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x < maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z < maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x != maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z != maxMapSize)
                {
                    //tile above
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+7].y = selectedIndexHeight;
                    //tile below
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-3].y = selectedIndexHeight;
                    //tile right
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+1].y = selectedIndexHeight;
                    //tile right +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4-3].y = selectedIndexHeight;
                    //tile right -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+4].y = selectedIndexHeight;
                    //tile left
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+3].y = selectedIndexHeight;
                    //tile left +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4-2].y = selectedIndexHeight;
                    //tile left -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+7].y = selectedIndexHeight;
                }
                //skip right
                if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x == maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z < maxMapSize)
                {
                    //tile above
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+7].y = selectedIndexHeight;
                    //tile below
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-3].y = selectedIndexHeight;
                    //tile left
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+3].y = selectedIndexHeight;
                    //tile left +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4-2].y = selectedIndexHeight;
                    //tile left -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+7].y = selectedIndexHeight;
                }
                //skip top
                if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x < maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z == maxMapSize)
                {
                    //tile below
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-3].y = selectedIndexHeight;
                    //tile right
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+1].y = selectedIndexHeight;
                    //tile right +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4-3].y = selectedIndexHeight;
                    //tile left
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+3].y = selectedIndexHeight;
                    //tile left +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4-2].y = selectedIndexHeight;
                }
                //skip right & top side tile edits
                if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x == maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z == maxMapSize)
                {
                    //tile below
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-3].y = selectedIndexHeight;
                    //tile left
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+3].y = selectedIndexHeight;
                    //tile left +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4-2].y = selectedIndexHeight;
                }
            }
            //skip left tile edits
            if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x == 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z > 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z != maxMapSize)
            {
                    //tile above
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+7].y = selectedIndexHeight;
                    //tile below
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-3].y = selectedIndexHeight;
                    //tile right
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+1].y = selectedIndexHeight;
                    //tile right +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4-3].y = selectedIndexHeight;
                    //tile right -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+4].y = selectedIndexHeight;
            }
            //skip bottom tile edits
            if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x > 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z == 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x != maxMapSize)
            {
                    //tile above
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+7].y = selectedIndexHeight;
                    //tile right
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+1].y = selectedIndexHeight;
                    //tile left -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+7].y = selectedIndexHeight;
                    //tile left
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+3].y = selectedIndexHeight;
                    //tile right -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+4].y = selectedIndexHeight;
            }
            //skip 0,0
            if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x == 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z == 0)
            {
                    //tile above
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+7].y = selectedIndexHeight;
                    //tile right
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+1].y = selectedIndexHeight;
                    //tile right -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+4].y = selectedIndexHeight;
            }
            //skip left and max x
            if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x == maxMapSize && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z == 0)
            {
                    //tile above
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+7].y = selectedIndexHeight;
                    //tile left
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+3].y = selectedIndexHeight;
                    //tile left -1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-MapDataScript.instance.xCount*4+7].y = selectedIndexHeight;

            }
            //skip right and max z
            if(MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].x == 0 && MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].z == maxMapSize)
            {
                    //tile below
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-2].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex-3].y = selectedIndexHeight;
                    //tile right
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4].y = selectedIndexHeight;
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4+1].y = selectedIndexHeight;
                    //tile right +1
                    MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+MapDataScript.instance.xCount*4-3].y = selectedIndexHeight;
            }
            
            MapDataScript.instance.elevationChange = true;
        }
    
        //cliffs
        if(ElevationPanelScript.instance.elevationToggle == 5)
        {
            if(CliffDataScript.instance.cliffChangeState == 0)
            {
                MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex].y = selectedIndexHeight;
                MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+1].y = selectedIndexHeight;
                MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+2].y = selectedIndexHeight;
                MapDataScript.instance.vertices[selectorDataScript.instance.selectedIndex+3].y = selectedIndexHeight;
                MapDataScript.instance.elevationChange = true;

                
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesBottom[1].y = selectedIndexHeight;
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesBottom[2].y = selectedIndexHeight;

                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesLeft[1].y = selectedIndexHeight;
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesLeft[2].y = selectedIndexHeight;

                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesTop[1].y = selectedIndexHeight;
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesTop[2].y = selectedIndexHeight;

                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesRight[1].y = selectedIndexHeight;
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].verticesRight[2].y = selectedIndexHeight;


                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].isEnabled = true;
                //*
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].sidesEnabled = 3;
                //*
                CliffDataScript.instance.cliffDataArray[selectorDataScript.instance.selectedIndex/4].sideCombination = "BLR";
                CliffDataScript.instance.cliffChangeState = 1;

            }
            

        }
        

    }

}
