using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//updates cliff reference array
public class CliffDataUpdater1 : MonoBehaviour
{
    public static CliffDataUpdater1 instance { get; private set;}
    public int activeCount;
    public int triangleCount;

    //local temp list for cliff data
    public List<int> triangleLocalActiveList = new List<int>();
    
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
        activeCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(CliffDataScript.instance.cliffChangeState == 1)
        {
            activeCount = 0;
            for(int i = 0; i < CliffDataScript.instance.cliffDataArray.Length; i++)
            {
                if(CliffDataScript.instance.cliffDataArray[i].isEnabled == true)
                {
                    activeCount++;
                }
            }
            //add new cliff data (verts, uv, and triangles)
            AddCliffs();

            //updates existing vertex data for cliffs  
            updateExistingCliffData();
            

            
        }
        
    }

    void AddCliffs()
    {
        //add new cliff vertex and uv data
        for(int i = 0; i < CliffDataScript.instance.cliffDataArray.Length; i++)
        {
            
            if(CliffDataScript.instance.cliffDataArray[i].isEnabled == true)
            {
                if(CliffDataScript.instance.referenceActiveList.Contains(i) == false)
                {

                    for(int sideString = 0; sideString < CliffDataScript.instance.cliffDataArray[i].sideCombination.Length; sideString++)
                    {
                        if(CliffDataScript.instance.cliffDataArray[i].sideCombination[sideString] == 'B')
                        {
                            for(int k = 0; k < 4; k++)
                            {
                                CliffDataScript.instance.referenceActiveList.Add(i);
                                CliffDataScript.instance.vertexActiveList.Add(CliffDataScript.instance.cliffDataArray[i].verticesBottom[k]);
                                CliffDataScript.instance.uvActiveList.Add(CliffDataScript.instance.cliffDataArray[i].uvBottom[k]);
                            }
                            triangleCount = triangleCount + 6; 
                        }
                        if(CliffDataScript.instance.cliffDataArray[i].sideCombination[sideString] == 'L')
                        {
                            for(int k = 0; k < 4; k++)
                            {
                                CliffDataScript.instance.referenceActiveList.Add(i);
                                CliffDataScript.instance.vertexActiveList.Add(CliffDataScript.instance.cliffDataArray[i].verticesLeft[k]);
                                CliffDataScript.instance.uvActiveList.Add(CliffDataScript.instance.cliffDataArray[i].uvLeft[k]);
                            }
                            triangleCount = triangleCount + 6; 
                        }
                        if(CliffDataScript.instance.cliffDataArray[i].sideCombination[sideString] == 'T')
                        {
                            for(int k = 0; k < 4; k++)
                            {
                                CliffDataScript.instance.referenceActiveList.Add(i);
                                CliffDataScript.instance.vertexActiveList.Add(CliffDataScript.instance.cliffDataArray[i].verticesTop[k]);
                                CliffDataScript.instance.uvActiveList.Add(CliffDataScript.instance.cliffDataArray[i].uvTop[k]);
                            }
                            triangleCount = triangleCount + 6; 
                        }
                        if(CliffDataScript.instance.cliffDataArray[i].sideCombination[sideString] == 'R')
                        {
                            for(int k = 0; k < 4; k++)
                            {
                                CliffDataScript.instance.referenceActiveList.Add(i);
                                CliffDataScript.instance.vertexActiveList.Add(CliffDataScript.instance.cliffDataArray[i].verticesRight[k]);
                                CliffDataScript.instance.uvActiveList.Add(CliffDataScript.instance.cliffDataArray[i].uvRight[k]);
                            }
                            triangleCount = triangleCount + 6; 
                        }
                    }
               
                }
                  
            }
        }
        //Debug.Log(triangleCount);
        //add new cliff triangle data
        triangleLocalActiveList = new List<int>(CliffDataScript.instance.triangleReferenceActiveList);
        //triangleLocalActiveList.RemoveRange(activeCount*24, triangleLocalActiveList.Count-(activeCount*24));
        triangleLocalActiveList.RemoveRange(triangleCount, triangleLocalActiveList.Count-triangleCount);
        CliffDataScript.instance.triangleActiveList = new List<int>(triangleLocalActiveList);

        //update cliff data state
        CliffDataScript.instance.cliffChangeState = 2;
    }

    void updateExistingCliffData()
    {
        int totalCount = 0;
        int strLen = 0;
        for(int i = 0; i < activeCount; i++)
        {
            strLen = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].sideCombination.Length;
            for(int sideString = 0; sideString < strLen; sideString++)
            {

                if(CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].sideCombination[sideString] == 'B')
                {
                    for(int k = 0; k < 4; k++)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesBottom[k];
                        totalCount++;
                    }

                }
                if(CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].sideCombination[sideString] == 'L')
                {
                    for(int j = 0; j < 4; j++)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesLeft[j];
                        totalCount++;
                    }

                }
                if(CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].sideCombination[sideString] == 'T')
                {
                    for(int l = 0; l < 4; l++)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesTop[l];
                        totalCount++;
                    }

                }
                if(CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].sideCombination[sideString] == 'R')
                {
                    for(int m = 0; m < 4; m++)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesRight[m];
                        totalCount++;
                    }

                }
            }

            
        }
                    /*
            for(int j = 0; j < 4; j++)
            {
                for(int k = 0; k < 4; k++)
                {
                    if(j == 0)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesBottom[k];
                        totalCount++;
                    }
                    if(j == 1)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesLeft[k];
                        totalCount++;
                    }
                    if(j == 2)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesTop[k];
                        totalCount++;
                    }
                    if(j == 3)
                    {
                        CliffDataScript.instance.vertexActiveList[totalCount] = CliffDataScript.instance.cliffDataArray[CliffDataScript.instance.referenceActiveList[totalCount]].verticesRight[k];
                        totalCount++;
                    }
                }
            }
            */

    }
}
