using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataObserver : MonoBehaviour
{
    //float[] yVertices;
    void Start()
    {
        //yVertices = new float[(MapDataScript.instance.tileSize)*4];
        //for(int i = 0; i < yVertices.Length; i++)
        //{
        //    yVertices[i] = MapDataScript.instance.vertices[i].y;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool checkForElevationUpdate()
    {
        return true;
    }
}
