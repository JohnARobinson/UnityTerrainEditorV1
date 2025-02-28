using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//update cliff data related to sidesEnabled & sideCombination
//analyze data array to determine each cliff set and how many sides are rendered
public class CliffDataUpdater2 : MonoBehaviour
{
    public static CliffDataUpdater2 instance { get; private set;}
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(CliffDataScript.instance.cliffChangeState == 1)
        {
            for(int i = 0; i < CliffDataScript.instance.cliffDataArray.Length; i++)
            {
                if(CliffDataScript.instance.cliffDataArray[i].isEnabled == true)
                {
                    
                }

            }

        }
        
    }
}
