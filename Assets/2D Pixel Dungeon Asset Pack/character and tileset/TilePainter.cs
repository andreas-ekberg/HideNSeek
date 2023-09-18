using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{

    public Tile openDoor1;
    public Tile openDoor2;
    public Tile closedDoor1;
    public Tile closedDoor2;

    private TilemapCollider2D myCollider;

    public Vector3Int position;

    public Transform PlayerPos;

    public Tilemap tilemap;

    bool Closed = true;

    private float tileRotation = 0f;

    void Start(){
        myCollider = tilemap.GetComponent<TilemapCollider2D>();

        tileRotation = tilemap.GetTransformMatrix(position).rotation.eulerAngles.z;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.K)){
            //Debug.Log(Math.Abs(PlayerPos.position.x));
            TryOpenDoor();
        }
    }


    private void TryOpenDoor(){

        if(Math.Abs(PlayerPos.position.x-position.x) < 1.5f  && Math.Abs(PlayerPos.position.y-position.y) < 1.5f && Closed == true){
            tilemap.SetTile(position, openDoor1);

            if(tileRotation == 270 || tileRotation == 90){
                Vector3Int myTemp = new Vector3Int(position.x, position.y+1, position.z);
                tilemap.SetTile(myTemp, openDoor2);
            }
            else if(tileRotation == 0){
                Vector3Int myTemp = new Vector3Int(position.x-1, position.y, position.z);
                tilemap.SetTile(myTemp, openDoor2);
            }


            Debug.Log("Inne1!");
            Closed = false;
            myCollider.enabled = false;
        }
        else if(Math.Abs(PlayerPos.position.x-position.x) < 2.5f  && Math.Abs(PlayerPos.position.y-position.y) < 2.5f && Closed == false){
            tilemap.SetTile(position, closedDoor1);

            if(tileRotation == 270 || tileRotation == 90){
                Vector3Int myTemp = new Vector3Int(position.x, position.y+1, position.z);
                tilemap.SetTile(myTemp, closedDoor2);
            }
            else if(tileRotation == 0){
                Vector3Int myTemp = new Vector3Int(position.x-1, position.y, position.z);
                tilemap.SetTile(myTemp, closedDoor2);
            }


            Debug.Log("Inne2!");
            Closed = true;
            myCollider.enabled = true;
        }
        else{
            Debug.Log("Inte nära!");
        }
        
        
    }

/*     [ContextMenu("Paint")]
    // Start is called before the first frame update
    void Paint()
    {
        tilemap.SetTile(position, openDoor);
    }
 */
}
