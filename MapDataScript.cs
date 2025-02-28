using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapDataScript : MonoBehaviour
{
    public static MapDataScript instance { get; private set;}

    //map tile size and count
    public int tileSize;
    public int xCount;
    public int zCount;
    public int tileCount;

    //map mesh data
    public Vector3[] vertices;
    public Vector2[] uv;
    public int[] triangles;
    public bool elevationChange;


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

        
        tileSize = 100;
        xCount = 100;
        zCount= 100;
        tileCount = xCount * zCount;
        vertices = new Vector3[(tileCount)*4];
        uv = new Vector2[(tileCount)*4];
        triangles = new int[(tileCount)*6];
        

    }



    void Update()
    {

    }

    public IEnumerator resetData()
    {
        vertices = new Vector3[(tileCount)*4];
        uv = new Vector2[(tileCount)*4];
        triangles = new int[(tileCount)*6];
        MeshManagementScript.instance.DestroyTerrainMesh();
        MeshManagementScript.instance.reInitializeTerrainMeshes();
        yield return null;
    }

    public float[] SerializeVector3Data()
    {
        float[] SerializedResult = new float[vertices.Length*3];
        int j = 0;
        for(int i = 0; i < vertices.Length; i++)
        {
            SerializedResult[j] = vertices[i].x;
            SerializedResult[j+1] = vertices[i].y;
            SerializedResult[j+2] = vertices[i].z;
            j = j + 3;
        }
        return SerializedResult;
    }
    public float[] SerializeUVData()
    {
        float[] SerializedResult = new float[uv.Length*2];
        int j = 0;
        for(int i = 0; i < uv.Length; i++)
        {
            SerializedResult[j] = uv[i].x;
            SerializedResult[j+1] = uv[i].y;
            j = j + 3;
        }
        return SerializedResult;
    }
    public Vector3[] DeSerializeVector3Data(float[] SerializedVector3)
    {
        Vector3[] DeSerializedResult = new Vector3[vertices.Length/3];;
        return DeSerializedResult;
    }



}
