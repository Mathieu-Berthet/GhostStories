using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostPower : MonoBehaviour {

    //Variable pour acces au nombre de dés

    public GameManager gm;

    public PriestCircle circle;

    [SerializeField]
    private StockOfToken tokenStock;
    public string choseenToken;
    public bool choose;
    public GameObject panelButtonChoice;

    public string choseenAward;
    public bool chooseAward;

    public bool hasHauntedTile;

    public GameObject hauntingGhost;

    public Transform startPosition;
    public Transform middlePosition;
    public Transform endPosition;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
            //StartCoroutine(player.GetComponent<YellowPlayer>().LaunchBlackDice());
        }
    }

    //Functions for power activate when ghost is draw
    public void CaptureOneDice() // May be an ui text to see how dice we have. And so, we must update UI
    {
        gm.nbDice--;
        Debug.Log(gm.nbDice);
    }

    public void CantUseTAOToken() //Idem than previous function. See how to indicate that
    {
        gm.canUseTaoToken = false;
        Debug.Log(gm.canUseTaoToken);
    }

    public void DrawAGhost(GameObject player)
    {
        //Relancer la pioche
        if (player.name == "BluePlayer")
        {
            //player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_DRAW;
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
            //player.GetComponent<YellowPlayer>().DrawAGhost();
        }
    }

    public void CantUsePower(GameObject player)
    {
        //Bloque en fait le pouvoir du plateau ou il est posé
        //Booleen dans le script du joueur a modifier
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().canUsePower = false;
            Debug.Log(player.GetComponent<BluePlayer>().canUsePower);
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
            //player.GetComponent<YellowPlayer>().canUsePower = false;
        }
    }

    public void BlockAllPower()
    {
        //Bloquer le pouvoir de tous les joueurs
    }

    public void HauntedTile()
    {
        hasHauntedTile = false;
        RaycastHit hitTiledirection;
        GameObject tileToCheck;
        do
        {
            if(Physics.Raycast(transform.position, Vector3.back, out hitTiledirection, 6.5f) || Physics.Raycast(transform.position, Vector3.forward, out hitTiledirection, 6.5f) ||
               Physics.Raycast(transform.position, Vector3.right, out hitTiledirection, 6.5f) || Physics.Raycast(transform.position, Vector3.left, out hitTiledirection, 6.5f))
            {
                tileToCheck = hitTiledirection.collider.gameObject;
                switch(tileToCheck.name)
                {
                    case "MaisonThe":
                        if (!tileToCheck.GetComponent<HouseOfTea>().hauntedTile)
                        {
                            tileToCheck.GetComponent<HouseOfTea>().hauntedTile = true;
                            tileToCheck.GetComponent<HouseOfTea>().haunted();
                            hasHauntedTile = true;
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
        while (!hasHauntedTile);
    }

    public void LoseLife(GameObject player)
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
            //player.GetComponent<YellowPlayer>().Qi -= 1;
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

    public void HauntedGhostAdvanced()
    {
        GameObject go = Instantiate(hauntingGhost, middlePosition); //To verify if we need to ajust. I think we must warning with start function and this (Which function is before the other)
        go.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
        go.transform.localScale = new Vector3(1.0f, 200.0f, 1.0f);
    }

    //Functions for power activate when ghost in on the field
    public void Insensible() //To rename later
    {
        gameObject.GetComponent<Ghost>().cantBeDestroyByDice = true;
        Debug.Log(gameObject.GetComponent<Ghost>().cantBeDestroyByDice);
    }

    //Funcitons when the ghost is not dead yet 
    public void HauntedGhost()
    {
        GameObject go = Instantiate(hauntingGhost, startPosition);
        go.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
        go.transform.localScale = new Vector3(1.0f, 200.0f, 1.0f);
    }

    public void UnactiveWhiteFace()
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
        //panelButtonChoice.SetActive(true);
        while (!chooseAward)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (chooseAward)
        {
            Debug.Log("Couocu");
            //panelButtonChoice.SetActive(false);
            choose = false;
        }
        switch (choseenAward)
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
                }
                else if (player.name == "YellowPlayer")
                {
                    player.GetComponent<BluePlayer>().Qi += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "GreenPlayer")
                {
                    player.GetComponent<BluePlayer>().Qi += 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().useTilePower = false;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }*/
                break;
            case "Token":
                panelButtonChoice.SetActive(true);
                while (!choose)
                {
                    yield return new WaitForSeconds(1.0f);
                }
                if (choose)
                {
                    Debug.Log("Couocu");
                    panelButtonChoice.SetActive(false);
                    choose = false;
                }
                switch (choseenToken)
                {
                    case "Red":
                        if (tokenStock.nbRedToken == 0)
                        {
                            //Indiquer qu'il y en a plus en reserve
                            //Redemander de choisir une autre couleur
                        }
                        else
                        {
                            tokenStock.nbRedToken -= 1;
                            if (player.name == "BluePlayer")
                            {
                                player.GetComponent<BluePlayer>().NbRedToken += 1;
                                player.GetComponent<BluePlayer>().update = true;
                                player.GetComponent<BluePlayer>().canLaunchDice = true;
                                player.GetComponent<BluePlayer>().useTilePower = false;
                                player.GetComponent<Deplacement>().enabled = true;
                                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                            }
                        }
                        break;
                    case "Blue":
                        if (tokenStock.nbBlueToken == 0)
                        {
                            //Indiquer qu'il y en a plus en reserve
                            //Redemander de choisir une autre couleur
                        }
                        else
                        {
                            tokenStock.nbBlueToken -= 1;
                            if (player.name == "BluePlayer")
                            {
                                player.GetComponent<BluePlayer>().NbBlueToken += 1;
                                player.GetComponent<BluePlayer>().update = true;
                                player.GetComponent<BluePlayer>().canLaunchDice = true;
                                player.GetComponent<BluePlayer>().useTilePower = false;
                                player.GetComponent<Deplacement>().enabled = true;
                                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                            }
                        }
                        break;
                    case "Green":
                        if (tokenStock.nbGreenToken == 0)
                        {
                            //Indiquer qu'il y en a plus en reserve
                            //Redemander de choisir une autre couleur
                        }
                        else
                        {
                            tokenStock.nbGreenToken -= 1;
                            if (player.name == "BluePlayer")
                            {
                                player.GetComponent<BluePlayer>().NbGreenToken += 1;
                                player.GetComponent<BluePlayer>().update = true;
                                player.GetComponent<BluePlayer>().canLaunchDice = true;
                                player.GetComponent<BluePlayer>().useTilePower = false;
                                player.GetComponent<Deplacement>().enabled = true;
                                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                            }
                        }
                        break;
                    case "Yellow":
                        if (tokenStock.nbYellowToken == 0)
                        {
                            //Indiquer qu'il y en a plus en reserve
                            //Redemander de choisir une autre couleur
                        }
                        else
                        {
                            tokenStock.nbYellowToken -= 1;
                            if (player.name == "BluePlayer")
                            {
                                player.GetComponent<BluePlayer>().NbYellowToken += 1;
                                player.GetComponent<BluePlayer>().update = true;
                                player.GetComponent<BluePlayer>().canLaunchDice = true;
                                player.GetComponent<BluePlayer>().useTilePower = false;
                                player.GetComponent<Deplacement>().enabled = true;
                                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                            }
                        }
                        break;
                    case "black":
                        if (tokenStock.nbBlackToken == 0)
                        {
                            //Indiquer qu'il y en a plus en reserve
                            //Redemander de choisir une autre couleur
                        }
                        else
                        {
                            tokenStock.nbBlackToken -= 1;
                            if (player.name == "BluePlayer")
                            {
                                player.GetComponent<BluePlayer>().NbBlackToken += 1;
                                player.GetComponent<BluePlayer>().update = true;
                                player.GetComponent<BluePlayer>().canLaunchDice = true;
                                player.GetComponent<BluePlayer>().useTilePower = false;
                                player.GetComponent<Deplacement>().enabled = true;
                                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                            }
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator WinTAOToken(GameObject player)
    {
        panelButtonChoice.SetActive(true);
        while (!choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (choose)
        {
            Debug.Log("Couocu");
            panelButtonChoice.SetActive(false);
            choose = false;
        }
        switch (choseenToken)
        {
            case "Red":
                if (tokenStock.nbRedToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbRedToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbRedToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Blue":
                if (tokenStock.nbBlueToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlueToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbBlueToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Green":
                if (tokenStock.nbGreenToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbGreenToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbGreenToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Yellow":
                if (tokenStock.nbYellowToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbYellowToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbYellowToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "black":
                if (tokenStock.nbBlackToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlackToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbBlackToken += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator WinQIANDYinYang(GameObject player) //Warning : We must active Yin Yang token. Or may be in first, indicate them on UI
    {
        panelButtonChoice.SetActive(true);
        while (!choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (choose)
        {
            Debug.Log("Couocu");
            panelButtonChoice.SetActive(false);
            choose = false;
        }
        switch (choseenToken)
        {
            case "Red":
                if (tokenStock.nbRedToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbRedToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbRedToken += 1;
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Blue":
                if (tokenStock.nbBlueToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlueToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbBlueToken += 1;
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Green":
                if (tokenStock.nbGreenToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbGreenToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbGreenToken += 1;
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Yellow":
                if (tokenStock.nbYellowToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbYellowToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbYellowToken += 1;
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "black":
                if (tokenStock.nbBlackToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlackToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().NbBlackToken += 1;
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator WinTwoTAOToken(GameObject player)
    {
        for (int i = 0; i < 2; i++)
        {
            panelButtonChoice.SetActive(true);
            while (!choose)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (choose)
            {
                Debug.Log("Couocu");
                panelButtonChoice.SetActive(false);
                choose = false;
            }
            switch (choseenToken)
            {
                case "Red":
                    if (tokenStock.nbRedToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        tokenStock.nbRedToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbRedToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Blue":
                    if (tokenStock.nbBlueToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        tokenStock.nbBlueToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbBlueToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Green":
                    if (tokenStock.nbGreenToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        tokenStock.nbGreenToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbGreenToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Yellow":
                    if (tokenStock.nbYellowToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        tokenStock.nbYellowToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbYellowToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "black":
                    if (tokenStock.nbBlackToken == 0)
                    {
                        //Indiquer qu'il y en a plus en reserve
                        //Redemander de choisir une autre couleur
                    }
                    else
                    {
                        tokenStock.nbBlackToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().NbBlackToken += 1;
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }


    public void MustChooseToken(Button buttonClick)
    {
        choseenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
    }

    public void MustChooseAward(Button buttonClick)
    {
        choseenAward = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        chooseAward = true;
    }
}
