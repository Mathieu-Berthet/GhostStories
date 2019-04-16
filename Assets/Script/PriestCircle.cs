using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestCircle : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private int typeJeton; // A voir si on fait un script général pour les jetons, afin d'avoir un type précis ici. Ou bien gameobject et on va chercher la couleur.

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reduceGhostLife()
    {

    }
}
