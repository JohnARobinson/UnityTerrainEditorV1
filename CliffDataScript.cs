using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffDataScript : MonoBehaviour
{
    public static CliffDataScript instance { get; private set;}
    public bool isInit = false;

    public struct cliffData{
        public bool isEnabled;
        public int sidesEnabled;
        public string sideCombination;
        //public Vector3[] vertices;
        public Vector3[] verticesBottom;
        public Vector3[] verticesLeft;
        public Vector3[] verticesTop;
        public Vector3[] verticesRight;
        public Vector2[] uvBottom;
        public Vector2[] uvLeft;
        public Vector2[] uvTop;
        public Vector2[] uvRight;
    }

    public cliffData[] cliffDataArray;
    public List<Vector3> vertexActiveList = new List<Vector3>();
    public List<Vector2> uvActiveList = new List<Vector2>();
    public List<int> triangleActiveList = new List<int>();
    public List<int> triangleReferenceActiveList = new List<int>();
    public List<int> referenceActiveList = new List<int>();

    
    //cliff mesh state
    //0 - 2
    //0 take input from terrain_Selector_Input_Script
    //1 update lists in CliffDataUpdater1 singleton
    //2 update Mesh in cliffScript object
    public int cliffChangeState;


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
        cliffChangeState = 0;
        cliffDataArray = new cliffData[MapDataScript.instance.tileCount];
        for(int i = 0; i < cliffDataArray.Length; i++)
        {
            cliffDataArray[i].isEnabled = false;
            cliffDataArray[i].sidesEnabled = 0;
            cliffDataArray[i].sideCombination = "";
            cliffDataArray[i].verticesBottom = new Vector3[4];
            cliffDataArray[i].verticesLeft = new Vector3[4];
            cliffDataArray[i].verticesTop = new Vector3[4];
            cliffDataArray[i].verticesRight = new Vector3[4];
            cliffDataArray[i].uvBottom = new Vector2[4];
            cliffDataArray[i].uvLeft = new Vector2[4];
            cliffDataArray[i].uvTop = new Vector2[4];
            cliffDataArray[i].uvRight = new Vector2[4]; 
        } 
        
    }


    // Update is called once per frame
    void Update()
    {

        
    }

    public IEnumerator resetData()
    {
        vertexActiveList = new List<Vector3>();
        uvActiveList = new List<Vector2>();
        triangleActiveList = new List<int>();
        triangleReferenceActiveList = new List<int>();
        referenceActiveList = new List<int>();

        isInit = false;
        cliffChangeState = 0;
        cliffDataArray = new cliffData[MapDataScript.instance.tileCount];
        for(int i = 0; i < cliffDataArray.Length; i++)
        {
            cliffDataArray[i].isEnabled = false;
            cliffDataArray[i].sidesEnabled = 0;
            cliffDataArray[i].sideCombination = "";
            cliffDataArray[i].verticesBottom = new Vector3[4];
            cliffDataArray[i].verticesLeft = new Vector3[4];
            cliffDataArray[i].verticesTop = new Vector3[4];
            cliffDataArray[i].verticesRight = new Vector3[4];
            cliffDataArray[i].uvBottom = new Vector2[4];
            cliffDataArray[i].uvLeft = new Vector2[4];
            cliffDataArray[i].uvTop = new Vector2[4];
            cliffDataArray[i].uvRight = new Vector2[4]; 
        }

        CliffDataUpdater1.instance.activeCount = 0;
        CliffDataUpdater1.instance.triangleCount = 0;
        CliffDataUpdater1.instance.triangleLocalActiveList = new List<int>();


        MeshManagementScript.instance.DestroyCliffMesh();
        MeshManagementScript.instance.reInitializeCliffMeshes();
        yield return null;
    }



}
