using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainScript : MonoBehaviour
{
    Material[] materialList = new Material[23];
    Texture[] textureList = new Texture[6];
    Material baseMaterial;

    public Texture2D tileAtlas;
    public int tileResolution = 100;

    Shader shader;

    int[] triangleList1;
    int[] triangleList2;
    int[] triangleList3;
    int[] triangleList4;
    int[] triangleList5;
    int[] triangleList6;



    Mesh mesh;
    Vector3[] vertices;
    void Start()
    {

        //materialList[1] = Resources.Load("Materials/Grass1_Mat",typeof(Material)) as Material;
        //materialList[0] = Resources.Load("Materials/Sand1_Mat",typeof(Material)) as Material;
        //materialList[2] = Resources.Load("Materials/Stone2_Mat",typeof(Material)) as Material;

        //textureList[0] = Resources.Load("Textures/Grass1_Tex", typeof(Texture)) as Texture;
        //textureList[1] = Resources.Load("Textures/Sand1_Tex", typeof(Texture)) as Texture;
        //textureList[2] = Resources.Load("Textures/Dirt1_Tex", typeof(Texture)) as Texture;
        //textureList[3] = Resources.Load("Textures/Dirt2_Tex", typeof(Texture)) as Texture;
        //textureList[4] = Resources.Load("Textures/Stone1_Tex", typeof(Texture)) as Texture;
        //textureList[5] = Resources.Load("Textures/Stone2_Tex", typeof(Texture)) as Texture;

        //materialList[3] = Resources.Load("Materials/grassMix_Mat",typeof(Material)) as Material;
        //materialList[3] = Resources.Load("Materials/Main_Tile_Material_Test1_Mat",typeof(Material)) as Material;
        //materialList[0] = Resources.Load("Materials/Main_Tile_Material_Test1_Mat",typeof(Material)) as Material;
        //materialList[1] = Resources.Load("Materials/Main_Tile_Material_Test1_Mat",typeof(Material)) as Material;
        

        //materialList[3].SetTexture("_baseTexture",textureList[1]);
        //materialList[3].SetTexture("_mixTexture",textureList[2]);

        /*
        materialList[0].SetTexture("_baseTexture",textureList[0]);
        materialList[0].SetTexture("_topTexture",textureList[0]);
        materialList[0].SetTexture("_leftTexture",textureList[0]);
        materialList[0].SetTexture("_rightTexture",textureList[0]);
        materialList[0].SetTexture("_bottomTexture",textureList[0]);
        materialList[0].SetTexture("_toprightTexture",textureList[0]);
        materialList[0].SetTexture("_topleftTexture",textureList[0]);
        materialList[0].SetTexture("_bottomrightTexture",textureList[0]);
        materialList[0].SetTexture("_bottomleftTexture",textureList[0]);
        */
        materialList[0] = Resources.Load("Materials/TextureArrayTest",typeof(Material)) as Material;
        //materialList[1] = Resources.Load("Materials/BaseMaterial",typeof(Material)) as Material;
        materialList[0].SetFloat("_ArrayIndex", 8);
        /*
        
        //grass
        materialList[0] = Resources.Load("Materials/GrassAll",typeof(Material)) as Material;
        //sand
        materialList[1] = Resources.Load("Materials/DirtAll",typeof(Material)) as Material;
        //dirt
        materialList[2] = Resources.Load("Materials/SandAll",typeof(Material)) as Material;
        //sand grass mix
        
        //one side
        materialList[3] = Resources.Load("Materials/GrassAllSandTop",typeof(Material)) as Material;
        materialList[4] = Resources.Load("Materials/GrassAllSandLeft",typeof(Material)) as Material;
        materialList[5] = Resources.Load("Materials/GrassAllSandRight",typeof(Material)) as Material;
        materialList[6] = Resources.Load("Materials/GrassAllSandBottom",typeof(Material)) as Material;

        //corners
        materialList[7] = Resources.Load("Materials/GrassTopLeftSand",typeof(Material)) as Material;
        materialList[8] = Resources.Load("Materials/GrassTopRightSand",typeof(Material)) as Material;
        materialList[9] = Resources.Load("Materials/GrassBottomLeftSand",typeof(Material)) as Material;
        materialList[10] = Resources.Load("Materials/GrassBottomRightSand",typeof(Material)) as Material;

        //two sides angles
        materialList[11] = Resources.Load("Materials/GrassLeftTopSideSand",typeof(Material)) as Material;
        materialList[12] = Resources.Load("Materials/GrassLeftBottomSideSand",typeof(Material)) as Material;
        materialList[13] = Resources.Load("Materials/GrassRightTopSideSand",typeof(Material)) as Material;
        materialList[14] = Resources.Load("Materials/GrassRightBottomSideSand",typeof(Material)) as Material;
        materialList[15] = Resources.Load("Materials/GrassLeftRightSideSand",typeof(Material)) as Material;
        materialList[16] = Resources.Load("Materials/GrassTopBottomSideSand",typeof(Material)) as Material;

        
        //3 sides
        materialList[17] = Resources.Load("Materials/GrassLeftRightBottomSand",typeof(Material)) as Material;
        materialList[18] = Resources.Load("Materials/GrassTopLeftBottomSand",typeof(Material)) as Material;
        materialList[19] = Resources.Load("Materials/GrassTopLeftRightSand",typeof(Material)) as Material;
        materialList[20] = Resources.Load("Materials/GrassTopRightBottomSand",typeof(Material)) as Material;
        materialList[21] = Resources.Load("Materials/GrassRightTopSideSand",typeof(Material)) as Material;

        //4 sides
        materialList[22] = Resources.Load("Materials/GrassAllSand",typeof(Material)) as Material;
        materialList[22] = Resources.Load("Materials/GrassAllSand",typeof(Material)) as Material;  


        //materialList[1] = Resources.Load("Materials/Main_Tile_Material_Test1_Mat",typeof(Material)) as Material;

        mesh = GetComponent<MeshFilter>().mesh;
        gameObject.GetComponent<Renderer>().materials = materialList;

        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        

        mesh.subMeshCount = 23;

        triangleList1 = new int[]{0,1,2,0,2,3};
        mesh.SetTriangles(triangleList1,1);
        triangleList2 = new int[]{4,5,6,4,6,7,804,805,806,804,806,807};
        mesh.SetTriangles(triangleList2,2);
        triangleList3 = new int[]{8,9,10,8,10,11,808,809,810,808,810,811};
        mesh.SetTriangles(triangleList3,3);
        triangleList4 = new int[]{12,13,14,12,14,15,404,405,406,404,406,407};
        mesh.SetTriangles(triangleList4,4);
        triangleList5 = new int[]{12,13,14,12,14,15,1204,1205,1206,1204,1206,1207};
        mesh.SetTriangles(triangleList5,5);
        triangleList6 = new int[]{4,5,6,4,6,7,800,801,802,800,802,803};
        mesh.SetTriangles(triangleList6,6);

        
        */
        

        mesh = GetComponent<MeshFilter>().mesh;
        gameObject.GetComponent<Renderer>().materials = materialList;

        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        


        


        
    }




    void Update()
    {
        
        if(MapDataScript.instance.elevationChange == true)
        {
            updateMesh();
            MapDataScript.instance.elevationChange = false;
        }
    }

    void checkForElevationUpdate()
    {
        
    }

    void updateMesh()
    {
        //vertices = new Vector3[(MapDataScript.instance.tileSize)*4];
        vertices = MapDataScript.instance.vertices;
        mesh.vertices = vertices;
        mesh = GetComponent<MeshFilter>().mesh;
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        
    }

    void updateTileTerrain()
    {

    }

}
