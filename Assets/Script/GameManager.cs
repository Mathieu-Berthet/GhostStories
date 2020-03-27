using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public StockOfToken tokenStock;

    public Vector3 positionPlateau1;
    public Vector3 rotationPlateau1;

    public Vector3 positionPlateau2;
    public Vector3 rotationPlateau2;

    public Vector3 positionPlateau3;
    public Vector3 rotationPlateau3;

    public Vector3 positionPlateau4;
    public Vector3 rotationPlateau4;

    public Vector3 scalePlateau;


    public GameObject test;
    public GameObject test2;
    public GameObject test3;
    public GameObject test4;

    public Vector3 positionCamera1;
    public Vector3 positionCamera2;
    public Vector3 positionCamera3;
    public Vector3 positionCamera4;

    public Vector3 rotationCamera1;
    public Vector3 rotationCamera2;
    public Vector3 rotationCamera3;
    public Vector3 rotationCamera4;

    public Camera mainCamera;
    public bool canLerp;

    public float speed = 1.5f;
    public float startTime;
    public float actualTime;
    public int turn;
    public bool nextPlayer;

    public boardColor blueBoard;
    public boardColor redBoard;
    public boardColor greenBoard;
    public boardColor yellowBoard;

    public int nbDice;
    public int nbCardOnDeck;
    public int nbCardOnBossDeck;
    public bool canUseTaoToken;
    public bool cantTransformWhiteFace;

    public GameObject panelButtonChoice;
    public GameObject panelAwardChoice;

    public string choseenToken;
    public bool choose;

    public string choseenAward;
    public bool chooseAward;

    public Text textEntry;
    public Text textInGame;
    public Text textDeath;

    public Text textPlayerTurn;

    public GameObject bluePlayer;
    public GameObject yellowPlayer;
    public GameObject greenPlayer;
    public GameObject redPlayer;

    //Enum game phase

    //Enum player turn
    public enum STATE_PLAYER_TURN
    {
        BLUE_PLAYER_TURN = 0,
        YELLOW_PLAYER_TURN = 1,
        GREEN_PLAYER_TURN = 2,
        RED_PLAYER_TURN = 3
    }
    //Ordre prédéfini pour l'instant. A voir par la suite

    public enum STATE_GAME
    {
        STATE_GHOSTPOWER = 0,
        STATE_DRAW = 1,
        STATE_MOVE = 2,
        STATE_PLAYER = 3
    }

    public STATE_GAME state;
    public STATE_PLAYER_TURN turnPlayer;

    // Use this for initialization
    void Start ()
    {
        //startTime = Time.time;
        canUseTaoToken = true;
        nbDice = 3;
        nbCardOnDeck = 55;
        nbCardOnBossDeck = 10;
        turn = 1;

        turnPlayer = STATE_PLAYER_TURN.BLUE_PLAYER_TURN;

        textEntry.text = "";
        textInGame.text = "";
        textDeath.text = "";

        nextPlayer = false;
        canLerp = false;
        scalePlateau = new Vector3(3.0f, 0.03f, 2.0f);

        positionPlateau1 = new Vector3(4.0f, 0.0f, 1.5f);
        rotationPlateau1 = new Vector3(0.0f, 90.0f, 0.0f);

        positionPlateau2 = new Vector3(1.5f, 0.0f, -1.0f);
        rotationPlateau2 = new Vector3(0.0f, 180.0f, 0.0f);

        positionPlateau3 = new Vector3(-1.0f, 0.0f, 1.5f);
        rotationPlateau3 = new Vector3(0.0f, -90.0f, 0.0f);

        positionPlateau4 = new Vector3(1.5f, 0.0f, 4.0f);
        rotationPlateau4 = new Vector3(0.0f, 0.0f, 0.0f);

        positionCamera1 = new Vector3(1.5f, 3.65f, -2.4f);
        rotationCamera1 = new Vector3(55.0f, 0.0f, 0.0f);

        positionCamera2 = new Vector3(-2.4f, 3.65f, 1.5f);
        rotationCamera2 = new Vector3(55.0f, 90.0f, 0.0f);

        positionCamera3 = new Vector3(1.5f, 3.65f, 5.4f);
        rotationCamera3 = new Vector3(55.0f, 180.0f, 0.0f);

        positionCamera4 = new Vector3(5.4f, 3.65f, 1.5f);
        rotationCamera4 = new Vector3(55.0f, 270.0f, 0.0f);

        redBoard = GameObject.Find("PlateauJoueurRouge").GetComponent<boardColor>();
        blueBoard = GameObject.Find("PlateauJoueurBleu").GetComponent<boardColor>();
        greenBoard = GameObject.Find("PlateauJoueurVert").GetComponent<boardColor>();
        yellowBoard = GameObject.Find("PlateauJoueurJaune").GetComponent<boardColor>();
        tokenStock = GameObject.Find("TokenStock").GetComponent<StockOfToken>();

    }

    // Update is called once per frame
    void Update ()
    {
        if(turnPlayer == STATE_PLAYER_TURN.BLUE_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR BLEU";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = true;
            bluePlayer.GetComponent<BluePlayer>().CheckDistance();
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = false;
            //bluePlayer.GetComponent<GreenPlayer>().greenTurn = false;
            //bluePlayer.GetComponent<RedPlayer>().redTurn = false;
        }
        else if(turnPlayer == STATE_PLAYER_TURN.YELLOW_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR JAUNE";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = false;
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = true;
            yellowPlayer.GetComponent<YellowPlayer>().CheckDistance();
            //bluePlayer.GetComponent<GreenPlayer>().greenTurn = false;
            //bluePlayer.GetComponent<RedPlayer>().redTurn = false;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.GREEN_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR VERT";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = false;
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = false;
            //bluePlayer.GetComponent<GreenPlayer>().greenTurn = true;
            //bluePlayer.GetComponent<RedPlayer>().redTurn = false;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.RED_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR ROUGE";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = false;
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = false;
            //bluePlayer.GetComponent<GreenPlayer>().greenTurn = false;
            //bluePlayer.GetComponent<RedPlayer>().redTurn = true;
        }
        if((int)turnPlayer > 3)
        {
            turnPlayer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject go = Instantiate(test);
            go.transform.eulerAngles = rotationPlateau1;
            go.transform.position = positionPlateau1;
            go.transform.localScale = scalePlateau;

            GameObject go2 = Instantiate(test2);
            go2.transform.eulerAngles = rotationPlateau2;
            go2.transform.position = positionPlateau2;
            go2.transform.localScale = scalePlateau;

            GameObject go3 = Instantiate(test3);
            go3.transform.eulerAngles = rotationPlateau3;
            go3.transform.position = positionPlateau3;
            go3.transform.localScale = scalePlateau;

            GameObject go4 = Instantiate(test4);
            go4.transform.eulerAngles = rotationPlateau4;
            go4.transform.position = positionPlateau4;
            go4.transform.localScale = scalePlateau;
        }

        if (turn == 1 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera4, positionCamera1, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera4, rotationCamera1, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera1;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }

        if (turn == 2 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera1, positionCamera2, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera1, rotationCamera2, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera2;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }

        if (turn == 3 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera2, positionCamera3, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera2, rotationCamera3, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera2;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }

        if (turn == 4 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera3, positionCamera4, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera3, rotationCamera4, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera2;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }
    }

    public void nextTurn()
    {
        nextPlayer = true;
        canLerp = true;
        if(nextPlayer)
        {
            turn++;
            if(turn > 4)
            {
                turn = 1;
            }

            /*if(turn == 1)
            {
                //mainCamera.transform.position = Vector3.Lerp(positionCamera1, positionCamera2, newTime);
                mainCamera.transform.position = positionCamera1;
                mainCamera.transform.eulerAngles = rotationCamera1;
            }

            if (turn == 2)
            {
                //mainCamera.transform.position = Vector3.Slerp(positionCamera1, positionCamera2, 1.0f);
                mainCamera.transform.position = positionCamera2;
                //mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera1, rotationCamera2, 0.5f);
                mainCamera.transform.eulerAngles = rotationCamera2;
            }

            if (turn == 3)
            {
                mainCamera.transform.position = positionCamera3;
                mainCamera.transform.eulerAngles = rotationCamera3;
            }

            if (turn == 4)
            {
                mainCamera.transform.position = positionCamera4;
                mainCamera.transform.eulerAngles = rotationCamera4;
            }*/
        }
        nextPlayer = false;
    }


    public void MustChooseToken(Button buttonClick)
    {
        choseenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
    }

    public void MustChooseAward(Button buttonClick)
    {
        choseenAward = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        chooseAward = true;
    }


    public void PowerGhostInformation(GameObject ghost)
    {
        textEntry.text = "";
        textInGame.text = "";
        textDeath.text = "";
        if (ghost.GetComponent<Ghost>().entryPower)
        {
            if(ghost.GetComponent<Ghost>().hasLaunchBlackDiceEntryPower)
            {
                textEntry.text += "- Lancez le dé noir lorsque le fantôme rentre en jeu \n";
            }
            if(ghost.GetComponent<Ghost>().hasCantUseTokenPower)
            {
                textEntry.text += "- Les jetons sont inutilisables pendant que le fantôme est vivant \n";
            }
            if(ghost.GetComponent<Ghost>().hasCaptureDicePower)
            {
                textEntry.text += "- Vous perdez un dé \n";
            }
            if(ghost.GetComponent<Ghost>().hasDrawAGhostPower)
            {
                textEntry.text += "- Piochez un nouveau fantôme juste après avoir posé celui ci \n";
            }
            if(ghost.GetComponent<Ghost>().hasCantUsePowerPower)
            {
                textEntry.text += "- Bloque le pouvoir du plateau ou est posé le fantôme \n";
            }
            if(ghost.GetComponent<Ghost>().hasLoseLifePower)
            {
                textEntry.text += "- Vous perdez un QI \n";
            }
            if(ghost.GetComponent<Ghost>().hasHauntedGhostAdvancedPower)
            {
                textEntry.text += "- Le fantôme hanteur entre avancé d'une case supplémentaire \n";
            }
            if(ghost.GetComponent<Ghost>().hasHauntedTilePower)
            {
                textEntry.text += "- Le fantôme hante directement la première tuile devant lui \n";
            }
        }

        if(ghost.GetComponent<Ghost>().inGamePower)
        {
            if(ghost.GetComponent<Ghost>().hasHauntedGhostPower)
            {
                textInGame.text += "- Le fantôme hanteur apparait sur la carte \n";
            }
            if(ghost.GetComponent<Ghost>().hasLaunchBlackDiceInGamePower)
            {
                textInGame.text += "- Lancez le dé noir à chaque tour \n";
            }
            if(ghost.GetComponent<Ghost>().hasInsensiblePower)
            {
                textInGame.text += "- Le fantôme est insensible aux dés \n";
            }
        }

        if(ghost.GetComponent<Ghost>().deathPower)
        {
            if(ghost.GetComponent<Ghost>().hasWinQiOrYinYangTokenPower)
            {
                textDeath.text += "- A la mort du fantôme, récupérer un QI ou votre jeton Yin Yang \n";
            }
            if(ghost.GetComponent<Ghost>().hasWinTAOTokenPower)
            {
                textDeath.text += "- A la mort du fantôme, récupérer un jeton de votre choix \n";
            }
            if(ghost.GetComponent<Ghost>().hasWinQiAndYinYangPower)
            {
                textDeath.text += "- A la mort du fantôme, récupérer un QI et votre jeton Yin Yang \n";
            }
            if(ghost.GetComponent<Ghost>().hasWinTwoTAOTokenPower)
            {
                textDeath.text += "- A la mort du fantôme, récupérer 2 jetons de votre choix \n";
            }
            if(ghost.GetComponent<Ghost>().hasLaunchBlackDiceDeathPower)
            {
                textDeath.text += "- A la mort du fantôme, lancez le dé noir \n";
            }
        }
    }
}
