using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouddhisteTemple : MonoBehaviour {

    [SerializeField]
    private int numberOfBouddha = 2;
    public bool hauntedTile = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void getBouddha()
    {
        //Si joueur bleu avec pouvoir "Second souffle" : numberOfBouddha -=2

        numberOfBouddha -= 1;
        //Augementer la reserve de bouddha du joueur de 1 ou 2
    }
}
