using UnityEngine;
using System.Collections;
using System;

public class Tile : MonoBehaviour {

    public bool isOccupied;
    public bool isBlocked;

    //The following Vector3 variables store only Z values for changing the depth of tiles. This is usually done via SetLayer() below.
    protected Vector3 floorLayer = new Vector3(0, 0, 0);
    protected Vector3 wallLayer = new Vector3(0, 0, 1);
    protected Vector3 mobLayer = new Vector3(0, 0, -1);

    //SetLayer allows us to set the layer of any tile object directly.
    protected void setLayer(string layer)
    {
        //NewLayer is used to hold the Z-LEVEL (depth) that we want to move our tile to.
        float newLayer = 0;

        //OldPosition takes the position of the tile we're changing, so that we can change it's Z-Level Safely.
        Vector3 oldPosition;

        //layer.ToUpper converts the string input we got into upper case letters, so that the input doesn't need to be case sensitive.
        layer = layer.ToUpper();

        //This switch statement takes in a string 'layer' that defines which layer the tile should be set to.
        switch (layer) {

            //WALL layer takes the z position from the wallLayer field from the Tile class (and it's subclasses). 
            //Selecting Wall layer sets the Z level to 1.
            case "WALL":
                //We set our planned new layer to the Z level of the WallLayer. This grabs the usual Z level for walls.
                newLayer = wallLayer.z;

                //Jump out of this code loop.
                break;

            //FLOOR layer takes the z position from the mobLayer field from the Tile class (and it's subclasses). 
            //Selecting Floor layer sets the Z level to 0.
            case "FLOOR":
                //We set our planned new layer to the Z level of the floorLayer. This grabs the usual Z level for floors.
                newLayer = floorLayer.z;

                //Jump out of this code loop.
                break;

            //MOB layer takes the z position from the mobLayer field from the Tile class (and it's subclasses). 
            //Selecting Mob layer sets the Z level to -1.
            case "MOB":
                //We set our planned new layer to the Z level of the mobLayer. This grabs the usual Z level for mobs.
                newLayer = mobLayer.z;

                //Jump out of this code loop.
                break;

            default:
                Debug.Log("Unknown layer specified in switch String");
                break;
        }

        //We take the old position of the tile, because we can't directly modify the position of an object easily.
        oldPosition = transform.position;

        //We set the Z level of our old position to the Z level we plan to move to.
        oldPosition.z = newLayer;

        //We set the Current Z level with our modified old position. This keeps us in the same spot, but moves us to the wall Layer.
        transform.position = oldPosition;
    }

}
