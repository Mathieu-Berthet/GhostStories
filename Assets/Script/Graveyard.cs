using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graveyard : MonoBehaviour
{
    [SerializeField]
    private GameObject[] playerToResurrect;

    [SerializeField]
    private CubeScript cube;
    public Text infos;

    public string resultFace;

    public bool hauntedTile = false;
    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Resurrect(GameObject player)
    {
        if (!hauntedTile)
        {
            //PARTIE POUR RESU ^^'
            LaunchBlackDice(player);
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
        }
    }

    public void LaunchBlackDice(GameObject player)
    {
        if (player.name == "BluePlayer")
        {
            StartCoroutine(player.GetComponent<BluePlayer>().LaunchBlackDice());
            player.GetComponent<BluePlayer>().update = true;
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
            player.GetComponent<BluePlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
        }
        /*else if (player.name == "RedPlayer")
        {
            //player.GetComponent<RedPlayer>().DrawAGhost();
        }
        else if (player.name == "GreenPlayer")
        {
            //player.GetComponent<GreenPlayer>().DrawAGhost();
        }
        else if (player.name == "YellowPlayer")
        {
            //player.GetComponent<YellowPlayer>().DrawAGhost();
        }*/
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
