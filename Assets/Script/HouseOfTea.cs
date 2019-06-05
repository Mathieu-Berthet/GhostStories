using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOfTea : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private StockOfToken tokenStock;
    public string choosenToken;

    // Use this for initialization
    void Start ()
    {
        tokenStock = GetComponent<StockOfToken>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GainTokenAndQI(GameObject player)
    {
        //Remplir choseenToken avant le switch
        //Demander la couleur ici ? (Demandez uniquement pour les jetons encore en stock ?)
        //Interface pour les jetons. (Bien plus simple)
        switch (choosenToken)
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
                }
                break;
            default:
                break;
        }

        //Recuperer le joueur sur la case et lui donner un qi
        if(player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().Qi += 1;
        }
        else if(player.name == "GreenPlayer")
        {
            player.GetComponent<GreenPlayer>().Qi += 1;
        }
        else if(player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().Qi += 1;
        }
        else if(player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().Qi += 1;
        }

        //Pioche d'une carte fantome
    }
}
