using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class cameraMovement : MonoBehaviour
{
    private int prevTile;
    [SerializeField] int tile = 0;
    Vector3 tilePosition;
    public float speed = 20.0f;
    public float scrollSpeed = 40.0f;
    public float rotSpeed = 40.0f;
    float degreesPerSecond = 20;
    Vector3 pivotPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StateManagerScript.instance.gameState == 3 || StateManagerScript.instance.gameState == 4 || StateManagerScript.instance.gameState == 5)
        {
            moveCameraInGameAndEditor();
        }
    }


    void moveCameraInGameAndEditor()
    {
        Vector3 panMoveZ = this.transform.up;
            panMoveZ.y = 0f;
            Vector3 panMoveX = this.transform.right;
            panMoveX.y = 0f;
            Vector3 panMoveY = this.transform.up;
            panMoveY.x = 0f;
            panMoveY.z = 0f;
            

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(panMoveZ * Time.deltaTime * speed, Space.World); 
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-panMoveZ * Time.deltaTime * speed, Space.World); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(panMoveX * Time.deltaTime * speed, Space.World); 
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-panMoveX * Time.deltaTime * speed, Space.World); 
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0,-rotSpeed, 0) * Time.deltaTime * speed, Space.World);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            //pos.y -= scrollSpeed * Time.deltaTime;
            transform.Translate(-panMoveY * Time.deltaTime * scrollSpeed, Space.World); 
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
        {
            //pos.y += scrollSpeed * Time.deltaTime;
            transform.Translate(panMoveY * Time.deltaTime * scrollSpeed, Space.World); 
        }
        jumpCameraToTile();
    }


    //jump camera to directed tile number
    void jumpCameraToTile()
    {
        if(tile != prevTile)
        {
            if(tile < MapDataScript.instance.tileCount)
            {
                transform.position = new Vector3(MapDataScript.instance.vertices[tile*4].x,MapDataScript.instance.vertices[tile*4].y+300,MapDataScript.instance.vertices[tile*4].z);
                prevTile = tile;
            }

        }

        prevTile = tile;
    }
    void jumpCameraToObject()
    {

    }
    void jumpCameraToPoint()
    {

    }
}
