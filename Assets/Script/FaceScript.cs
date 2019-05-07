using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour {

    CubeScript cube;

	// Use this for initialization
	void Start () {
        cube = GameObject.Find("Dice").GetComponent<CubeScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sol")
        {
            cube.face = gameObject.name;
        }
    }
}
