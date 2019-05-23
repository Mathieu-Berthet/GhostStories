using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPower : MonoBehaviour {

    //Variable pour acces au nombre de dés

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Functions for power activate when ghost is draw
    public void CaptureOneDice()
    {
        //nb de dés -1;
    }

    public void CantUseTAOToken()
    {
        //Booleen dans le script du joueur a modifier
    }

    public void DrawAGhost()
    {
        //Relancer la pioche
    }

    public void CantUsePower()
    {
        //Booleen dans le script du joueur a modifier
    }

    public void HauntedTile()
    {
        //Modifier le booleen dans les script des tuiles
    }

    public void LoseLife(GameObject player)
    {
        //Player actif perd 1 qi
    }

    public void LoseOneTAOToken()
    {
        //For all player, leur faire renvoyer un jeton en reserve
    }

    //Functions for power activate when ghost in on the field

    public void LaunchBlackDice()
    {
        //Comme pour le lancer de dés
    }

    public void Insensible() //To rename later
    {
        // ???????
    }


    //Functions for power activate when ghost dead (if dead naturally)

    public void WinQiORYinYangToken(GameObject player)
    {
        //Player choisi ce qu'il veut
        //Lui réattribuer le qi ou le jeton
    }

    public void WinTAOToken(GameObject player)
    {
        //Voir précédente fonction ^^
    }

    public void WinQIANDYinYang(GameObject player)
    {
        //Pour quand on vainc un boss.
    }
}
