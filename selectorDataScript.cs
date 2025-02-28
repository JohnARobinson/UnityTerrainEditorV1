using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectorDataScript : MonoBehaviour
{
    public static selectorDataScript instance { get; private set;}
    public int selectedIndex;
    public Vector3[] vertices;
    public int[] triangles;

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

        Vector3[] vertices = new Vector3[16];
        int[] triangles = new int[24];
        selectedIndex = 0;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
