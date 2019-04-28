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


    public void getBouddha(GameObject player)
    {
        //Si joueur bleu avec pouvoir "Second souffle" : numberOfBouddha -=2

        numberOfBouddha -= 1;
        //Augementer la reserve de bouddha du joueur de 1 ou 2
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().nbBouddha += 1;
            //Test avec son pouvoir pour augmenter de 2 si il l'a
        }
        else if (player.name == "GreenPlayer")
        {
            player.GetComponent<GreenPlayer>().nbBouddha += 1;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().nbBouddha += 1;
        }
        else if (player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().nbBouddha += 1;
        }
    }
}
