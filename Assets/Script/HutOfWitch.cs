using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HutOfWitch : MonoBehaviour {

    public bool hauntedTile = false;

    public GameObject ghostToKill;
    public GameObject defausse;
    public string chooseenGhost;
    public bool choose;
    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;
    public BoardPosition board;
    // Use this for initialization
    void Start ()
    {
        choose = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public IEnumerator KillGhost(GameObject player)
    {
        choose = false;
        board.usingTile = true;
        yield return new WaitForSeconds(0.5f);

        panelBluePlace.SetActive(true);
        panelRedPlace.SetActive(true);
        panelGreenPlace.SetActive(true);
        panelYellowPlace.SetActive(true);
        while (!choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (choose)
        {
            Debug.Log("Couocu");
            panelBluePlace.SetActive(false);
            panelRedPlace.SetActive(false);
            panelGreenPlace.SetActive(false);
            panelYellowPlace.SetActive(false);
            choose = false;
        }

        if (player.name == "BluePlayer")
        {
            //player.GetComponent<BluePlayer>().enabled = true;
            //player.GetComponent<BluePlayer>().card = ghostToKill;
            switch (ghostToKill.GetComponent<Ghost>().couleur)
            {
                case "red":
                    player.GetComponent<BluePlayer>().redBoard.nbCardOnBoard--;
                break;
                case "yellow":
                    player.GetComponent<BluePlayer>().yellowBoard.nbCardOnBoard--;
                    break;
                case "blue":
                    player.GetComponent<BluePlayer>().blueBoard.nbCardOnBoard--;
                    break;
                case "green":
                    player.GetComponent<BluePlayer>().greenBoard.nbCardOnBoard--;
                    break;
                default:
                    break;
            }

            player.GetComponent<BluePlayer>().Qi -= 1;
            player.GetComponent<BluePlayer>().update = true;
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
            player.GetComponent<BluePlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
        }
        else if (player.name == "GreenPlayer")
        {
            player.GetComponent<GreenPlayer>().Qi -= 1;
            //player.GetComponent<GreenPlayer>().board.usingTile = true;
            /*switch (ghostToKill.GetComponent<Ghost>().couleur)
            {
                case "red":
                    player.GetComponent<BluePlayer>().redBoard.nbCardOnBoard--;
                    break;
                case "yellow":
                    player.GetComponent<BluePlayer>().yellowBoard.nbCardOnBoard--;
                    break;
                case "blue":
                    player.GetComponent<BluePlayer>().blueBoard.nbCardOnBoard--;
                    break;
                case "green":
                    player.GetComponent<BluePlayer>().greenBoard.nbCardOnBoard--;
                    break;
                default:
                    break;
            }*/
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().Qi -= 1;
            //player.GetComponent<YellowPlayer>().board.usingTile = true;
            /*switch (ghostToKill.GetComponent<Ghost>().couleur)
            {
                case "red":
                    player.GetComponent<BluePlayer>().redBoard.nbCardOnBoard--;
                    break;
                case "yellow":
                    player.GetComponent<BluePlayer>().yellowBoard.nbCardOnBoard--;
                    break;
                case "blue":
                    player.GetComponent<BluePlayer>().blueBoard.nbCardOnBoard--;
                    break;
                case "green":
                    player.GetComponent<BluePlayer>().greenBoard.nbCardOnBoard--;
                    break;
                default:
                    break;
            }*/
        }
        else if (player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().Qi -= 1;
            //player.GetComponent<RedPlayer>().board.usingTile = true;
            /*switch (ghostToKill.GetComponent<Ghost>().couleur)
            {
                case "red":
                    player.GetComponent<BluePlayer>().redBoard.nbCardOnBoard--;
                    break;
                case "yellow":
                    player.GetComponent<BluePlayer>().yellowBoard.nbCardOnBoard--;
                    break;
                case "blue":
                    player.GetComponent<BluePlayer>().blueBoard.nbCardOnBoard--;
                    break;
                case "green":
                    player.GetComponent<BluePlayer>().greenBoard.nbCardOnBoard--;
                    break;
                default:
                    break;
            }*/
        }

        ghostToKill.transform.parent = defausse.transform;
        ghostToKill.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        ghostToKill = null;
        board.usingTile = false;
    }

    public void MustChooseGhost(Button buttonClick)
    {
        Debug.Log("coucou");
        chooseenGhost = buttonClick.name;
        switch(chooseenGhost)
        {
            case "BlueOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "RedOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "RedTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "RedThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount > 4)
                {
                    Debug.Log(buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount);
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.GetChild(4).gameObject;
                }
                break;
        }
        choose = true;
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
