﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StallOfHerbalist : MonoBehaviour
{
    public GameManager gm;
    public GameObject fogHaunted;

    [SerializeField]
    private GameObject dice;

    private GameObject diceOne;
    private GameObject diceTwo;

    [SerializeField]
    private CubeScript cube;

    public Text infoStall;
    public Text infos;

    public bool hauntedTile = false;    

    public string resultDiceOne;
    public string resultDiceTwo;

    public int nbDiceHerbalist = 2;
    public int nbRedFace;
    public int nbBlueFace;
    public int nbYellowFace;
    public int nbGreenFace;
    public int nbWhiteFace;
    public int nbBlackFace;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //tokenStock = GameObject.Find("TokenStock").GetComponent<StockOfToken>();
        nbRedFace = 0;
        nbBlueFace = 0;
        nbBlackFace = 0;
        nbWhiteFace = 0;
        nbGreenFace = 0;
        nbYellowFace = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

	//Fait lancer 2 dés au joueur pour lui permettre de récupérer des jetons, ceux correspondant à la couleur du dé
    public IEnumerator getToken(GameObject player)
    {
        if (!hauntedTile)
        {
            gm.choose = false;
            //player.GetComponent<BluePlayer>().canLaunchDice = false;
            nbRedFace = 0;
            nbBlueFace = 0;
            nbBlackFace = 0;
            nbWhiteFace = 0;
            nbGreenFace = 0;
            nbYellowFace = 0;

            for (int i = 0; i < nbDiceHerbalist; i++)
            {
                GameObject go = Instantiate(dice, new Vector3(i, 2, 0), Quaternion.identity);
                go.AddComponent<CubeScript>();
                cube = go.GetComponent<CubeScript>();
                if (i == 0)
                {
                    diceOne = go;
                }
                else if (i == 1)
                {
                    diceTwo = go;
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    cube.rb.AddForce(hit.point * cube.force);
                }
            }
            gm.ActiveDiceFace();
            yield return new WaitForSeconds(5.0f);

            resultDiceOne = diceOne.GetComponent<CubeScript>().face;
            switch (resultDiceOne)
            {
                case "RedFace":
                    nbRedFace++;
                    gm.textNbRedFace.text = "Face Rouge : " + nbRedFace;
                    Destroy(diceOne);
                    break;
                case "BlueFace":
                    nbBlueFace++;
                    gm.textNbBlueFace.text = "Face Bleue : " + nbBlueFace;
                    Destroy(diceOne);
                    break;
                case "YellowFace":
                    nbYellowFace++;
                    gm.textNbYellowFace.text = "Face Jaune : " + nbYellowFace;
                    Destroy(diceOne);
                    break;
                case "GreenFace":
                    nbGreenFace++;
                    gm.textNbGreenFace.text = "Face Verte : " + nbGreenFace;
                    Destroy(diceOne);
                    break;
                case "WhiteFace":
                    nbWhiteFace++;
                    gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                    Destroy(diceOne);
                    break;
                case "BlackFace":
                    nbBlackFace++;
                    gm.textNbBlackFace.text = "Face Noire : " + nbBlackFace;
                    Destroy(diceOne);
                    break;
                default:
                    break;
            }

            resultDiceTwo = diceTwo.GetComponent<CubeScript>().face;
            switch (resultDiceTwo)
            {
                case "RedFace":
                    nbRedFace++;
                    gm.textNbRedFace.text = "Face Rouge : " + nbRedFace;
                    Destroy(diceTwo);
                    break;
                case "BlueFace":
                    nbBlueFace++;
                    gm.textNbBlueFace.text = "Face Bleue : " + nbBlueFace;
                    Destroy(diceTwo);
                    break;
                case "YellowFace":
                    nbYellowFace++;
                    gm.textNbYellowFace.text = "Face Jaune : " + nbYellowFace;
                    Destroy(diceTwo);
                    break;
                case "GreenFace":
                    nbGreenFace++;
                    gm.textNbGreenFace.text = "Face Verte : " + nbGreenFace;
                    Destroy(diceTwo);
                    break;
                case "WhiteFace":
                    nbWhiteFace++;
                    gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                    Destroy(diceTwo);
                    break;
                case "BlackFace":
                    nbBlackFace++;
                    gm.textNbBlackFace.text = "Face Noire : " + nbBlackFace;
                    Destroy(diceTwo);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1.0f);
            infoStall = gm.panelButtonChoice.transform.GetChild(0).GetComponent<Text>();
            infoStall.text = "Veuillez choisir la couleur de vos faces blanches : ";
            while (nbWhiteFace > 0)
            {
                gm.textNbWhiteFace.text = "Face blanches : " + nbWhiteFace.ToString();
                gm.textNbWhiteFace.gameObject.SetActive(true);
                gm.panelButtonChoice.SetActive(true);
                while (!gm.choose)
                {
                    yield return new WaitForSeconds(1.0f);
                }
                if (gm.choose)
                {
                    switch (gm.choseenToken)
                    {
                        case "Red":
                            if (gm.tokenStock.nbRedToken == 0)
                            {
                                infos.text = "Il n'y a plus de jetons rouges, veuillez choisir une autre couleur";
                                infos.gameObject.SetActive(true);
                            }
                            else
                            {
                                nbRedFace++;
                                gm.textNbRedFace.text = "Face Rouge : " + nbRedFace;
                                nbWhiteFace--;
                                gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                            }
                            break;
                        case "Blue":
                            if (gm.tokenStock.nbBlueToken == 0)
                            {
                                infos.text = "Il n'y a plus de jetons bleus, veuillez choisir une autre couleur";
                                infos.gameObject.SetActive(true);
                            }
                            else
                            {
                                nbBlueFace++;
                                gm.textNbBlueFace.text = "Face Bleue : " + nbBlueFace;
                                nbWhiteFace--;
                                gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                            }
                            break;
                        case "Yellow":
                            if (gm.tokenStock.nbYellowToken == 0)
                            {
                                infos.text = "Il n'y a plus de jetons jaunes, veuillez choisir une autre couleur";
                                infos.gameObject.SetActive(true);
                            }
                            else
                            {
                                nbYellowFace++;
                                gm.textNbYellowFace.text = "Face Jaune : " + nbYellowFace;
                                nbWhiteFace--;
                                gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                            }
                            break;
                        case "Green":
                            if (gm.tokenStock.nbGreenToken == 0)
                            {
                                infos.text = "Il n'y a plus de jetons verts, veuillez choisir une autre couleur";
                                infos.gameObject.SetActive(true);
                            }
                            else
                            {
                                nbGreenFace++;
                                gm.textNbGreenFace.text = "Face Verte : " + nbGreenFace;
                                nbWhiteFace--;
                                gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                            }
                            break;
                        case "Black":
                            if (gm.tokenStock.nbBlackToken == 0)
                            {
                                infos.text = "Il n'y a plus de jetons noirs, veuillez choisir une autre couleur";
                                infos.gameObject.SetActive(true);
                            }
                            else
                            {
                                nbBlackFace++;
                                gm.textNbBlackFace.text = "Face Noire : " + nbBlackFace;
                                nbWhiteFace--;
                                gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
                            }
                            break;
                        default:
                            break;
                    }
                    gm.choose = false;
                    gm.panelButtonChoice.SetActive(false);
                }
                yield return new WaitForSeconds(1.0f);
            }

            gm.panelButtonChoice.SetActive(false);
            //Attribution des jetons
            int nbBlueTokenToGive= 0;
            if (gm.tokenStock.nbBlueToken == 0)
            {
                nbBlueTokenToGive = 0;
            }
            else if (gm.tokenStock.nbBlueToken >= nbBlueFace)
            {
                nbBlueTokenToGive = nbBlueFace;
                gm.tokenStock.nbBlueToken -= nbBlueFace;
            }
            else if (gm.tokenStock.nbBlueToken < nbBlueFace)
            {
                nbBlueTokenToGive = nbBlueFace - gm.tokenStock.nbBlueToken;
                gm.tokenStock.nbBlueToken -= nbBlueFace - gm.tokenStock.nbBlueToken;
            }

            int nbRedTokenToGive = 0;
            if (gm.tokenStock.nbRedToken == 0)
            {
                nbRedTokenToGive = 0;
            }
            else if (gm.tokenStock.nbRedToken >= nbRedFace)
            {
                nbRedTokenToGive = nbRedFace;
                gm.tokenStock.nbRedToken -= nbRedFace;
            }
            else if (gm.tokenStock.nbRedToken < nbRedFace)
            {
                nbRedTokenToGive = nbRedFace - gm.tokenStock.nbRedToken;
                gm.tokenStock.nbRedToken -= nbRedFace - gm.tokenStock.nbRedToken;
            }

            int nbGreenTokenToGive = 0;
            if (gm.tokenStock.nbGreenToken == 0)
            {
                nbGreenTokenToGive = 0;
            }
            else if (gm.tokenStock.nbGreenToken >= nbGreenFace)
            {
                nbGreenTokenToGive = nbGreenFace;
                gm.tokenStock.nbGreenToken -= nbGreenFace;
            }
            else if (gm.tokenStock.nbGreenToken < nbGreenFace)
            {
                nbGreenTokenToGive = nbGreenFace - gm.tokenStock.nbGreenToken;
                gm.tokenStock.nbGreenToken -= nbGreenFace - gm.tokenStock.nbGreenToken;
            }

            int nbYellowTokenToGive = 0;
            if (gm.tokenStock.nbYellowToken == 0)
            {
                nbYellowTokenToGive = 0;
            }
            else if (gm.tokenStock.nbYellowToken >= nbYellowFace)
            {
                nbYellowTokenToGive = nbYellowFace;
                gm.tokenStock.nbYellowToken -= nbYellowFace;
            }
            else if (gm.tokenStock.nbYellowToken < nbYellowFace)
            {
                nbYellowTokenToGive = nbYellowFace - gm.tokenStock.nbYellowToken;
                gm.tokenStock.nbYellowToken -= nbYellowFace - gm.tokenStock.nbYellowToken;
            }

            int nbBlackTokenToGive = 0;
            if (gm.tokenStock.nbBlackToken == 0)
            {
                nbBlackTokenToGive = 0;
            }
            else if (gm.tokenStock.nbBlackToken >= nbBlackFace)
            {
                nbBlackTokenToGive = nbBlackFace;
                gm.tokenStock.nbBlackToken -= nbBlackFace;
            }
            else if (gm.tokenStock.nbBlackToken < nbBlackFace)
            {
                nbBlackTokenToGive = nbBlackFace - gm.tokenStock.nbBlackToken;
                gm.tokenStock.nbBlackToken -= nbBlackFace - gm.tokenStock.nbBlackToken;
            }

            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().NbBlueToken += nbBlueTokenToGive;
                player.GetComponent<BluePlayer>().NbRedToken += nbRedTokenToGive;
                player.GetComponent<BluePlayer>().NbGreenToken += nbGreenTokenToGive;
                player.GetComponent<BluePlayer>().NbYellowToken += nbYellowTokenToGive;
                player.GetComponent<BluePlayer>().NbBlackToken += nbBlackTokenToGive;
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().NbBlueToken += nbBlueTokenToGive;
                player.GetComponent<YellowPlayer>().NbRedToken += nbRedTokenToGive;
                player.GetComponent<YellowPlayer>().NbGreenToken += nbGreenTokenToGive;
                player.GetComponent<YellowPlayer>().NbYellowToken += nbYellowTokenToGive;
                player.GetComponent<YellowPlayer>().NbBlackToken += nbBlackTokenToGive;
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().NbBlueToken += nbBlueTokenToGive;
                player.GetComponent<GreenPlayer>().NbRedToken += nbRedTokenToGive;
                player.GetComponent<GreenPlayer>().NbGreenToken += nbGreenTokenToGive;
                player.GetComponent<GreenPlayer>().NbYellowToken += nbYellowTokenToGive;
                player.GetComponent<GreenPlayer>().NbBlackToken += nbBlackTokenToGive;
                player.GetComponent<GreenPlayer>().update = true;
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().NbBlueToken += nbBlueTokenToGive;
                player.GetComponent<RedPlayer>().NbRedToken += nbRedTokenToGive;
                player.GetComponent<RedPlayer>().NbGreenToken += nbGreenTokenToGive;
                player.GetComponent<RedPlayer>().NbYellowToken += nbYellowTokenToGive;
                player.GetComponent<RedPlayer>().NbBlackToken += nbBlackTokenToGive;
                player.GetComponent<RedPlayer>().update = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
            }
            gm.cantPause = false;
            nbRedFace = 0;
            nbBlackFace = 0;
            nbBlueFace = 0;
            nbYellowFace = 0;
            nbGreenFace = 0;
            gm.textNbRedFace.text = "Face Rouge : " + nbRedFace;
            gm.textNbBlueFace.text = "Face Bleue : " + nbBlueFace;
            gm.textNbGreenFace.text = "Face Verte : " + nbGreenFace;
            gm.textNbYellowFace.text = "Face Jaune : " + nbYellowFace;
            gm.textNbBlackFace.text = "Face Noire : " + nbBlackFace;
            gm.textNbWhiteFace.text = "Face Blanche : " + nbWhiteFace;
            gm.UnactiveDiceFace();
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activer son pouvoir";
            if (player.name == "BluePlayer")
            {
                Debug.Log("BLEU");
                Debug.Log(infos.gameObject.activeSelf);
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
                Debug.Log(infos.gameObject.activeSelf);
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;
            }
            gm.cantPause = false;
        }
    }

    public void haunted()
    {
        if (hauntedTile)
        {
            fogHaunted.transform.GetChild(6).GetComponent<ParticleSystem>().Play();
            StartCoroutine(gm.audio.PlayHauntingFX(gm.audio.GetComponent<AudioManager>().hauntingFX, gm.audio.GetComponent<AudioManager>().horrorScreamFX, 3.0f));
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
