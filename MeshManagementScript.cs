using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class MeshManagementScript : MonoBehaviour
{
    public static MeshManagementScript instance { get; private set;}
    
    public int tileSize;
    public int xCount;
    public int zCount;
    int tileCount;
    Mesh mesh;
    GameObject terrain_Mesh;
    GameObject tile_Selector_Mesh;
    GameObject cliff_Mesh;

    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;

    Vector3[] verticesCliff;

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



    
    // Start is called before the first frame update
    void Start()
    {
        
        tileSize = MapDataScript.instance.tileSize;
        xCount = MapDataScript.instance.xCount;
        zCount= MapDataScript.instance.zCount;
        
        terrain_Mesh = new GameObject("Terrain_Mesh", typeof(MeshFilter), typeof(MeshRenderer),typeof(MeshCollider));
        terrain_Mesh.AddComponent<terrainScript>();
        terrain_Mesh.transform.SetParent(gameObject.transform);
        CreateTerrainMesh();

        tile_Selector_Mesh = new GameObject("Terrain_Selector_Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        tile_Selector_Mesh.AddComponent<tileSelectorScript>();
        tile_Selector_Mesh.transform.SetParent(gameObject.transform);
        CreateSelectorMesh();

        cliff_Mesh = new GameObject("Cliff_Mesh", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
        cliff_Mesh.AddComponent<cliffScript>();
        cliff_Mesh.transform.SetParent(gameObject.transform);
        CreateCliffMesh();
        
    
    }


    // Update is called once per frame
    void Update()
    {
        if(CliffDataScript.instance.isInit == false)
        {
            StartCoroutine(FillCliffInitialData());
            Debug.Log("initialize cliff array");
            CliffDataScript.instance.isInit = true;
        }
    }

    private void CreateTerrainMesh()
    {
        mesh = new Mesh();
        tileCount = xCount * zCount;
        vertices = new Vector3[(tileCount)*4];
        uv = new Vector2[(tileCount)*4];
        triangles = new int[(tileCount)*6];

        int index = 0;
    
        for(int i = 0; i < xCount; i++)
        {
            for(int j = 0; j < zCount; j++)
            {
                index = i * zCount + j;

                vertices[index*4 + 0] = new Vector3(tileSize * i, 0 ,tileSize * j);
                vertices[index*4 + 1] = new Vector3(tileSize * i, 0 ,tileSize * (j+1));
                vertices[index*4 + 2] = new Vector3(tileSize * (i+1), 0 ,tileSize * (j+1));
                vertices[index*4 + 3] = new Vector3(tileSize * (i+1), 0 ,tileSize * j);

                uv[index*4 + 0] = new Vector2(0, 0);
                uv[index*4 + 1] = new Vector2(0, 1);
                uv[index*4 + 2] = new Vector2(1, 1);
                uv[index*4 + 3] = new Vector2(1, 0);

                triangles[index*6 + 0] = index *4 + 0; 
                triangles[index*6 + 1] = index *4 + 1;
                triangles[index*6 + 2] = index *4 + 2;

                triangles[index*6 + 3] = index *4 + 0;
                triangles[index*6 + 4] = index *4 + 2;
                triangles[index*6 + 5] = index *4 + 3;

                
            }
        }
        MapDataScript.instance.vertices = vertices;
        MapDataScript.instance.uv = uv;
        MapDataScript.instance.triangles = triangles;

        verticesCliff = vertices;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        terrain_Mesh.GetComponent<MeshFilter>().mesh = mesh;
        //terrain_Mesh.AddComponent<MeshCollider>();
        //terrain_Mesh.GetComponent<MeshCollider>().sharedMesh = mesh;
        

    }

    private void CreateSelectorMesh()
    {
        mesh = new Mesh();
        Vector3[] vertices = new Vector3[16];
        int[] triangles = new int[24];

        vertices[0] = new Vector3(0,1,0);
        vertices[1] = new Vector3(0,1,MapDataScript.instance.tileSize);
        vertices[2] = new Vector3(1,1,MapDataScript.instance.tileSize);
        vertices[3] = new Vector3(1,1,0);

        vertices[4] = new Vector3(1,1,MapDataScript.instance.tileSize);
        vertices[5] = new Vector3(MapDataScript.instance.tileSize,1,MapDataScript.instance.tileSize);
        vertices[6] = new Vector3(MapDataScript.instance.tileSize,1,MapDataScript.instance.tileSize-1);
        vertices[7] = new Vector3(1,1,MapDataScript.instance.tileSize-1);

        vertices[8] = new Vector3(MapDataScript.instance.tileSize,1,MapDataScript.instance.tileSize-1);
        vertices[9] = new Vector3(MapDataScript.instance.tileSize,1,0);
        vertices[10] = new Vector3(MapDataScript.instance.tileSize-1,1,0);
        vertices[11] = new Vector3(MapDataScript.instance.tileSize-1,1,MapDataScript.instance.tileSize-1);

        vertices[12] = new Vector3(MapDataScript.instance.tileSize-1,1,0);
        vertices[13] = new Vector3(1,1,0);
        vertices[14] = new Vector3(1,1,1);
        vertices[15] = new Vector3(MapDataScript.instance.tileSize-1,1,1);
        
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
        tile_Selector_Mesh.GetComponent<MeshFilter>().mesh = mesh;

    }

    private IEnumerator FillCliffInitialData(){
        int vertexCounter = 0;
        for(int i = 0; i < CliffDataScript.instance.cliffDataArray.Length; i++)
        {

            for(int j = 0; j < 4; j++)
            {
               
                //bottom side
                if(j == 0)
                {
                    for(int k = 0; k < 4; k++)
                    {
                        if(k == 0)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesBottom[k] = verticesCliff[vertexCounter];
                            CliffDataScript.instance.cliffDataArray[i].uvBottom[k] = uv[vertexCounter];
                        }
                        if(k == 1)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesBottom[k] = verticesCliff[vertexCounter];
                            CliffDataScript.instance.cliffDataArray[i].uvBottom[k] = uv[vertexCounter+1];
                        }
                        if(k == 2)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesBottom[k] = verticesCliff[vertexCounter+3];
                            CliffDataScript.instance.cliffDataArray[i].uvBottom[k] = uv[vertexCounter+2];
                        }
                        if(k == 3)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesBottom[k] = verticesCliff[vertexCounter+3];
                            CliffDataScript.instance.cliffDataArray[i].uvBottom[k] = uv[vertexCounter+3];
                        }
                    }
                    
                }
                if(j == 1)
                {
                    for(int k = 0; k < 4; k++)
                    {
                        if(k == 0)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesLeft[k] = verticesCliff[vertexCounter+1];
                            CliffDataScript.instance.cliffDataArray[i].uvLeft[k] = uv[vertexCounter];
                        }
                        if(k == 1)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesLeft[k] = verticesCliff[vertexCounter+1];
                            CliffDataScript.instance.cliffDataArray[i].uvLeft[k] = uv[vertexCounter+1];
                        }
                        if(k == 2)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesLeft[k] = verticesCliff[vertexCounter];
                            CliffDataScript.instance.cliffDataArray[i].uvLeft[k] = uv[vertexCounter+2];
                        }
                        if(k == 3)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesLeft[k] = verticesCliff[vertexCounter];
                            CliffDataScript.instance.cliffDataArray[i].uvLeft[k] = uv[vertexCounter+3];
                        }
                    }
                    
                }

                if(j == 2)
                {
                    for(int k = 0; k < 4; k++)
                    {
                        if(k == 0)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesTop[k] = verticesCliff[vertexCounter+2];
                            CliffDataScript.instance.cliffDataArray[i].uvTop[k] = uv[vertexCounter];
                        }
                        if(k == 1)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesTop[k] = verticesCliff[vertexCounter+2];
                            CliffDataScript.instance.cliffDataArray[i].uvTop[k] = uv[vertexCounter+1];
                        }
                        if(k == 2)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesTop[k] = verticesCliff[vertexCounter+1];
                            CliffDataScript.instance.cliffDataArray[i].uvTop[k] = uv[vertexCounter+2];
                        }
                        if(k == 3)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesTop[k] = verticesCliff[vertexCounter+1];
                            CliffDataScript.instance.cliffDataArray[i].uvTop[k] = uv[vertexCounter+3];
                        }
                    }
                    
                }

                if(j == 3)
                {
                    for(int k = 0; k < 4; k++)
                    {
                        if(k == 0)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesRight[k] = verticesCliff[vertexCounter+3];
                            CliffDataScript.instance.cliffDataArray[i].uvRight[k] = uv[vertexCounter];
                        }
                        if(k == 1)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesRight[k] = verticesCliff[vertexCounter+3];
                            CliffDataScript.instance.cliffDataArray[i].uvRight[k] = uv[vertexCounter+1];
                        }
                        if(k == 2)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesRight[k] = verticesCliff[vertexCounter+2];
                            CliffDataScript.instance.cliffDataArray[i].uvRight[k] = uv[vertexCounter+2];
                        }
                        if(k == 3)
                        {
                            CliffDataScript.instance.cliffDataArray[i].verticesRight[k] = verticesCliff[vertexCounter+2];
                            CliffDataScript.instance.cliffDataArray[i].uvRight[k] = uv[vertexCounter+3];
                        }
                    }
                    
                }
            }
            vertexCounter = vertexCounter + 4;

        }
            
            

        

        int triangleReferenceCounter = 0;

        for(int t = 0; t < MapDataScript.instance.tileCount*24;)
        {
            for(int c = 0; c < 6; c++)
            {
                if(c == 0)
                {
                    CliffDataScript.instance.triangleReferenceActiveList.Add(triangleReferenceCounter + 0);
                }
                if(c == 1)
                {
                    CliffDataScript.instance.triangleReferenceActiveList.Add(triangleReferenceCounter + 1);
                }
                if(c == 2)
                {
                    CliffDataScript.instance.triangleReferenceActiveList.Add(triangleReferenceCounter + 2);
                }
                if(c == 3)
                {
                    CliffDataScript.instance.triangleReferenceActiveList.Add(triangleReferenceCounter + 0);
                }
                if(c == 4)
                {
                    CliffDataScript.instance.triangleReferenceActiveList.Add(triangleReferenceCounter + 2);
                }
                if(c == 5)
                {
                    CliffDataScript.instance.triangleReferenceActiveList.Add(triangleReferenceCounter + 3);
                }
            }
            triangleReferenceCounter = triangleReferenceCounter + 4;
            t = t + 6;
        }


        yield return null;
        
    }
    private void CreateCliffMesh()
    {

        //mesh = new Mesh();



    }

    public void DestroyTerrainMesh()
    {
        Destroy(terrain_Mesh);
    }
    public void DestroyCliffMesh()
    {
        Destroy(cliff_Mesh);
    }

    public void reInitializeTerrainMeshes()
    {
        terrain_Mesh = new GameObject("Terrain_Mesh", typeof(MeshFilter), typeof(MeshRenderer),typeof(MeshCollider));
        terrain_Mesh.AddComponent<terrainScript>();
        terrain_Mesh.transform.SetParent(gameObject.transform);
        CreateTerrainMesh();
    }
    public void reInitializeCliffMeshes()
    {
        cliff_Mesh = new GameObject("Cliff_Mesh", typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider));
        cliff_Mesh.AddComponent<cliffScript>();
        cliff_Mesh.transform.SetParent(gameObject.transform);
        CreateCliffMesh();
    }


}
