using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StallOfHerbalist : MonoBehaviour
{

    public bool hauntedTile = false;
    public int nbDiceHerbalist = 2;

    [SerializeField]
    private GameObject dice;

    private GameObject diceOne;
    private GameObject diceTwo;
    //private GameObject diceThree;

    //TODO : Faire remplir ces variables
    public string resultDiceOne;
    public string resultDiceTwo;
    //public string resultDiceThree;

    public int nbRedFace;
    public int nbBlueFace;
    public int nbYellowFace;
    public int nbGreenFace;
    public int nbWhiteFace;
    public int nbBlackFace;

    public bool choose;
    public string choosenToken = "";
    public GameObject panelButtonChoice;

    [SerializeField]
    private CubeScript cube;
    // Use this for initialization
    void Start ()
    {
        nbRedFace = 0;
        nbBlueFace = 0;
        nbBlackFace = 0;
        nbWhiteFace = 0;
        nbGreenFace = 0;
        nbYellowFace = 0;
        choose = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public IEnumerator getToken(GameObject player)
    {
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
            if(i == 0)
            {
                diceOne = go;
            }
            else if(i == 1)
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

        yield return new WaitForSeconds(2.0f);
        while (nbWhiteFace > 0)
        {
            panelButtonChoice.SetActive(true);
            while (!choose)
            {
                yield return new WaitForSeconds(2.0f);
            }
            if(choose)
            {
                switch (choosenToken)
                {
                    case "Red":
                        nbRedFace++;
                        break;
                    case "Blue":
                        nbBlueFace++;
                        break;
                    case "Yellow":
                        nbYellowFace++;
                        break;
                    case "Green":
                        nbGreenFace++;
                        break;
                    case "Black":
                        nbBlackFace++;
                        break;
                    default:
                        break;
                }
                choose = false;
                panelButtonChoice.SetActive(false);
            }
            nbWhiteFace--;
        }

        yield return new WaitForSeconds(2.0f);
        panelButtonChoice.SetActive(false);
        //Attribution des jetons
        Debug.Log("Attribution jeton");

        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().NbBlueToken += nbBlueFace;
            player.GetComponent<BluePlayer>().NbBlackToken += nbBlackFace;
            player.GetComponent<BluePlayer>().NbRedToken += nbRedFace;
            player.GetComponent<BluePlayer>().NbGreenToken += nbGreenFace;
            player.GetComponent<BluePlayer>().NbYellowToken += nbYellowFace;
            player.GetComponent<BluePlayer>().update = true;
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = false;
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

    public void MustChooseToken(Button buttonClick)
    {
        choosenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
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
