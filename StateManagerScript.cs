using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScript : MonoBehaviour
{
    public static StateManagerScript instance { get; private set;}

    //Overall Game States
    //0 Startup
    //1 Loading
    //2 Main Menu
    //3 SinglePlayerGame
    //4 MultiplayerPlayerGame
    //5 Tile Selection/Editor
    //6 Save Game
    //7 Save Editor
    public int gameState;
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
        gameState = 2;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
