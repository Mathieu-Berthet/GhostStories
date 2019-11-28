﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private GameObject[] playerToResurrect;

    [SerializeField]
    private GameObject blackDice;

    [SerializeField]
    private CubeScript cube;
    public string resultFace;

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
        StartCoroutine(LaunchBlackDice(player));
    }

    public IEnumerator LaunchBlackDice(GameObject player)
    {
            if (player.name == "BluePlayer")
            {
                StartCoroutine(player.GetComponent<BluePlayer>().LaunchBlackDice());
            }
            else if (player.name == "RedPlayer")
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
            }
        yield return new WaitForSeconds(0.5f);

        Destroy(blackDice);
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
