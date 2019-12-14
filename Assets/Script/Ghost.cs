using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public string couleur;

    public int life;

    public GhostPower power;

    public HauntingGhostDeplacement positions;

    public bool killWithBouddha;
    public bool cantBeDestroyByDice;

    //Un booleen par type de pouvoir : Entrer, En jeu, Mort
    public bool entryPower;
    public bool inGamePower;
    public bool deathPower;


    //Un booleen par pouvoir
    public bool hasLaunchBlackDicePower;
    public bool hasCaptureDicePower;
    public bool hasCantUseTokenPower;
    public bool hasDrawAGhostPower;
    public bool hasCantUsePowerPower;
    public bool hasHauntedTilePower;
    public bool hasLoseLifePower;
    public bool hasLoseOneTokenPower;
    public bool hasUnactivePriestCirclePower;
    public bool hasHauntedGhostAdvancedPower;
    public bool hasInsensiblePower;
    public bool hasHauntedGhostPower;
    public bool hasUnactiveWhiteFacePower;
    public bool hasMustBeKillWithBouddhaPower;
    public bool hasWinQiOrYinYangTokenPower;
    public bool hasWinTAOTokenPower;
    public bool hasWinQiAndYinYangPower;
    public bool hasWinTwoTAOTokenPower;

	// Use this for initialization
	void Start ()
    {
        power = gameObject.GetComponent<GhostPower>();
        //life = 4;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //power = gameObject.GetComponent<GhostPower>();
    }
    //Pouvoir activé avant de faire la pioche.

    public void UseEntryPower(GameObject player)
    {
        Debug.Log("HEYY");
        Debug.Log(power);
        if (hasLaunchBlackDicePower)
        {
            Debug.Log("Je lance le dé noir");
            power.LaunchBlackDice(player);
            Debug.Log("Dé noir lancé");
        }
        if(hasCantUseTokenPower)
        {
            Debug.Log("Je bloque les jetons");
            power.CantUseTAOToken();
            Debug.Log("J'ai bloqué les jetons");
        }
        if(hasCaptureDicePower)
        {
            Debug.Log("Je capture un dé");
            power.CaptureOneDice();
            Debug.Log("J'ai capturé un dé");
        }
        if(hasDrawAGhostPower)
        {
            Debug.Log("Je pioche un autre fantome");
            power.DrawAGhost(player);
            Debug.Log("J'ai pioché un autre fantome");
        }
        if(hasHauntedTilePower)
        {
            Debug.Log("J'hante une tuile");
            power.HauntedTile();
            Debug.Log("Tuile hantée");
        }
        if(hasCantUsePowerPower)
        {
            Debug.Log("Je bloque les pouvoirs");
            power.CantUsePower(player);
            Debug.Log("Pouvoirs bloqués");
        }
        if(hasLoseLifePower)
        {
            Debug.Log("Je perd une vie");
            power.LoseLife(player);
            Debug.Log("J'ai perdu une vie");
        }
        if(hasHauntedGhostAdvancedPower)
        {
            Debug.Log("Je suis un fantome hanteur avancé");
            power.HauntedGhostAdvanced();
            Debug.Log("J'ai été mis sur la 2e case");
        }
        if(hasHauntedGhostPower)
        {
            Debug.Log("Je suis un fantome hanteur");
            power.HauntedGhost();
            Debug.Log("J'ai été mis sur la 1e case");
        }
        if(hasInsensiblePower)
        {
            Debug.Log("Je suis insensible au dé");
            power.Insensible();
            //Debug.Log("Je lance le dé noir");
        }
        if(hasUnactiveWhiteFacePower)
        {
            Debug.Log("Je désactive les faces blanches");
            power.UnactiveWhiteFace();
            //Debug.Log("Je lance le dé noir");
        }
    }

    public void UseInGamePower(GameObject player)
    {
        if(hasHauntedGhostPower || hasHauntedGhostAdvancedPower)
        {
            positions.GhostMove();
        }
        if(hasLaunchBlackDicePower)
        {
            power.LaunchBlackDice(player);
        }
    }

    public void UseDeathPower(GameObject player)
    {
        if (hasWinQiOrYinYangTokenPower)
        {
            power.WinQiORYinYangToken(player);
        }
        if (hasWinTAOTokenPower)
        {
            power.WinTAOToken(player);
        }
        if (hasWinQiAndYinYangPower)
        {
            power.WinQIANDYinYang(player);
        }
        if (hasWinTwoTAOTokenPower)
        {
            power.WinTwoTAOToken(player);
        }
        if (hasLaunchBlackDicePower)
        {
            power.LaunchBlackDice(player);
        }
    }
}
