﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightTower : MonoBehaviour
{
    public GameManager gm;

    public GameObject panelBoardChoice;
    public GameObject hauntingGhost;
    public GameObject ghostCard;
    public GameObject fogHaunted;

    public Text infos;
    public Text infoTower;

    public string boardToRetreatGhost;
   
    public bool hauntedTile = false;
    public bool chooseBoard;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        hauntingGhost = null;
        ghostCard = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	//Fait reculer les fantomes hanteur d'un plateau d'une case.
    public IEnumerator RetreatGhost(GameObject player)
    {
        if (!hauntedTile)
        {
            //Choix du plateau
            infoTower.text = "Veuillez choisir le plateau dont vous voulez faire reculer les fantômes : ";
            panelBoardChoice.SetActive(true);
            while (!chooseBoard)
            {
                yield return new WaitForSeconds(2.0f);
            }
            if (chooseBoard)
            {
                switch (boardToRetreatGhost)
                {
                    case "Red":
                        int maxChildRed = gm.redBoard.gameObject.transform.childCount;
                        for (int i = 0; i < maxChildRed; i++)
                        {
                            if (gm.redBoard.gameObject.transform.GetChild(i).childCount >= 5)
                            {
                                if (gm.redBoard.gameObject.transform.GetChild(i).GetChild(1).childCount >= 1)
                                {
                                    hauntingGhost = gm.redBoard.gameObject.transform.GetChild(i).GetChild(1).GetChild(0).gameObject;
                                    ghostCard = gm.redBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                                else if (gm.redBoard.gameObject.transform.GetChild(i).GetChild(2).childCount >= 1)
                                {
                                    hauntingGhost = gm.redBoard.gameObject.transform.GetChild(i).GetChild(2).GetChild(0).gameObject;
                                    ghostCard = gm.redBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                            }
                        }
                        break;
                    case "Blue":
                        int maxChildBlue = gm.blueBoard.gameObject.transform.childCount;
                        for (int i = 0; i < maxChildBlue; i++)
                        {
                            if (gm.blueBoard.gameObject.transform.GetChild(i).childCount >= 5)
                            {
                                if (gm.blueBoard.gameObject.transform.GetChild(i).GetChild(1).childCount >= 1)
                                {
                                    hauntingGhost = gm.blueBoard.gameObject.transform.GetChild(i).GetChild(1).GetChild(0).gameObject;
                                    ghostCard = gm.blueBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                                else if (gm.blueBoard.gameObject.transform.GetChild(i).GetChild(2).childCount >= 1)
                                {
                                    hauntingGhost = gm.blueBoard.gameObject.transform.GetChild(i).GetChild(2).GetChild(0).gameObject;
                                    ghostCard = gm.blueBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                            }
                        }
                        break;
                    case "Yellow":
                        int maxChildYellow = gm.yellowBoard.gameObject.transform.childCount;
                        for (int i = 0; i < maxChildYellow; i++)
                        {
                            if (gm.yellowBoard.gameObject.transform.GetChild(i).childCount >= 5)
                            {
                                if (gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(1).childCount >= 1)
                                {
                                    hauntingGhost = gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(1).GetChild(0).gameObject;
                                    ghostCard = gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                                else if (gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(2).childCount >= 1)
                                {
                                    hauntingGhost = gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(2).GetChild(0).gameObject;
                                    ghostCard = gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                            }
                        }
                        break;
                    case "Green":
                        int maxChildGreen = gm.greenBoard.gameObject.transform.childCount;
                        for (int i = 0; i < maxChildGreen; i++)
                        {
                            if (gm.greenBoard.gameObject.transform.GetChild(i).childCount >= 5)
                            {
                                if (gm.greenBoard.gameObject.transform.GetChild(i).GetChild(1).childCount >= 1)
                                {
                                    hauntingGhost = gm.greenBoard.gameObject.transform.GetChild(i).GetChild(1).GetChild(0).gameObject;
                                    ghostCard = gm.greenBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                                else if (gm.greenBoard.gameObject.transform.GetChild(i).GetChild(2).childCount >= 1)
                                {
                                    hauntingGhost = gm.greenBoard.gameObject.transform.GetChild(i).GetChild(2).GetChild(0).gameObject;
                                    ghostCard = gm.greenBoard.gameObject.transform.GetChild(i).GetChild(4).gameObject;
                                    if (hauntingGhost.transform.parent.name.Contains("Case"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                    else if (hauntingGhost.transform.parent.name.Contains("Depart"))
                                    {
                                        //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
                                        hauntingGhost.transform.parent = ghostCard.GetComponent<Ghost>().power.startPosition;
                                        hauntingGhost.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                chooseBoard = false;
                panelBoardChoice.SetActive(false);
                gm.cantPause = false;
            }

            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;

            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
            }
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activer son pouvoir";
            infos.gameObject.SetActive(true);
            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;
            }
            gm.cantPause = false;
        }
    }

    public void haunted()
    {
        if (hauntedTile)
        {
            fogHaunted.transform.GetChild(6).GetComponent<ParticleSystem>().Play();
            StartCoroutine(gm.audio.PlayHauntingFX(gm.audio.GetComponent<AudioManager>().hauntingFX, gm.audio.GetComponent<AudioManager>().horrorScreamFX, 3.0f));
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

    public void getBoard(Button buttonClick)
    {
        boardToRetreatGhost = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        chooseBoard = true;
    }
}
