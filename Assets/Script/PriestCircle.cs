using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestCircle : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private int typeJeton; // A voir si on fait un script général pour les jetons, afin d'avoir un type précis ici. Ou bien gameobject et on va chercher la couleur.

    public StockOfToken tokenStock;
    public string choseenToken;
    public GameObject token;

    // Use this for initialization
    void Start ()
    {
        tokenStock = GetComponent<StockOfToken>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reduceGhostLife()
    {
        switch(choseenToken)
        {
            case "Red":
                if (tokenStock.nbRedToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbRedToken -= 1;
                    if (token != null)
                    {

                        token = GetComponent<StockOfToken>().transform.GetChild(0).GetChild(0).gameObject;
                        token.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        token = GetComponent<StockOfToken>().transform.GetChild(0).GetChild(0).gameObject;
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            case "Blue":
                if (tokenStock.nbBlueToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbBlueToken -= 1;
                }
                break;
            case "Green":
                if (tokenStock.nbGreenToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbGreenToken -= 1;
                }
                break;
            case "Yellow":
                if (tokenStock.nbYellowToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbYellowToken -= 1;
                }
                break;
            case "black":
                if (tokenStock.nbBlackToken == 0)
                {
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbBlackToken -= 1;
                }
                break;
            default:
                break;
        }
    }
}
