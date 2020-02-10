using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HutOfWitch : MonoBehaviour
{
    public GameManager gm;

    public GameObject ghostToKill;
    public GameObject defausse;

    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;

    public BoardPosition board;
    public Text infos;

    public string chooseenGhost;

    public bool hauntedTile = false;
    public bool choose;
    // Use this for initialization
    void Start ()
    {
        choose = false;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public IEnumerator KillGhost(GameObject player)
    {
        if (!hauntedTile)
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

            switch (ghostToKill.GetComponent<Ghost>().couleur)
            {
                case "red":
                    gm.redBoard.nbCardOnBoard--;
                    break;
                case "yellow":
                    gm.yellowBoard.nbCardOnBoard--;
                    break;
                case "blue":
                case "black":
                    gm.blueBoard.nbCardOnBoard--;
                    break;
                case "green":
                    gm.greenBoard.nbCardOnBoard--;
                    break;
                default:
                    break;
            }

            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().Qi -= 1;
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().Qi -= 1;
                //player.GetComponent<GreenPlayer>().board.usingTile = true;

            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().Qi -= 1;
                //player.GetComponent<YellowPlayer>().board.usingTile = true;

            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().Qi -= 1;
                //player.GetComponent<RedPlayer>().board.usingTile = true;

            }
            ghostToKill.transform.parent.GetChild(0).GetChild(2).GetComponent<ParticleSystem>().Play();
            if (ghostToKill.transform.parent.GetChild(1).childCount >= 1)
            {
                Destroy(ghostToKill.transform.parent.GetChild(1).GetChild(0).gameObject);
            }
            if (ghostToKill.transform.parent.GetChild(2).childCount >= 1)
            {
                Destroy(ghostToKill.transform.parent.GetChild(2).GetChild(0).gameObject);
            }
            ghostToKill.transform.parent = defausse.transform;
            ghostToKill.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            ghostToKill.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
            ghostToKill = null;
            board.usingTile = false;
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

    public void MustChooseGhost(Button buttonClick)
    {
        Debug.Log("coucou");
        chooseenGhost = buttonClick.name;
        switch(chooseenGhost)
        {
            case "BlueOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "RedOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "RedTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "RedThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount > 4)
                {
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
