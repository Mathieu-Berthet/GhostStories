using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouddhisteTemple : MonoBehaviour {

    [SerializeField]
    private int numberOfBouddha = 2;
    public bool hauntedTile = false;

    public GameObject bouddhaFirst;
    public GameObject bouddhaSecond;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void getBouddha(GameObject player)
    {
        //Si joueur bleu avec pouvoir "Second souffle" : numberOfBouddha -=2

        numberOfBouddha -= 1;
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
            player.GetComponent<YellowPlayer>().NbBouddha += 1;
        }
        else if (player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().NbBouddha += 1;
        }
    }

    public void KillGhost()
    {
        //Kill le fantome qui apparait sur la meme case que le bouddha
        //Remettre le bouddha a sa place et augmenter le nombre de bouddha de la tuile.
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
