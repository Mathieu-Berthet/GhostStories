using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindCelestialFlag : MonoBehaviour {

    public GameManager gm;
    public GameObject fogHaunted;

    [Header("Les panels")]
    public GameObject panelBoardPlayer;
    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;

    [Header("Les objets à récupérer par la fonction")]
    public GameObject previousPosition;
    public GameObject playerChoose;
    public GameObject hauntingGhostToMove;
    public GameObject ghostToMove;

    [Header("Les autres objets")]
    public GameObject defausse;
    public GameObject bouddhisteTemple;
    public GameObject bouddha;

    [Header("Divers scripts et textes d'information")]
    public BoardPosition board;
    public Text infos;
    public Text infoWindCelestialFlag;

    [Header("String")]
    public string playerToMove;
    public string namePositionGhost;
    public string chooseenGhost;

    [Header("Booléens")]
    public bool hauntedTile = false;
    public bool choosePlayer;
    public bool chooseGhost;
    public bool selectedPosition;
    public bool canPlace;
    public bool isActiveTilePower;
    public bool oneTime;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        canPlace = false;
        chooseGhost = false;
        choosePlayer = false;
        isActiveTilePower = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator MovePlayerAndGhost(GameObject player)
    {
        if(!hauntedTile)
        {
            //PARTIE DEPLACEMENT FANTOME
            isActiveTilePower = true;
            chooseGhost = false;
            canPlace = false;
            board.mustChooseGhost = true;
            ghostToMove = null;
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
                board.mustChooseGhost = false;
            }
            infos.text = "Veuillez choisir le nouvel emplacement du fantôme";
            while (!selectedPosition)
            {
                panelBluePlace.SetActive(true);
                panelRedPlace.SetActive(true);
                panelGreenPlace.SetActive(true);
                panelYellowPlace.SetActive(true);
                yield return new WaitForSeconds(1.0f);
            }

            //PARTIE DEPLACEMENT JOUEUR
            CheckBoard(player);
            panelBoardPlayer.SetActive(true);
            infos.text = "Veuillez choisir le joueur à déplacer";
            infoWindCelestialFlag.text = "Veuillez choisir le joueur à déplacer : ";
            while (!choosePlayer)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (choosePlayer)
            {
                panelBoardPlayer.SetActive(false);
                oneTime = false;
                choosePlayer = false;
            }
            if (playerChoose.name == "BluePlayer")
            {
                infos.text = "Veuillez choisir la tuile d'arrivée";
                playerChoose.GetComponent<BluePlayer>().useWindCelestialPower = true;
                playerChoose.GetComponent<BluePlayer>().CheckDistance();
                StartCoroutine(playerChoose.GetComponent<Deplacement>().PlayerDeplacement());
            }
            else if (playerChoose.name == "YellowPlayer")
            {
                infos.text = "Veuillez choisir la tuile d'arrivée";
                playerChoose.GetComponent<YellowPlayer>().useWindCelestialPower = true;
                playerChoose.GetComponent<YellowPlayer>().CheckDistance();
                StartCoroutine(playerChoose.GetComponent<Deplacement>().PlayerDeplacement());
            }
            else if (playerChoose.name == "RedPlayer")
            {
                infos.text = "Veuillez choisir la tuile d'arrivée";
                playerChoose.GetComponent<RedPlayer>().useWindCelestialPower = true;
                playerChoose.GetComponent<RedPlayer>().CheckDistance();
                StartCoroutine(playerChoose.GetComponent<Deplacement>().PlayerDeplacement());
            }
            else if (playerChoose.name == "GreenPlayer")
            {
                infos.text = "Veuillez choisir la tuile d'arrivée";
                playerChoose.GetComponent<GreenPlayer>().useWindCelestialPower = true;
                playerChoose.GetComponent<GreenPlayer>().CheckDistance();
                StartCoroutine(playerChoose.GetComponent<Deplacement>().PlayerDeplacement());
            }
            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<BluePlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                isActiveTilePower = false;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<YellowPlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                isActiveTilePower = false;
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
                player.GetComponent<RedPlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                isActiveTilePower = false;
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().canLaunchDice = true;
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;
                player.GetComponent<GreenPlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                isActiveTilePower = false;
            }
            gm.cantPause = false;
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activer son pouvoir";
            infos.gameObject.SetActive(true);
            isActiveTilePower = false;
            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<BluePlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<YellowPlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
                player.GetComponent<RedPlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().canLaunchDice = true;
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;
                player.GetComponent<GreenPlayer>().textInfoPhase.gameObject.SetActive(true);
                player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
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

    public void getPlayer(GameObject player)
    {
        playerChoose = player;
        choosePlayer = true;
    }

    public void MustChooseGhostToMove(Button buttonClick)
    {
        chooseenGhost = buttonClick.name;
        if (isActiveTilePower && !oneTime)
        {
            switch (chooseenGhost)
            {
                case "BlueOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne;
                    }
                    break;
                case "BlueTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo;
                    }
                    break;
                case "BlueThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree;
                    }
                    break;
                case "RedOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne;
                    }
                    break;
                case "RedTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo;
                    }
                    break;
                case "RedThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree;
                    }
                    break;
                case "GreenOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne;
                    }
                    break;
                case "GreenTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo;
                    }
                    break;
                case "GreenThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree;
                    }
                    break;
                case "YellowOne":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne;
                    }
                    break;
                case "YellowTwo":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(4).gameObject;
                        oneTime = true;
                        previousPosition = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo;
                    }
                    break;
                case "YellowThree":
                    if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount > 4)
                    {
                        ghostToMove = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.GetChild(4).gameObject;
                        oneTime = true;
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
                if (ghostToMove.GetComponent<Ghost>().canBeKillByBouddha)
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
                    bouddhisteTemple.GetComponent<BouddhisteTemple>().numberOfBouddha += 1;
                    bouddha.transform.parent = bouddhisteTemple.transform;
                    bouddha.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    bouddha.SetActive(false);
                    bouddha = null;
                    ghostToMove.transform.parent.GetComponent<BoxCollider>().enabled = true;
                    ghostToMove.GetComponent<GhostPower>().startPosition = ghostToMove.transform.parent.GetChild(1);
                    ghostToMove.GetComponent<GhostPower>().middlePosition = ghostToMove.transform.parent.GetChild(2);
                    ghostToMove.GetComponent<GhostPower>().endPosition = ghostToMove.transform.parent.GetChild(3);
                    if (namePositionGhost == "One")
                    {
                        hauntingGhostToMove.transform.parent = ghostToMove.GetComponent<GhostPower>().startPosition;
                        hauntingGhostToMove.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                    }
                    else if (namePositionGhost == "Two")
                    {
                        hauntingGhostToMove.transform.parent = ghostToMove.GetComponent<GhostPower>().middlePosition;
                        hauntingGhostToMove.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
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
                    hauntingGhostToMove.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
                }
                else if (namePositionGhost == "Two")
                {
                    hauntingGhostToMove.transform.parent = ghostToMove.GetComponent<GhostPower>().middlePosition;
                    hauntingGhostToMove.transform.localPosition = new Vector3(0.0f, 200.0f, 0.0f);
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
            if (ghostToMove.name == "Uncatchable(Clone)")
            {
                ghostToMove.GetComponent<GhostPower>().UninsensibleWithBouddha();
            }
        }
    }

    public void CheckBoard(GameObject player)
    {
        if (player.name == "BluePlayer")
        {
            panelBoardPlayer.transform.GetChild(1).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(2).GetComponent<Button>().interactable = false;
            panelBoardPlayer.transform.GetChild(3).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(4).GetComponent<Button>().interactable = true;
        }
        else if (player.name == "YellowPlayer")
        {
            panelBoardPlayer.transform.GetChild(1).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(2).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(3).GetComponent<Button>().interactable = false;
            panelBoardPlayer.transform.GetChild(4).GetComponent<Button>().interactable = true;
        }
        else if (player.name == "RedPlayer")
        {
            panelBoardPlayer.transform.GetChild(1).GetComponent<Button>().interactable = false;
            panelBoardPlayer.transform.GetChild(2).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(3).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(4).GetComponent<Button>().interactable = true;
        }
        else if (player.name == "GreenPlayer")
        {
            panelBoardPlayer.transform.GetChild(1).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(2).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(3).GetComponent<Button>().interactable = true;
            panelBoardPlayer.transform.GetChild(4).GetComponent<Button>().interactable = false;
        }
    }
}
