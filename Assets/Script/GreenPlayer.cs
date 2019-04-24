using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : MonoBehaviour
{

    public int qi = 0; // PV du joueur

    public int nbBlueToken;
    public int nbRedToken;
    public int nbGreenToken;
    public int nbYellowToken;
    public int nbBlackToken;

    public int nbPowerToken; // Pour une partie ou il n'y a pas 4 joueur

    public int nbYinYangGreenToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur

    public bool powerForceDeLaMontagne;
    public bool powerFavoriDesDieux;


    // Use this for initialization
    void Start ()
    {
        qi = 4; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        nbBlueToken = 0;
        nbRedToken = 0;
        nbYellowToken = 0;
        nbGreenToken = 1;
        nbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        nbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        nbYinYangGreenToken = 1; //Max possible.
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void LaunchDice()
    {
        //A voir plus tard
        if(powerFavoriDesDieux)
        {
            //Relancer les dés 1 fois
        }
        else if(powerForceDeLaMontagne)
        {
            //Lancer avec 1 dé supplémentaire et pas de dés noir
        }
    }
}
