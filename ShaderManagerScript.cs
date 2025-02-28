using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderManagerScript : MonoBehaviour
{
    Material[] materialList = new Material[4];
    Texture[] textureList = new Texture[6];
    Shader shader;

    void Start()
    {
        /*
        materialList[0] = Resources.Load("Materials/Grass1_Mat",typeof(Material)) as Material;
        materialList[1] = Resources.Load("Materials/Sand1_Mat",typeof(Material)) as Material;
        materialList[2] = Resources.Load("Materials/Stone2_Mat",typeof(Material)) as Material;
        materialList[3] = Resources.Load("Materials/grassMix_Mat",typeof(Material)) as Material;

        materialList[3].SetTexture("_baseTexture",textureList[0]);
        materialList[3].SetTexture("_mixTexture",textureList[1]);

        shader = Shader.Find("Shader Graphs/MixMiddle_LR");
        materialList[2].shader = shader;

        materialList[2].SetTexture("_baseTexture",textureList[2]);
        materialList[2].SetTexture("_mixTexture",textureList[3]);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
