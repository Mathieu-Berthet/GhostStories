using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindCelestialFlag : MonoBehaviour {

    public bool hauntedTile = false;
    public GameManager gm;
    public Text infos;
    public GameObject ghostToMove;
    public string chooseenGhost;
    public bool choosePlayer;
    public bool chooseGhost;
    public bool selectedPosition;
    public string playerToMove;
    public string namePositionGhost;
    public GameObject panelBoardPlayer;
    public GameObject playerChoose;
    public GameObject hauntingGhostToMove;

    public GameObject defausse;
    public GameObject bouddhisteTemple;
    public GameObject bouddha;
    public bool canPlace;

    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;
    public GameObject previousPosition;
    public BoardPosition board;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        canPlace = false;
        chooseGhost = false;
        choosePlayer = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator MovePlayerAndGhost()
    {
        if(!hauntedTile)
        {
            //PARTIE DEPLACEMENT FANTOME
            chooseGhost = false;
            canPlace = false;
            board.usingTile = true;
            yield return new WaitForSeconds(0.5f);
            infos.gameObject.SetActive(true);
            infos.text = "Veuillez choisir le fantôme à déplacer";
            panelBluePlace.SetActive(true);
            panelRedPlace.SetActive(true);
            panelGreenPlace.SetActive(true);
            panelYellowPlace.SetActive(true);
            while (!chooseGhost)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseGhost)
            {
                panelBluePlace.SetActive(false);
                panelRedPlace.SetActive(false);
                panelGreenPlace.SetActive(false);
                panelYellowPlace.SetActive(false);
                if (ghostToMove.transform.parent.GetChild(1).childCount >= 1)
                {
                    hauntingGhostToMove = ghostToMove.transform.parent.GetChild(1).GetChild(0).gameObject;
                    namePositionGhost = "One";
                }
                if (ghostToMove.transform.parent.GetChild(2).childCount >= 1)
                {
                    hauntingGhostToMove = ghostToMove.transform.parent.GetChild(2).GetChild(0).gameObject;
                    namePositionGhost = "Two";
                }
                chooseGhost = false;
                canPlace = true;
            }
            infos.text = "Veuillez choisir le nouvel emplacement du fantôme";
            while (!selectedPosition)
            {
                Debug.Log("Couocu");
                panelBluePlace.SetActive(true);
                panelRedPlace.SetActive(true);
                panelGreenPlace.SetActive(true);
                panelYellowPlace.SetActive(true);
                yield return new WaitForSeconds(1.0f);
            }

            //PARTIE DEPLACEMENT JOUEUR
            panelBoardPlayer.SetActive(true);
            infos.text = "Veuillez choisir le joueur à déplacer";
            while (!choosePlayer)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (choosePlayer)
            {
                panelBoardPlayer.SetActive(false);
                choosePlayer = false;
            }
            if (playerChoose.name == "BluePlayer")
            {
                infos.text = "Veuillez choisir la tuile d'arrivée";
                playerChoose.GetComponent<BluePlayer>().CheckDistance();
                StartCoroutine(playerChoose.GetComponent<Deplacement>().PlayerDeplacement());
                playerChoose.GetComponent<BluePlayer>().canLaunchDice = true;
                playerChoose.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                playerChoose.GetComponent<BluePlayer>().useTilePower = false;
                playerChoose.GetComponent<Deplacement>().enabled = true;
                playerChoose.GetComponent<BluePlayer>().update = true;
            }
            //Pour les autres joueurs ...
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activez son pouvoir";
            infos.gameObject.SetActive(true);
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

    public void getPlayer(GameObject player)
    {
        playerChoose = player;
        choosePlayer = true;
    }

    public void MustChooseGhostToMove(Button buttonClick)
    {
        Debug.Log("coucou");
        chooseenGhost = buttonClick.name;
        if (ghostToMove == null)
        {
            switch (chooseenGhost)
            {
                case "BlueOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne;
                    }
                    break;
                case "BlueTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo;
                    }
                    break;
                case "BlueThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree;
                    }
                    break;
                case "RedOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne;
                    }
                    break;
                case "RedTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo;
                    }
                    break;
                case "RedThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree;
                    }
                    break;
                case "GreenOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne;
                    }
                    break;
                case "GreenTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo;
                    }
                    break;
                case "GreenThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree;
                    }
                    break;
                case "YellowOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne;
                    }
                    break;
                case "YellowTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo;
                    }
                    break;
                case "YellowThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.GetChild(4).gameObject;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree;
                    }
                    break;
            }
        }
        chooseGhost = true;
    }


    public void SelectGhostNewPosition(GameObject position)
    {
        selectedPosition = false;
        if (ghostToMove != null && canPlace)
        {
            if (position.transform.childCount > 4)
            {
                bouddha = position.transform.GetChild(4).gameObject;
                ghostToMove.transform.SetParent(defausse.transform);
                ghostToMove.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                ghostToMove.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                bouddhisteTemple.GetComponent<BouddhisteTemple>().numberOfBouddha += 1;
                bouddha.transform.parent = bouddhisteTemple.transform;
                bouddha.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                bouddha.SetActive(false);
                bouddha = null;

                panelBluePlace.SetActive(false);
                panelRedPlace.SetActive(false);
                panelGreenPlace.SetActive(false);
                panelYellowPlace.SetActive(false);
                selectedPosition = true;
                canPlace = false;
            }
            else
            {
                ghostToMove.transform.SetParent(position.transform);
                ghostToMove.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                ghostToMove.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 180.0f);
                ghostToMove.transform.localScale = new Vector3(15.0f, 10.0f, 1);
                ghostToMove.transform.parent.GetComponent<BoxCollider>().enabled = true;
                ghostToMove.GetComponent<GhostPower>().startPosition = ghostToMove.transform.parent.GetChild(1);
                ghostToMove.GetComponent<GhostPower>().middlePosition = ghostToMove.transform.parent.GetChild(2);
                ghostToMove.GetComponent<GhostPower>().endPosition = ghostToMove.transform.parent.GetChild(3);
                if (namePositionGhost == "One")
                {
                    hauntingGhostToMove.transform.parent = ghostToMove.GetComponent<GhostPower>().startPosition;
                    hauntingGhostToMove.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                }
                else if (namePositionGhost == "Two")
                {
                    hauntingGhostToMove.transform.parent = ghostToMove.GetComponent<GhostPower>().middlePosition;
                    hauntingGhostToMove.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                }
                //Décompte du plateau précédent
                if (previousPosition.transform.parent.GetComponent<boardColor>().color == "blue")
                {
                    gm.blueBoard.nbCardOnBoard--;
                }
                else if (previousPosition.transform.parent.GetComponent<boardColor>().color == "green")
                {
                    gm.greenBoard.nbCardOnBoard--;
                }
                else if (previousPosition.transform.parent.GetComponent<boardColor>().color == "red")
                {
                    gm.redBoard.nbCardOnBoard--;
                }
                else if (previousPosition.transform.parent.GetComponent<boardColor>().color == "yellow")
                {
                    gm.yellowBoard.nbCardOnBoard--;
                }

                //Compte sur le nouveau plateau
                if (position.transform.parent.GetComponent<boardColor>().color == "blue")
                {
                    gm.blueBoard.nbCardOnBoard++;
                }
                else if (position.transform.parent.GetComponent<boardColor>().color == "green")
                {
                    gm.greenBoard.nbCardOnBoard++;
                }
                else if (position.transform.parent.GetComponent<boardColor>().color == "red")
                {
                    gm.redBoard.nbCardOnBoard++;
                }
                else if (position.transform.parent.GetComponent<boardColor>().color == "yellow")
                {
                    gm.yellowBoard.nbCardOnBoard++;
                }
                panelBluePlace.SetActive(false);
                panelRedPlace.SetActive(false);
                panelGreenPlace.SetActive(false);
                panelYellowPlace.SetActive(false);
                selectedPosition = true;
                canPlace = false;
            }
        }
    }
}
