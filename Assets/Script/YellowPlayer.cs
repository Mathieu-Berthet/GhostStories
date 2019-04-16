using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : MonoBehaviour
{

    public int qi = 0; // PV du joueur

    public int nbBlueToken;
    public int nbRedToken;
    public int nbGreenToken;
    public int nbYellowToken;
    public int nbBlackToken;

    public int nbPowerToken; // Pour une partie ou il n'y a pas 4 joueur

    public int nbYinYangYellowToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur

    public bool powerPocheSansFond;
    public bool powerMantraAffaiblissement;

    public int nbMantraToken;

    // Use this for initialization
    void Start ()
    {
        qi = 4; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        nbBlueToken = 0;
        nbRedToken = 0;
        nbYellowToken = 1;
        nbGreenToken = 0;
        nbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        nbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        nbYinYangYellowToken = 1; //Max possible.

        if(powerMantraAffaiblissement)
        {
            nbMantraToken = 1;
        }
        else
        {
            nbMantraToken = 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PocheSansFond()
    {

    }

    public void MantraAffaiblissement()
    {
        //Recupérer le fantôme ciblé // Seulement si le joueur a encore son jeton mantra // Doit le jouer AVANT le combat
        nbMantraToken -= 1;
        //Si fantome mort
        nbMantraToken += 1;
    }

    public void LaunchDice()
    {

    }
}
