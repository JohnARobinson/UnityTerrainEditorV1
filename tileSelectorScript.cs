using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSelectorScript : MonoBehaviour
{
    Mesh mesh;
    int selectedIndex;
    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;
    void Start()
    {
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        //mesh = GetComponent<MeshFilter>().mesh;
        Material selectorMaterial = Resources.Load("Materials/selector",typeof(Material)) as Material;
        gameObject.GetComponent<Renderer>().material = selectorMaterial;
        //gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        selectedIndex = selectorDataScript.instance.selectedIndex;
    }

    // Update is called once per frame
    void Update()
    {
        checkForUpdate();
        //selectorDataScript.instance.selectedIndex
    }

    void checkForUpdate()
    {
        if(selectorDataScript.instance.selectedIndex != selectedIndex)
        {
            selectedIndex = selectorDataScript.instance.selectedIndex;
            updateLocation();
            //gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void updateLocation()
    {
        mesh = new Mesh();
        vertices = new Vector3[16];
        triangles = new int[24];

        vertices[0] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z);
        vertices[1] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize);
        vertices[2] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + 2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize);
        vertices[3] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + 2, MapDataScript.instance.vertices[selectedIndex].y + 2,MapDataScript.instance.vertices[selectedIndex].z);

        vertices[4] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + 2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z +MapDataScript.instance.tileSize);
        vertices[5] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize);
        vertices[6] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize, MapDataScript.instance.vertices[selectedIndex].y + 2 , MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize-2);
        vertices[7] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + 2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize-2);

        vertices[8] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize-2);
        vertices[9] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z);
        vertices[10] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize-2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z);
        vertices[11] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize-2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + MapDataScript.instance.tileSize-2);

        vertices[12] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize-2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z);
        vertices[13] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + 1, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z);
        vertices[14] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + 1, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + 1);
        vertices[15] = new Vector3(MapDataScript.instance.vertices[selectedIndex].x + MapDataScript.instance.tileSize-2, MapDataScript.instance.vertices[selectedIndex].y + 2, MapDataScript.instance.vertices[selectedIndex].z + 2);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 6;
        
        triangles[9] = 4;
        triangles[10] = 6;
        triangles[11] = 7;

        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 10;
        
        triangles[15] = 8;
        triangles[16] = 10;
        triangles[17] = 11;

        triangles[18] = 12;
        triangles[19] = 13;
        triangles[20] = 14;
        
        triangles[21] = 12;
        triangles[22] = 14;
        triangles[23] = 15;

        selectorDataScript.instance.vertices = vertices;
        selectorDataScript.instance.triangles = triangles;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
    
    }

}
