using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriestCircle : MonoBehaviour
{
    public GameManager gm;

    [SerializeField]
    private GameObject token;
    public GameObject playerSave;

    public bool hauntedTile = false;

    public Text infos;
    public Text infoCircle;
    
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public IEnumerator reduceGhostLife(GameObject player)
    {
        if (!hauntedTile)
        {
            gm.choose = false;
            gm.panelButtonChoice.SetActive(true);
            playerSave = player;
            //infoCircle = gm.panelButtonChoice.transform.GetChild(0).GetComponent<Text>();
            infoCircle.text = "Veuillez choisir le jeton à mettre sur la tuile : ";
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
                        StopCoroutine(reduceGhostLife(player));
                        StartCoroutine(reduceGhostLife(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbRedToken -= 1;
                        if (token != null)
                        {
                            switch (token.name)
                            {
                                case "BlueToken(Clone)":
                                    gm.tokenStock.nbBlueToken += 1;
                                    break;
                                case "YellowToken(Clone)":
                                    gm.tokenStock.nbYellowToken += 1;
                                    break;
                                case "GreenToken(Clone)":
                                    gm.tokenStock.nbGreenToken += 1;
                                    break;
                                case "BlackToken(Clone)":
                                    gm.tokenStock.nbBlackToken += 1;
                                    break;
                                default:
                                    break;
                            }
                            token.GetComponent<PoolChild>().ReturnToPool();
                            token = null;
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                        else
                        {
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.redToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                    }
                    break;
                case "Blue":
                    if (gm.tokenStock.nbBlueToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons bleus, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(reduceGhostLife(player));
                        StartCoroutine(reduceGhostLife(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbBlueToken -= 1;
                        if (token != null)
                        {
                            switch (token.name)
                            {
                                case "RedToken(Clone)":
                                    gm.tokenStock.nbRedToken += 1;
                                    break;
                                case "YellowToken(Clone)":
                                    gm.tokenStock.nbYellowToken += 1;
                                    break;
                                case "GreenToken(Clone)":
                                    gm.tokenStock.nbGreenToken += 1;
                                    break;
                                case "BlackToken(Clone)":
                                    gm.tokenStock.nbBlackToken += 1;
                                    break;
                                default:
                                    break;
                            }
                            token.GetComponent<PoolChild>().ReturnToPool();
                            token = null;
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blueToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                        else
                        {
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blueToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                    }
                    break;
                case "Green":
                    if (gm.tokenStock.nbGreenToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons verts, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(reduceGhostLife(player));
                        StartCoroutine(reduceGhostLife(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbGreenToken -= 1;
                        if (token != null)
                        {
                            switch (token.name)
                            {
                                case "RedToken(Clone)":
                                    gm.tokenStock.nbRedToken += 1;
                                    break;
                                case "YellowToken(Clone)":
                                    gm.tokenStock.nbYellowToken += 1;
                                    break;
                                case "BlueToken(Clone)":
                                    gm.tokenStock.nbBlueToken += 1;
                                    break;
                                case "BlackToken(Clone)":
                                    gm.tokenStock.nbBlackToken += 1;
                                    break;
                                default:
                                    break;
                            }
                            token.GetComponent<PoolChild>().ReturnToPool();
                            token = null;
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.greenToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                        else
                        {
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.greenToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                    }
                    break;
                case "Yellow":
                    if (gm.tokenStock.nbYellowToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons jaunes, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(reduceGhostLife(player));
                        StartCoroutine(reduceGhostLife(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbYellowToken -= 1;
                        if (token != null)
                        {
                            switch (token.name)
                            {
                                case "RedToken(Clone)":
                                    gm.tokenStock.nbRedToken += 1;
                                    break;
                                case "GreenToken(Clone)":
                                    gm.tokenStock.nbGreenToken += 1;
                                    break;
                                case "BlueToken(Clone)":
                                    gm.tokenStock.nbBlueToken += 1;
                                    break;
                                case "BlackToken(Clone)":
                                    gm.tokenStock.nbBlackToken += 1;
                                    break;
                                default:
                                    break;
                            }
                            token.GetComponent<PoolChild>().ReturnToPool();
                            token = null;
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.yellowToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                        else
                        {
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.yellowToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                    }
                    break;
                case "Black":
                    if (gm.tokenStock.nbBlackToken == 0)
                    {
                        infos.text = "Il n'y a plus de jetons black, veuillez choisir une autre couleur";
                        infos.gameObject.SetActive(true);
                        StopCoroutine(reduceGhostLife(player));
                        StartCoroutine(reduceGhostLife(playerSave));
                    }
                    else
                    {
                        gm.tokenStock.nbBlackToken -= 1;
                        if (token != null)
                        {
                            switch (token.name)
                            {
                                case "RedToken(Clone)":
                                    gm.tokenStock.nbRedToken += 1;
                                    break;
                                case "GreenToken(Clone)":
                                    gm.tokenStock.nbGreenToken += 1;
                                    break;
                                case "BlueToken(Clone)":
                                    gm.tokenStock.nbBlueToken += 1;
                                    break;
                                case "YellowToken(Clone)":
                                    gm.tokenStock.nbYellowToken += 1;
                                    break;
                                default:
                                    break;
                            }
                            token.GetComponent<PoolChild>().ReturnToPool();
                            token = null;
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blackToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                        else
                        {
                            token = gm.tokenStock.GetComponent<PoolManager>().GetPoolByName(PoolName.blackToken).GetItem(transform, new Vector3(-0.32f, 0.75f, 0.32f), Quaternion.identity, true, false, 0);
                            token.transform.SetParent(gameObject.transform);
                        }
                    }
                    break;
                default:
                    break;
            }

            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "GreenPlayer")
            {
                //player.GetComponent<GreenPlayer>().Qi -= 1;
                //player.GetComponent<GreenPlayer>().board.usingTile = true;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
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
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
            }
        }
    }

    //Good to haunt a tile. See later if we keep like this or if we change haunted system
    public void haunted()
    {
        if(hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
            RemovePawn();
        }
    }

    public void Unhaunted()
    {
        if (!hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
    }


    public void RemovePawn()
    {
        if(hauntedTile && token != null)
        {
            switch (token.name)
            {
                case "BlueToken(Clone)":
                    gm.tokenStock.nbBlueToken += 1;
                    break;
                case "YellowToken(Clone)":
                    gm.tokenStock.nbYellowToken += 1;
                    break;
                case "GreenToken(Clone)":
                    gm.tokenStock.nbGreenToken += 1;
                    break;
                case "BlackToken(Clone)":
                    gm.tokenStock.nbBlackToken += 1;
                    break;
                case "RedToken(Clone)":
                    gm.tokenStock.nbBlackToken += 1;
                    break;
                default:
                    break;
            }
            token.GetComponent<PoolChild>().ReturnToPool();
            token = null;
        }
    }
}
