using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseOfTea : MonoBehaviour
{
    public GameManager gm;

    public GameObject playerSave;
    public GameObject fogHaunted;

    public Text infoHouse;
    public Text infos;
    
    public bool hauntedTile = false;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator GainTokenAndQI(GameObject player)
    {
        if (!hauntedTile)
        {
            gm.choose = false;
            gm.panelButtonChoice.SetActive(true);
            infoHouse = gm.panelButtonChoice.transform.GetChild(0).GetComponent<Text>();
            infoHouse.text = "Veuillez choisir votre jeton : ";
            playerSave = player;
            while (!gm.choose)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (gm.choose)
            {
                gm.panelButtonChoice.SetActive(false);
                gm.choose = false;
            }
            switch (gm.choseenToken)
            {
                case "Red":
                    if (gm.tokenStock.nbRedToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons rouges, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(GainTokenAndQI(player));
                        StartCoroutine(GainTokenAndQI(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbRedToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().Qi += 1;
                            player.GetComponent<BluePlayer>().NbRedToken += 1;
                            player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<BluePlayer>().DrawAGhost();
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().Qi += 1;
                            player.GetComponent<YellowPlayer>().NbRedToken += 1;
                            player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<YellowPlayer>().DrawAGhost();
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "RedPlayer")
                        {
                            player.GetComponent<RedPlayer>().Qi += 1;
                            player.GetComponent<RedPlayer>().NbRedToken += 1;
                            player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<RedPlayer>().DrawAGhost();
                            player.GetComponent<RedPlayer>().update = true;
                            player.GetComponent<RedPlayer>().canLaunchDice = true;
                            player.GetComponent<RedPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "GreenPlayer")
                        {
                            player.GetComponent<GreenPlayer>().Qi += 1;
                            player.GetComponent<GreenPlayer>().NbRedToken += 1;
                            player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<GreenPlayer>().DrawAGhost();
                            player.GetComponent<GreenPlayer>().update = true;
                            player.GetComponent<GreenPlayer>().canLaunchDice = true;
                            player.GetComponent<GreenPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Blue":
                    if (gm.tokenStock.nbBlueToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons bleus, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(GainTokenAndQI(player));
                        StartCoroutine(GainTokenAndQI(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbBlueToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().Qi += 1;
                            player.GetComponent<BluePlayer>().NbBlueToken += 1;
                            player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; //PEUT ETRE
                            player.GetComponent<BluePlayer>().DrawAGhost();
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().Qi += 1;
                            player.GetComponent<YellowPlayer>().NbBlueToken += 1;
                            player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<YellowPlayer>().DrawAGhost();
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "RedPlayer")
                        {
                            player.GetComponent<RedPlayer>().Qi += 1;
                            player.GetComponent<RedPlayer>().NbBlueToken += 1;
                            player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<RedPlayer>().DrawAGhost();
                            player.GetComponent<RedPlayer>().update = true;
                            player.GetComponent<RedPlayer>().canLaunchDice = true;
                            player.GetComponent<RedPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "GreenPlayer")
                        {
                            player.GetComponent<GreenPlayer>().Qi += 1;
                            player.GetComponent<GreenPlayer>().NbBlueToken += 1;
                            player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<GreenPlayer>().DrawAGhost();
                            player.GetComponent<GreenPlayer>().update = true;
                            player.GetComponent<GreenPlayer>().canLaunchDice = true;
                            player.GetComponent<GreenPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Green":
                    if (gm.tokenStock.nbGreenToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons verts, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(GainTokenAndQI(player));
                        StartCoroutine(GainTokenAndQI(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbGreenToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().Qi += 1;
                            player.GetComponent<BluePlayer>().NbGreenToken += 1;
                            player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<BluePlayer>().DrawAGhost();
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().Qi += 1;
                            player.GetComponent<YellowPlayer>().NbGreenToken += 1;
                            player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<YellowPlayer>().DrawAGhost();
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "RedPlayer")
                        {
                            player.GetComponent<RedPlayer>().Qi += 1;
                            player.GetComponent<RedPlayer>().NbGreenToken += 1;
                            player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<RedPlayer>().DrawAGhost();
                            player.GetComponent<RedPlayer>().update = true;
                            player.GetComponent<RedPlayer>().canLaunchDice = true;
                            player.GetComponent<RedPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "GreenPlayer")
                        {
                            player.GetComponent<GreenPlayer>().Qi += 1;
                            player.GetComponent<GreenPlayer>().NbGreenToken += 1;
                            player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<GreenPlayer>().DrawAGhost();
                            player.GetComponent<GreenPlayer>().update = true;
                            player.GetComponent<GreenPlayer>().canLaunchDice = true;
                            player.GetComponent<GreenPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Yellow":
                    if (gm.tokenStock.nbYellowToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons jaunes, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(GainTokenAndQI(player));
                        StartCoroutine(GainTokenAndQI(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbYellowToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().Qi += 1;
                            player.GetComponent<BluePlayer>().NbYellowToken += 1;
                            player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<BluePlayer>().DrawAGhost();
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().Qi += 1;
                            player.GetComponent<YellowPlayer>().NbYellowToken += 1;
                            player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<YellowPlayer>().DrawAGhost();
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "RedPlayer")
                        {
                            player.GetComponent<RedPlayer>().Qi += 1;
                            player.GetComponent<RedPlayer>().NbYellowToken += 1;
                            player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<RedPlayer>().DrawAGhost();
                            player.GetComponent<RedPlayer>().update = true;
                            player.GetComponent<RedPlayer>().canLaunchDice = true;
                            player.GetComponent<RedPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "GreenPlayer")
                        {
                            player.GetComponent<GreenPlayer>().Qi += 1;
                            player.GetComponent<GreenPlayer>().NbYellowToken += 1;
                            player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<GreenPlayer>().DrawAGhost();
                            player.GetComponent<GreenPlayer>().update = true;
                            player.GetComponent<GreenPlayer>().canLaunchDice = true;
                            player.GetComponent<GreenPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                case "Black":
                    if (gm.tokenStock.nbBlackToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons noirs, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(GainTokenAndQI(player));
                        StartCoroutine(GainTokenAndQI(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbBlackToken -= 1;
                        if (player.name == "BluePlayer")
                        {
                            player.GetComponent<BluePlayer>().Qi += 1;
                            player.GetComponent<BluePlayer>().NbBlackToken += 1;
                            player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; //PEUT ETRE
                            player.GetComponent<BluePlayer>().DrawAGhost();
                            player.GetComponent<BluePlayer>().update = true;
                            player.GetComponent<BluePlayer>().canLaunchDice = true;
                            player.GetComponent<BluePlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "YellowPlayer")
                        {
                            player.GetComponent<YellowPlayer>().Qi += 1;
                            player.GetComponent<YellowPlayer>().NbBlackToken += 1;
                            player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<YellowPlayer>().DrawAGhost();
                            player.GetComponent<YellowPlayer>().update = true;
                            player.GetComponent<YellowPlayer>().canLaunchDice = true;
                            player.GetComponent<YellowPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "RedPlayer")
                        {
                            player.GetComponent<RedPlayer>().Qi += 1;
                            player.GetComponent<RedPlayer>().NbBlackToken += 1;
                            player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<RedPlayer>().DrawAGhost();
                            player.GetComponent<RedPlayer>().update = true;
                            player.GetComponent<RedPlayer>().canLaunchDice = true;
                            player.GetComponent<RedPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                        }
                        else if (player.name == "GreenPlayer")
                        {
                            player.GetComponent<GreenPlayer>().Qi += 1;
                            player.GetComponent<GreenPlayer>().NbBlackToken += 1;
                            player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_DRAW; // PEUT ETRE
                            player.GetComponent<GreenPlayer>().DrawAGhost();
                            player.GetComponent<GreenPlayer>().update = true;
                            player.GetComponent<GreenPlayer>().canLaunchDice = true;
                            player.GetComponent<GreenPlayer>().useTilePower = false;
                            player.GetComponent<Deplacement>().enabled = true;
                            player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activez son pouvoir";
            infos.gameObject.SetActive(true);
            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().update = true;
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().update = true;
                player.GetComponent<GreenPlayer>().canLaunchDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
            }
        }
    }


    public void haunted()
    {
        if (hauntedTile)
        {
            fogHaunted.transform.GetChild(6).GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
    }

    public void Unhaunted()
    {
        if (!hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
    }
}
