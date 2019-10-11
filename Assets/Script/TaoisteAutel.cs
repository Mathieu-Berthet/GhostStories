using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaoisteAutel : MonoBehaviour {

    public bool hauntedTile = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnhauntTile()
    {

    }

    public void haunted()
    {
        if (hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
    }
}
