using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostPower : MonoBehaviour {

    //Variable pour acces au nombre de dés

    public GameManager gm;

    public GameObject bluePlayer;
    public GameObject redPlayer;
    public GameObject greenPlayer;
    public GameObject yellowPlayer;

    public PriestCircle circle;

    public string choseenToken;
    public bool choose;

    public string choseenAward;
    public bool chooseAward;

    public bool hasHauntedTile;

    public GameObject hauntingGhost;

    public Transform startPosition;
    public Transform middlePosition;
    public Transform endPosition;

    public GameObject tileToCheck;
    public GameObject firstTileCheck;
    public GameObject secondTileCheck;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    //Functions for Entry, In game and Dead
    public void LaunchBlackDice(GameObject player)
    {
        //Comme pour le lancer de dés
        if (player.name == "BluePlayer")
        {
            StartCoroutine(player.GetComponent<BluePlayer>().LaunchBlackDice());
        }
        else if (player.name == "RedPlayer")
        {
            //StartCoroutine(player.GetComponent<RedPlayer>().LaunchBlackDice());
        }
        else if (player.name == "GreenPlayer")
        {
            //StartCoroutine(player.GetComponent<GreenPlayer>().LaunchBlackDice());
        }
        else if (player.name == "YellowPlayer")
        {
            StartCoroutine(player.GetComponent<YellowPlayer>().LaunchBlackDice());
        }
    } 

    //Functions for power activate when ghost is draw
    public void CaptureOneDice() // May be an ui text to see how dice we have. And so, we must update UI
    {
        gm.nbDice--;
        Debug.Log(gm.nbDice);
    } //OK

    public void CantUseTAOToken() //Idem than previous function. See how to indicate that
    {
        gm.canUseTaoToken = false;
        Debug.Log(gm.canUseTaoToken);
    } //Okay

    public void DrawAGhost(GameObject player)
    {
        //Relancer la pioche
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().DrawAGhost();
        }
        else if (player.name == "RedPlayer")
        {
            //player.GetComponent<RedPlayer>().DrawAGhost();
        }
        else if (player.name == "GreenPlayer")
        {
            //player.GetComponent<GreenPlayer>().DrawAGhost();
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().DrawAGhost();
        }
    }

    public void CantUsePower(GameObject player)
    {
        //Bloque en fait le pouvoir du plateau ou il est posé
        //Booleen dans le script du joueur a modifier
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().canUsePower = false;
        }
        else if (player.name == "RedPlayer")
        {
            //player.GetComponent<RedPlayer>().canUsePower = false;
        }
        else if (player.name == "GreenPlayer")
        {
            //player.GetComponent<GreenPlayer>().canUsePower = false;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().canUsePower = false;
        }
    } // It seems okay, but we can't really test without include player's power. Try to check with debug

    public void BlockAllPower()
    {
        bluePlayer.GetComponent<BluePlayer>().canUsePower = false;
        /*redPlayer.GetComponent<RedPlayer>().canUsePower = false;
        greenPlayer.GetComponent<GreenPlayer>().canUsePower = false;
        yellowPlayer.GetComponent<YellowPlayer>().canUsePower = false;*/
    }

    public void HauntedTile() //Okay
    {
        hasHauntedTile = false;
        RaycastHit hitTiledirection;
        //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = false;
        gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = false;
        gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = false;
        for (int i = 0; i < 3; i++)
        {
            if (!hasHauntedTile)
            {
                if (Physics.Raycast(transform.position, Vector3.back, out hitTiledirection, 100.0f) || Physics.Raycast(transform.position, Vector3.forward, out hitTiledirection, 100.0f) ||
                   Physics.Raycast(transform.position, Vector3.right, out hitTiledirection, 100.0f) || Physics.Raycast(transform.position, Vector3.left, out hitTiledirection, 100.0f))
                {
                    tileToCheck = hitTiledirection.collider.gameObject;
                    switch (tileToCheck.name)
                    {
                        case "MaisonThe":
                            if (!tileToCheck.GetComponent<HouseOfTea>().hauntedTile)
                            {
                                tileToCheck.GetComponent<HouseOfTea>().hauntedTile = true;
                                tileToCheck.GetComponent<HouseOfTea>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "HutteSorciere":
                            if (!tileToCheck.GetComponent<HutOfWitch>().hauntedTile)
                            {
                                tileToCheck.GetComponent<HutOfWitch>().hauntedTile = true;
                                tileToCheck.GetComponent<HutOfWitch>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "EchoppeHerboriste":
                            if (!tileToCheck.GetComponent<StallOfHerbalist>().hauntedTile)
                            {
                                tileToCheck.GetComponent<StallOfHerbalist>().hauntedTile = true;
                                tileToCheck.GetComponent<StallOfHerbalist>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "AutelTaoiste":
                            if (!tileToCheck.GetComponent<TaoisteAutel>().hauntedTile)
                            {
                                tileToCheck.GetComponent<TaoisteAutel>().hauntedTile = true;
                                tileToCheck.GetComponent<TaoisteAutel>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "Cimetiere":
                            if (!tileToCheck.GetComponent<Graveyard>().hauntedTile)
                            {
                                tileToCheck.GetComponent<Graveyard>().hauntedTile = true;
                                tileToCheck.GetComponent<Graveyard>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "PavillonVentCeleste":
                            if (!tileToCheck.GetComponent<WindCelestialFlag>().hauntedTile)
                            {
                                tileToCheck.GetComponent<WindCelestialFlag>().hauntedTile = true;
                                tileToCheck.GetComponent<WindCelestialFlag>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "TourVeilleurNuit":
                            if (!tileToCheck.GetComponent<NightTower>().hauntedTile)
                            {
                                tileToCheck.GetComponent<NightTower>().hauntedTile = true;
                                tileToCheck.GetComponent<NightTower>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "CerclePierre":
                            if (!tileToCheck.GetComponent<PriestCircle>().hauntedTile)
                            {
                                tileToCheck.GetComponent<PriestCircle>().hauntedTile = true;
                                tileToCheck.GetComponent<PriestCircle>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "TempleBouddhiste":
                            if (!tileToCheck.GetComponent<BouddhisteTemple>().hauntedTile)
                            {
                                tileToCheck.GetComponent<BouddhisteTemple>().hauntedTile = true;
                                tileToCheck.GetComponent<BouddhisteTemple>().haunted();
                                hasHauntedTile = true;
                                gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            if(i == 0)
            {
                firstTileCheck = tileToCheck;
            }
            if (i == 1)
            {
                secondTileCheck = tileToCheck;
            }
            if (i == 2)
            {
                firstTileCheck.GetComponent<BoxCollider>().enabled = true;
                secondTileCheck.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public void LoseLife(GameObject player) //Okay
    {
        //Player actif perd 1 qi
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().Qi -= 1;
            player.GetComponent<BluePlayer>().update = true;
        }
        else if (player.name == "RedPlayer")
        {
            //player.GetComponent<RedPlayer>().Qi -= 1;
        }
        else if (player.name == "GreenPlayer")
        {
            //player.GetComponent<GreenPlayer>().Qi -= 1;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().Qi -= 1;
            player.GetComponent<YellowPlayer>().update = true;
        }
    }

    public void LoseOneTAOToken() // Can be at Entry or while ghost is alive
    {
        //For all player, leur faire renvoyer un jeton en reserve
    }

    public void UnactivePriestCircle()
    {
        //Enlève le jeton du cercle de prière
        //circle.GetComponent<PriestCircle>().
    }

    public void HauntedGhostAdvanced() //Okay
    {
        GameObject go = Instantiate(hauntingGhost, middlePosition); //To verify if we need to ajust. I think we must warning with start function and this (Which function is before the other)
        go.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
        go.transform.localScale = new Vector3(1.0f, 200.0f, 1.0f);
    }

    //Functions for power activate when ghost in on the field
    public void Insensible() //Okay
    {
        gameObject.GetComponent<Ghost>().canBeDestroyByDice = false;
        Debug.Log(gameObject.GetComponent<Ghost>().canBeDestroyByDice);
    }

    //Funcitons when the ghost is not dead yet 
    public void HauntedGhost() //Okay
    {
        GameObject go = Instantiate(hauntingGhost, startPosition);
        go.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
        go.transform.localScale = new Vector3(1.0f, 200.0f, 1.0f);
    }

    public void UnactiveWhiteFace() //To test 
    {
        gm.cantTransformWhiteFace = true;
        Debug.Log(gm.cantTransformWhiteFace);
    }

    public void MustBeKillWithBouddha()
    {
        gameObject.GetComponent<Ghost>().killWithBouddha = true;
    }

    //Functions for power activate when ghost dead (if dead naturally)

    public IEnumerator WinQiORYinYangToken(GameObject player) //Warning : We must active Yin Yang token. Or may be in first, indicate them on UI
    {
        gm.chooseAward = false;
        gm.panelAwardChoice.SetActive(true);
        while (!gm.chooseAward)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (gm.chooseAward)
        {
            Debug.Log("Couocu");
            gm.panelAwardChoice.SetActive(false);
            gm.chooseAward = false;
        }
        switch (gm.choseenAward)
        {
            case "Qi":
                if (player.name == "BluePlayer")
                {
                    player.GetComponent<BluePlayer>().Qi += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                /*else if (player.name == "RedPlayer")
                {
                    player.GetComponent<BluePlayer>().Qi += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }*/
                else if (player.name == "YellowPlayer")
                {
                    player.GetComponent<YellowPlayer>().Qi += 1;
                    player.GetComponent<YellowPlayer>().update = true;
                    player.GetComponent<YellowPlayer>().canLaunchDice = true;
                    player.GetComponent<YellowPlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                }
                /*else if (player.name == "GreenPlayer")
                {
                    player.GetComponent<BluePlayer>().Qi += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }*/
                break;
            case "YinYang":
                if (player.name == "BluePlayer")
                {
                    player.GetComponent<BluePlayer>().NbYinYangBlueToken += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                /*else if (player.name == "RedPlayer")
                {
                    player.GetComponent<BluePlayer>().NbYinYangRedToken += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }*/
                else if (player.name == "YellowPlayer")
                {
                    player.GetComponent<YellowPlayer>().NbYinYangYellowToken += 1;
                    player.GetComponent<YellowPlayer>().update = true;
                    player.GetComponent<YellowPlayer>().canLaunchDice = true;
                    player.GetComponent<YellowPlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                }
                /*else if (player.name == "GreenPlayer")
                {
                    player.GetComponent<BluePlayer>().NbYinYangGreenToken += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }*/
                break;
            default:
                break;
        }
    }

    public IEnumerator WinTAOToken(GameObject player)
    {
        gm.choose = false;
        gm.panelButtonChoice.SetActive(true);
        while (!gm.choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (gm.choose)
        {
            Debug.Log("Couocu");
            gm.panelButtonChoice.SetActive(false);
            gm.choose = false;
        }
        switch (gm.choseenToken)
        {
            case "Red":
                if (gm.tokenStock.nbRedToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    gm.tokenStock.nbRedToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbRedToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                    else if (player.name == "YellowPlayer")
                    {
                        player.GetComponent<YellowPlayer>().NbRedToken += 1;
                        player.GetComponent<YellowPlayer>().update = true;
                        player.GetComponent<YellowPlayer>().canLaunchDice = true;
                        player.GetComponent<YellowPlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Blue":
                if (gm.tokenStock.nbBlueToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    gm.tokenStock.nbBlueToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbBlueToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                    else if (player.name == "YellowPlayer")
                    {
                        player.GetComponent<YellowPlayer>().NbBlueToken += 1;
                        player.GetComponent<YellowPlayer>().update = true;
                        player.GetComponent<YellowPlayer>().canLaunchDice = true;
                        player.GetComponent<YellowPlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Green":
                if (gm.tokenStock.nbGreenToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    gm.tokenStock.nbGreenToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbGreenToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                    else if (player.name == "YellowPlayer")
                    {
                        player.GetComponent<YellowPlayer>().NbGreenToken += 1;
                        player.GetComponent<YellowPlayer>().update = true;
                        player.GetComponent<YellowPlayer>().canLaunchDice = true;
                        player.GetComponent<YellowPlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Yellow":
                if (gm.tokenStock.nbYellowToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    gm.tokenStock.nbYellowToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbYellowToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                    else if (player.name == "YellowPlayer")
                    {
                        player.GetComponent<YellowPlayer>().NbYellowToken += 1;
                        player.GetComponent<YellowPlayer>().update = true;
                        player.GetComponent<YellowPlayer>().canLaunchDice = true;
                        player.GetComponent<YellowPlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "black":
                if (gm.tokenStock.nbBlackToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    gm.tokenStock.nbBlackToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbBlackToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                    else if (player.name == "YellowPlayer")
                    {
                        player.GetComponent<YellowPlayer>().NbBlackToken += 1;
                        player.GetComponent<YellowPlayer>().update = true;
                        player.GetComponent<YellowPlayer>().canLaunchDice = true;
                        player.GetComponent<YellowPlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    public void WinQIANDYinYang(GameObject player) //Warning : We must active Yin Yang token. Or may be in first, indicate them on UI
    {
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().NbYinYangBlueToken += 1;
            player.GetComponent<BluePlayer>().Qi += 1;
            player.GetComponent<BluePlayer>().update = true;
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().NbYinYangYellowToken += 1;
            player.GetComponent<YellowPlayer>().Qi += 1;
            player.GetComponent<YellowPlayer>().update = true;
            player.GetComponent<YellowPlayer>().canLaunchDice = true;
            player.GetComponent<YellowPlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
        }
        /*else if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().NbRedToken += 1;
            player.GetComponent<BluePlayer>().Qi += 1;
            player.GetComponent<BluePlayer>().update = true;
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
        }
        else if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().NbRedToken += 1;
            player.GetComponent<BluePlayer>().Qi += 1;
            player.GetComponent<BluePlayer>().update = true;
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
        }*/
    }

    public IEnumerator WinTwoTAOToken(GameObject player)
    {
        gm.choose = false;
        for (int i = 0; i < 2; i++)
        {
            gm.panelButtonChoice.SetActive(true);
            while (!gm.choose)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (gm.choose)
            {
                Debug.Log("Couocu");
                gm.panelButtonChoice.SetActive(false);
                gm.choose = false;
            }
            switch (gm.choseenToken)
            {
                case "Red":
                    if (gm.tokenStock.nbRedToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        gm.tokenStock.nbRedToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbRedToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().NbRedToken += 1;
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Blue":
                    if (gm.tokenStock.nbBlueToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        gm.tokenStock.nbBlueToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbBlueToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().NbBlueToken += 1;
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Green":
                    if (gm.tokenStock.nbGreenToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        gm.tokenStock.nbGreenToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbGreenToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().NbGreenToken += 1;
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Yellow":
                    if (gm.tokenStock.nbYellowToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        gm.tokenStock.nbYellowToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbYellowToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().NbYellowToken += 1;
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "black":
                    if (gm.tokenStock.nbBlackToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        gm.tokenStock.nbBlackToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbBlackToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().NbBlackToken += 1;
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void UncaptureDice()
    {
        gm.nbDice += 1;
        if(gm.nbDice > 3)
        {
            gm.nbDice = 3;
        }
    }

    public void UnblockToken()
    {
        gm.canUseTaoToken = true;
    }

    public void UnblockPower(GameObject player)
    {
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().canUsePower = true;
            Debug.Log(player.GetComponent<BluePlayer>().canUsePower);
        }
        else if (player.name == "RedPlayer")
        {
            //player.GetComponent<RedPlayer>().canUsePower = true;
        }
        else if (player.name == "GreenPlayer")
        {
            //player.GetComponent<GreenPlayer>().canUsePower = true;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().canUsePower = true;
        }
    }
}
