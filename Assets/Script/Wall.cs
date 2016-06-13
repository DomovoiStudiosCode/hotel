using UnityEngine;
using System.Collections;

public class Wall : Tile {

    public bool blocksMovement = true;

	// Use this for initialization
	void Start () {
        setLayer("wall");
        isBlocked = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
