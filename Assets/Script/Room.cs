using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    public Component[] tileTransforms;
    public Component[] wallFlags;
    public IList walls;
    public ArrayList wallPositions;
    public Vector3[] colliders;

    // Use this for initialization
    void Start () {
        walls = null;
	}
	
	// Update is called once per frame
	void Update () {
        if(walls == null)
        {
            getAllWalls();
            getWallPositions();

        }
        //

    }

    void getColliders(){
        tileTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform tile in tileTransforms)
        {
            Debug.Log(tile.position);
        }
    }

    void getAllWalls() {
        int numberOfChildren = transform.childCount;
        walls = GameObject.FindGameObjectsWithTag("wall");
    }

    void getWallPositions()
    {
        for(int i = 0; i < walls.Count - 1; i++)
        {
            GameObject wall = (GameObject)walls[i];
            Debug.Log(wall.transform.position);
            wallPositions[i] = wall.transform.position;
            //Debug.Log(wallPositions[i]);
        }
    }

    void checkIfTileIsWall()
    {
        wallFlags = GetComponentsInChildren<Wall>();
        foreach (Wall tile in wallFlags){
            Debug.Log(tile.blocksMovement);
        }
    }
}

