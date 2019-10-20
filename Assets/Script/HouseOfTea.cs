using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseOfTea : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private StockOfToken tokenStock;
    public string choseenToken;
    public bool choose;
    public GameObject panelButtonChoice;

    // Use this for initialization
    void Start ()
    {
        tokenStock = GameObject.Find("TokenStock").GetComponent<StockOfToken>();
        choose = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator GainTokenAndQI(GameObject player)
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
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().NbRedToken += 1;
                        player.GetComponent<BluePlayer>().DrawAGhost();
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Blue":
                if(tokenStock.nbBlueToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlueToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().NbBlueToken += 1;
                        player.GetComponent<BluePlayer>().DrawAGhost();
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Green":
                if(tokenStock.nbGreenToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbGreenToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().NbGreenToken += 1;
                        player.GetComponent<BluePlayer>().DrawAGhost();
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "Yellow":
                if(tokenStock.nbYellowToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbYellowToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().NbYellowToken += 1;
                        player.GetComponent<BluePlayer>().DrawAGhost();
                        player.GetComponent<BluePlayer>().update = true;
                        player.GetComponent<BluePlayer>().canLaunchDice = true;
                        player.GetComponent<BluePlayer>().useTilePower = false;
                        player.GetComponent<Deplacement>().enabled = true;
                        player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    }
                }
                break;
            case "black":
                if(tokenStock.nbBlackToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlackToken -= 1;
                    if (player.name == "BluePlayer")
                    {
                        player.GetComponent<BluePlayer>().Qi += 1;
                        player.GetComponent<BluePlayer>().NbBlackToken += 1;
                        player.GetComponent<BluePlayer>().DrawAGhost();
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

    public void MustChooseToken(Button buttonClick)
    {
        choseenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
    }
}
