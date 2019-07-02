using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public string couleur;

    public int life;

    public GhostPower power;

	// Use this for initialization
	void Start ()
    {
        power = GetComponent<GhostPower>();
        life = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
