using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StallOfHerbalist : MonoBehaviour
{

    public bool hauntedTile = false;

    [SerializeField]
    private GameObject dice;

    private GameObject diceOne;
    private GameObject diceTwo;
    private GameObject diceThree;

    //TODO : Faire remplir ces variables
    public string resultDiceOne;
    public string resultDiceTwo;
    public string resultDiceThree;

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
        //resultDiceOne = " ";
        /*resultDiceTwo = " ";
        resultDiceThree = " ";*/
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
        /*if (diceOne != null && diceOne.GetComponent<CubeScript>().rb.velocity.magnitude == 0)
        {
            resultDiceOne = diceOne.GetComponent<CubeScript>().face;
            switch(resultDiceOne)
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
        }*/
        /*if (diceTwo != null && diceTwo.GetComponent<CubeScript>().rb.velocity.magnitude == 0)
        {
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
        }
        if (diceThree != null && diceThree.GetComponent<CubeScript>().rb.velocity.magnitude == 0)
        {
            resultDiceThree = diceThree.GetComponent<CubeScript>().face;
            switch (resultDiceThree)
            {
                case "RedFace":
                    nbRedFace++;
                    Destroy(diceThree);
                    break;
                case "BlueFace":
                    nbBlueFace++;
                    Destroy(diceThree);
                    break;
                case "YellowFace":
                    nbYellowFace++;
                    Destroy(diceThree);
                    break;
                case "GreenFace":
                    nbGreenFace++;
                    Destroy(diceThree);
                    break;
                case "WhiteFace":
                    nbWhiteFace++;
                    Destroy(diceThree);
                    break;
                case "BlackFace":
                    nbBlackFace++;
                    Destroy(diceThree);
                    break;
                default:
                    break;
            }
        }*/
    }

    public IEnumerator getToken(GameObject player)
    {
        //Si on passe player en parametre, on rempli directement le stock de jeton du joueur par la suite
        // A gérer le cas si on a une face blanche qui sort
        // A Transformer en coroutines. (Plus simple ? )
        nbRedFace = 0;
        nbBlueFace = 0;
        nbBlackFace = 0;
        nbWhiteFace = 0;
        nbGreenFace = 0;
        nbYellowFace = 0;
        //Remplacer 3 ici par le nombre de dés. (Qui sera dans un autre script)
        for (int i = 0; i < 3; i++)
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
            else if(i == 2)
            {
                diceThree = go;
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

        resultDiceThree = diceThree.GetComponent<CubeScript>().face;
        switch (resultDiceThree)
        {
            case "RedFace":
                nbRedFace++;
                Destroy(diceThree);
                break;
            case "BlueFace":
                nbBlueFace++;
                Destroy(diceThree);
                break;
            case "YellowFace":
                nbYellowFace++;
                Destroy(diceThree);
                break;
            case "GreenFace":
                nbGreenFace++;
                Destroy(diceThree);
                break;
            case "WhiteFace":
                nbWhiteFace++;
                Destroy(diceThree);
                break;
            case "BlackFace":
                nbBlackFace++;
                Destroy(diceThree);
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(2.0f);
        panelButtonChoice.SetActive(true);
        while (nbWhiteFace > 0)
        {
            while (!choose)
            {
                yield return new WaitForSeconds(5.0f);
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
}
