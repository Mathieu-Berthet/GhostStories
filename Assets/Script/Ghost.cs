using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public string couleur;

    public int life;

    public GhostPower power;

    public HauntingGhostDeplacement positions;

    //Un booleen par type de pouvoir : Entrer, En jeu, Mort

    //Un booleen par pouvoir

	// Use this for initialization
	void Start ()
    {
        power = GetComponent<GhostPower>();
        //life = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Pouvoir activé avant de faire la pioche.
}
