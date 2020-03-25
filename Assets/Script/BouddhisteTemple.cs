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
                numberOfBouddha -= 1;
                player.GetComponent<BluePlayer>().NbBouddha += 1;
                player.GetComponent<BluePlayer>().bouddhaOne = bouddhaFirst;
                bouddhaFirst.transform.parent = player.transform;
                bouddhaFirst.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                bouddhaFirst.SetActive(false);
                //Faire récupérer le 2e si pouvoir x2
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                //Test avec son pouvoir pour augmenter de 2 si il l'a
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().NbBouddha += 1;
            }
            else if (player.name == "YellowPlayer")
            {
                numberOfBouddha -= 1;
                player.GetComponent<YellowPlayer>().NbBouddha += 1;
                player.GetComponent<YellowPlayer>().bouddhaOne = bouddhaFirst;
                bouddhaFirst.transform.parent = player.transform;
                bouddhaFirst.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                bouddhaFirst.SetActive(false);
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().NbBouddha += 1;
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
