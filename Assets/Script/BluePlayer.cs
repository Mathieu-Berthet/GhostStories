using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : MonoBehaviour
{

    public int qi = 0; // PV du joueur

    public int nbBlueToken;
    public int nbRedToken;
    public int nbGreenToken;
    public int nbYellowToken;
    public int nbBlackToken;

    public int nbPowerToken; // Pour une partie ou il n'y a pas 4 joueur

    public int nbYinYangBlueToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur

    public bool powerSecondSouffle;
    public bool powerSouffleCeleste;

    private bool useTilePower;
    private bool fight;

	// Use this for initialization
	void Start ()
    {
        qi = 4; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        nbBlueToken = 1;
        nbRedToken = 0;
        nbYellowToken = 0;
        nbGreenToken = 0;
        nbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        nbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        nbYinYangBlueToken = 1; //Max possible.

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SecondSouffle()
    {
        if(useTilePower)
        {
            //Relancer la fonction de la tuile en question
        }
        else if (fight)
        {
            //LaunchDice(); // Relancer les dès pour un 2e combat
        }
    }

    public void SouffleCeleste()
    {

    }

    public void LaunchDice()
    {
        //A voir plus tard
    }
}
