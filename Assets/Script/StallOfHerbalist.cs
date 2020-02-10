using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StallOfHerbalist : MonoBehaviour
{
    public GameManager gm;

    [SerializeField]
    private GameObject dice;

    private GameObject diceOne;
    private GameObject diceTwo;

    [SerializeField]
    private CubeScript cube;

    public Text infoStall;
    public Text infos;
    public Text textNbWhiteFace;

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

    public IEnumerator getToken(GameObject player)
    {
        if (!hauntedTile)
        {
            gm.choose = false;
            player.GetComponent<BluePlayer>().canLaunchDice = false;
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
            yield return new WaitForSeconds(5.0f);

            resultDiceOne = diceOne.GetComponent<CubeScript>().face;
            switch (resultDiceOne)
            {
                case "RedFace":
                    nbRedFace++;
                    Destroy(diceOne);
                    break;
                case "BlueFace":
                    nbBlueFace++;
                    Destroy(diceOne);
                    break;
                case "YellowFace":
                    nbYellowFace++;
                    Destroy(diceOne);
                    break;
                case "GreenFace":
                    nbGreenFace++;
                    Destroy(diceOne);
                    break;
                case "WhiteFace":
                    nbWhiteFace++;
                    Destroy(diceOne);
                    break;
                case "BlackFace":
                    nbBlackFace++;
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
                    Destroy(diceTwo);
                    break;
                case "BlueFace":
                    nbBlueFace++;
                    Destroy(diceTwo);
                    break;
                case "YellowFace":
                    nbYellowFace++;
                    Destroy(diceTwo);
                    break;
                case "GreenFace":
                    nbGreenFace++;
                    Destroy(diceTwo);
                    break;
                case "WhiteFace":
                    nbWhiteFace++;
                    Destroy(diceTwo);
                    break;
                case "BlackFace":
                    nbBlackFace++;
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
                textNbWhiteFace.text = "Nombre de face blanches : " + nbWhiteFace.ToString();
                textNbWhiteFace.gameObject.SetActive(true);
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
                                nbWhiteFace--;
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
                                nbWhiteFace--;
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
                                nbWhiteFace--;
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
                                nbWhiteFace--;
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
                                nbWhiteFace--;
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

            textNbWhiteFace.gameObject.SetActive(false);
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
            Debug.Log("Attribution jeton");

            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().NbBlueToken += nbBlueTokenToGive;
                player.GetComponent<BluePlayer>().NbRedToken += nbRedTokenToGive;
                player.GetComponent<BluePlayer>().NbGreenToken += nbGreenTokenToGive;
                player.GetComponent<BluePlayer>().NbYellowToken += nbYellowTokenToGive;
                player.GetComponent<BluePlayer>().NbBlackToken += nbBlackTokenToGive;
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
            }
            /*else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().Qi += 1;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().Qi += 1;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().Qi += 1;
            }*/
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
        }
    }

    public void haunted()
    {
        if (hauntedTile)
        {
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
