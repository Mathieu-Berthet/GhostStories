using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriestCircle : MonoBehaviour {

    public bool hauntedTile = false;

    [SerializeField]
    private StockOfToken tokenStock;
    public string choseenToken;
    public bool choose;
    [SerializeField]
    private GameObject token;

    public GameObject panelButtonChoice;

    // Use this for initialization
    void Start ()
    {
        tokenStock = GameObject.Find("TokenStock").GetComponent<StockOfToken>();
        //TEST
        choseenToken = "Red";
        choose = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //To change. It was for test, and it is okay. 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(reduceGhostLife());
        }
        /*if(Input.GetMouseButtonDown(1))
        {
            hauntedTile = true;
            haunted();
        }*/
    }

    public IEnumerator reduceGhostLife()
    {
        panelButtonChoice.SetActive(true);
        while(!choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if(choose)
        {
            Debug.Log("Couocu");
            panelButtonChoice.SetActive(false);
            choose = false;
        }
        switch(choseenToken)
        {
            case "Red":
                if (tokenStock.nbRedToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton rouge en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbRedToken -= 1;
                    if (token != null)
                    {
                        switch (token.name)
                        {
                            case "BlueToken":
                                tokenStock.nbBlueToken += 1;
                                break;
                            case "YellowToken":
                                tokenStock.nbYellowToken += 1;
                                break;
                            case "GreenToken":
                                tokenStock.nbGreenToken += 1;
                                break;
                            case "BlackToken":
                                tokenStock.nbBlackToken += 1;
                                break;
                            default:
                                break;
                        }
                        token.GetComponent<PoolChild>().ReturnToPool();
                        token = null;
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            case "Blue":
                if (tokenStock.nbBlueToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton bleu en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlueToken -= 1;
                    if (token != null)
                    {
                        switch(token.name)
                        {
                            case "RedToken":
                                tokenStock.nbRedToken += 1;
                                break;
                            case "YellowToken":
                                tokenStock.nbYellowToken += 1;
                                break;
                            case "GreenToken":
                                tokenStock.nbGreenToken += 1;
                                break;
                            case "BlackToken":
                                tokenStock.nbBlackToken += 1;
                                break;
                            default:
                                break;
                        }
                        token.GetComponent<PoolChild>().ReturnToPool();
                        token = null;
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blueToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blueToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            case "Green":
                if (tokenStock.nbGreenToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton vert en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbGreenToken -= 1;
                    if (token != null)
                    {
                        switch (token.name)
                        {
                            case "RedToken":
                                tokenStock.nbRedToken += 1;
                                break;
                            case "YellowToken":
                                tokenStock.nbYellowToken += 1;
                                break;
                            case "BlueToken":
                                tokenStock.nbBlueToken += 1;
                                break;
                            case "BlackToken":
                                tokenStock.nbBlackToken += 1;
                                break;
                            default:
                                break;
                        }
                        token.GetComponent<PoolChild>().ReturnToPool();
                        token = null;
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.greenToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.greenToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            case "Yellow":
                if (tokenStock.nbYellowToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton jaune en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbYellowToken -= 1;
                    if (token != null)
                    {
                        switch (token.name)
                        {
                            case "RedToken":
                                tokenStock.nbRedToken += 1;
                                break;
                            case "GreenToken":
                                tokenStock.nbGreenToken += 1;
                                break;
                            case "BlueToken":
                                tokenStock.nbBlueToken += 1;
                                break;
                            case "BlackToken":
                                tokenStock.nbBlackToken += 1;
                                break;
                            default:
                                break;
                        }
                        token.GetComponent<PoolChild>().ReturnToPool();
                        token = null;
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.yellowToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.yellowToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            case "Black":
                if (tokenStock.nbBlackToken == 0)
                {
                    Debug.Log("Il n'y a plus de jeton noir en stock, veuillez choisir une autre couleur");
                    //Indiquer qu'il y en a plus en reserve
                    //Redemander de choisir une autre couleur
                }
                else
                {
                    tokenStock.nbBlackToken -= 1;
                    if (token != null)
                    {
                        switch (token.name)
                        {
                            case "RedToken":
                                tokenStock.nbRedToken += 1;
                                break;
                            case "GreenToken":
                                tokenStock.nbGreenToken += 1;
                                break;
                            case "BlueToken":
                                tokenStock.nbBlueToken += 1;
                                break;
                            case "YellowToken":
                                tokenStock.nbYellowToken += 1;
                                break;
                            default:
                                break;
                        }
                        token.GetComponent<PoolChild>().ReturnToPool();
                        token = null;
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blackToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                    else
                    {
                        token = tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blackToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                        token.transform.SetParent(gameObject.transform);
                    }
                }
                break;
            default:
                break;
        }
    }

    //Good to haunt a tile. See later if we keep like this or if we change haunted system
    public void haunted()
    {
        if(hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
    }


    public void MustChooseToken(Button buttonClick)
    {
        choseenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
    }
}
