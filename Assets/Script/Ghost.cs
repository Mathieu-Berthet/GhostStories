﻿using System.Collections;
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
        if (hasLaunchBlackDicePower)
        {
            power.LaunchBlackDice(player);
        }
        if(hasCantUseTokenPower)
        {
            power.CantUseTAOToken();
        }
        if(hasCaptureDicePower)
        {
            power.CaptureOneDice();
        }
        if(hasDrawAGhostPower)
        {
            power.DrawAGhost(player);
        }
        if(hasHauntedTilePower)
        {
            power.HauntedTile();
        }
        if(hasCantUsePowerPower)
        {
            power.CantUsePower(player);
        }
        if(hasLoseLifePower)
        {
            power.LoseLife(player);
        }
        if(hasHauntedGhostAdvancedPower)
        {
            power.HauntedGhostAdvanced();
        }
        if(hasHauntedGhostPower)
        {
            power.HauntedGhost();
        }
        if(hasInsensiblePower)
        {
            power.Insensible();
        }
        if(hasUnactiveWhiteFacePower)
        {
            power.UnactiveWhiteFace();
        }
    }

    public void UseInGamePower(GameObject player)
    {
        if (positions == null)
        {
            if (gameObject.transform.parent.GetChild(1).childCount >= 1)
            {
                positions = gameObject.transform.parent.GetChild(1).GetComponent<HauntingGhostDeplacement>();
            }
            else
            {
                positions = gameObject.transform.parent.GetChild(2).GetComponent<HauntingGhostDeplacement>();
            }
        }
        if (hasHauntedGhostPower || hasHauntedGhostAdvancedPower)
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
