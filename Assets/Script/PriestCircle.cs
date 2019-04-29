using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestCircle : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private int typeJeton; // A voir si on fait un script général pour les jetons, afin d'avoir un type précis ici. Ou bien gameobject et on va chercher la couleur.

    public StockOfToken tokenStock;
    public string choseenToken;
    public GameObject token; // A modifier. 2 Variables. Une pour le jeton A INSTANCIER, l'autre pour le jeton a RENVOYER DANS LA POULE

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
                    Debug.Log("Il n'y a plus de jeton rouge en stock, veuillez choisir une autre couleur");
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
                        token = GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(0,0,0), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            case "Blue":
                if (tokenStock.nbBlueToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton bleu en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbBlueToken -= 1;
                    token = GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(0, 0, 0), Quaternion.identity, true, false, 1);

                }
                break;
            case "Green":
                if (tokenStock.nbGreenToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton vert en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbGreenToken -= 1;
                    token = GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(0, 0, 0), Quaternion.identity, true, false, 2);

                }
                break;
            case "Yellow":
                if (tokenStock.nbYellowToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton jaune en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbYellowToken -= 1;
                    token = GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(0, 0, 0), Quaternion.identity, true, false, 3);

                }
                break;
            case "black":
                if (tokenStock.nbBlackToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton noir en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                }
                else
                {
                    tokenStock.nbBlackToken -= 1;
                    token = GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(0, 0, 0), Quaternion.identity, true, false, 4);

                }
                break;
            default:
                break;
        }
    }
}
