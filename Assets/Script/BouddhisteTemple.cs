using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouddhisteTemple : MonoBehaviour {

    [SerializeField]
    public int numberOfBouddha = 2;
    public bool hauntedTile = false;

    public GameObject bouddhaFirst;
    public GameObject bouddhaSecond;
    public GameObject fogHaunted;

    public Text infos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void getBouddha(GameObject player)
    {
        if (!hauntedTile)
        {
            //Si joueur bleu avec pouvoir "Second souffle" : numberOfBouddha -=2

            //numberOfBouddha -= 1;
            //Augementer la reserve de bouddha du joueur de 1 ou 2
            if (player.name == "BluePlayer")
            {
                if (numberOfBouddha == 0)
                {
                    infos.text = "Il n'y a plus de bouddha sur la tuile. Vous ne pouvez pas en prendre.";
                    infos.gameObject.SetActive(true);
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                else
                {
                    numberOfBouddha -= 1;
                    player.GetComponent<BluePlayer>().NbBouddha += 1;
                    if(player.GetComponent<BluePlayer>().bouddhaOne == null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<BluePlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<BluePlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if(player.GetComponent<BluePlayer>().bouddhaOne != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<BluePlayer>().bouddhaTwo = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<BluePlayer>().bouddhaTwo = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<BluePlayer>().bouddhaTwo != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<BluePlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<BluePlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    //Faire récupérer le 2e si pouvoir x2
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<BluePlayer>().canLaunchDice = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                    //Test avec son pouvoir pour augmenter de 2 si il l'a
                }
            }
            else if (player.name == "YellowPlayer")
            {
                if (numberOfBouddha == 0)
                {
                    infos.text = "Il n'y a plus de bouddha sur la tuile. Vous ne pouvez pas en prendre.";
                    infos.gameObject.SetActive(true);
                    player.GetComponent<YellowPlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<YellowPlayer>().canLaunchDice = true;
                    player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                }
                else
                {
                    numberOfBouddha -= 1;
                    player.GetComponent<YellowPlayer>().NbBouddha += 1;
                    if (player.GetComponent<YellowPlayer>().bouddhaOne == null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<YellowPlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<YellowPlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<YellowPlayer>().bouddhaOne != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<YellowPlayer>().bouddhaTwo = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<YellowPlayer>().bouddhaTwo = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<YellowPlayer>().bouddhaTwo != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<YellowPlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<YellowPlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    player.GetComponent<YellowPlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<YellowPlayer>().canLaunchDice = true;
                    player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                }
            }
            else if (player.name == "RedPlayer")
            {
                if (numberOfBouddha == 0)
                {
                    infos.text = "Il n'y a plus de bouddha sur la tuile. Vous ne pouvez pas en prendre.";
                    infos.gameObject.SetActive(true);
                    player.GetComponent<RedPlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<RedPlayer>().canLaunchDice = true;
                    player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                }
                else
                {
                    numberOfBouddha -= 1;
                    player.GetComponent<RedPlayer>().NbBouddha += 1;
                    if (player.GetComponent<RedPlayer>().bouddhaOne == null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<RedPlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<RedPlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<RedPlayer>().bouddhaOne != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<RedPlayer>().bouddhaTwo = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<RedPlayer>().bouddhaTwo = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<RedPlayer>().bouddhaTwo != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<RedPlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<RedPlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    player.GetComponent<RedPlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<RedPlayer>().canLaunchDice = true;
                    player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                }
            }
            else if (player.name == "GreenPlayer")
            {
                if (numberOfBouddha == 0)
                {
                    infos.text = "Il n'y a plus de bouddha sur la tuile. Vous ne pouvez pas en prendre.";
                    infos.gameObject.SetActive(true);
                    player.GetComponent<GreenPlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<GreenPlayer>().canLaunchDice = true;
                    player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                }
                else
                {
                    numberOfBouddha -= 1;
                    player.GetComponent<GreenPlayer>().NbBouddha += 1;
                    if (player.GetComponent<GreenPlayer>().bouddhaOne == null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<GreenPlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<GreenPlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<GreenPlayer>().bouddhaOne != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<GreenPlayer>().bouddhaTwo = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<GreenPlayer>().bouddhaTwo = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    else if (player.GetComponent<GreenPlayer>().bouddhaTwo != null)
                    {
                        if (bouddhaFirst != null)
                        {
                            player.GetComponent<GreenPlayer>().bouddhaOne = bouddhaFirst;
                            bouddhaFirst.transform.parent = player.transform;
                            bouddhaFirst.transform.localPosition = new Vector3(0.0f, 1.5f, 0.0f);
                            bouddhaFirst.SetActive(true);
                            bouddhaFirst = null;
                        }
                        else
                        {
                            player.GetComponent<GreenPlayer>().bouddhaOne = bouddhaSecond;
                            bouddhaSecond.transform.parent = player.transform;
                            bouddhaSecond.transform.localPosition = new Vector3(0.0f, 2.25f, 0.0f);
                            bouddhaSecond.SetActive(true);
                            bouddhaSecond = null;
                        }
                    }
                    player.GetComponent<GreenPlayer>().update = true;
                    player.GetComponent<Deplacement>().enabled = true;
                    player.GetComponent<GreenPlayer>().canLaunchDice = true;
                    player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                }
            }
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activer son pouvoir";
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
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().canLaunchDice = true;
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;
            }
        }
    }

    public void haunted()
    {
        if (hauntedTile)
        {
            fogHaunted.transform.GetChild(6).GetComponent<ParticleSystem>().Play();
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
