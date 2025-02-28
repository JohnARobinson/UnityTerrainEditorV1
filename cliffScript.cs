using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cliffScript : MonoBehaviour
{
    Material[] materialList = new Material[1];
    Mesh mesh;

    void Start()
    {
        materialList[0] = Resources.Load("Materials/Stone2_Mat",typeof(Material)) as Material;
        mesh = GetComponent<MeshFilter>().mesh;
        //gameObject.GetComponent<Renderer>().material = baseMaterial;
        gameObject.GetComponent<Renderer>().material = materialList[0];
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {

        if(CliffDataScript.instance.cliffChangeState == 2)
        {
            //update cliff mesh and return to base state
            updateMesh();
            CliffDataScript.instance.cliffChangeState = 0;
        }
    }

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = CliffDataScript.instance.vertexActiveList.ToArray();
        mesh.uv = CliffDataScript.instance.uvActiveList.ToArray();
        mesh.triangles = CliffDataScript.instance.triangleActiveList.ToArray();
       
        mesh = GetComponent<MeshFilter>().mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
    }


}
