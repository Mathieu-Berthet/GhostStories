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

    public GameObject panelOne;
    public GameObject panelTwo;
    public GameObject panelThree;
    public GameObject panelFour;

    public Vector3 temporaryPosition;
    public Vector3 temporaryScale;

    public Vector3 temporaryPositionButtonOne;
    public Vector3 temporaryScaleButtonOne;

    public Vector3 temporaryPositionButtonTwo;
    public Vector3 temporaryScaleButtonTwo;

    public Vector3 temporaryPositionButtonThree;
    public Vector3 temporaryScaleButtonThree;

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
    public bool cantPause;
    public bool cantPlay;

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

    public Camera cam;
    public Image drawedCard;
    public GameObject panelInfoGhostPower;

    public AudioManager audio;
    public float timerCri;

    public GameObject cubeGetTileName;
    public string nightTowerTileName;
    public string priestCircleTileName;
    public string bouddhistTempleTileName;
    public string taoisteAutelTileName;
    public string graveyardTileName;
    public string windCelestialFlagTileName;
    public string herbalistStallTileName;
    public string hutOfWitchTileName;
    public string houseOfTeaTileName;


    public Button nightTowerForDeplacement;
    public Button priestCircleForDeplacement;
    public Button bouddhisteTempleForDeplacement;

    public Button taoisteAutelForDeplacement;
    public Button graveyardForDeplacement;
    public Button windCelestialFlagForDeplacement;

    public Button herbalistStallForDeplacement;
    public Button hutOfWitchForDeplacement;
    public Button houseOfTeaForDeplacement;



    public Button nightTowerForHaunt;
    public Button priestCircleForHaunt;
    public Button bouddhisteTempleForHaunt;
    
    public Button taoisteAutelForHaunt;
    public Button graveyardForHaunt;
    public Button windCelestialFlagForHaunt;

    public Button herbalistStallForHaunt;
    public Button hutOfWitchForHaunt;
    public Button houseOfTeaForHaunt;


    [Header("Les faces")]
    public Image FaceRouge;
    public Image FaceBleue;
    public Image FaceVerte;
    public Image FaceJaune;
    public Image FaceNoire;
    public Image FaceBlanche;
    public Image FaceDeNoir;

    public Text textNbWhiteFace;
    public Text textNbRedFace;
    public Text textNbBlueFace;
    public Text textNbGreenFace;
    public Text textNbYellowFace;
    public Text textNbBlackFace;
    public Text textBlackDiceFace;

    //Enum game phase

    //Enum player turn
    public enum STATE_PLAYER_TURN
    {
        BLUE_PLAYER_TURN = 0,
        YELLOW_PLAYER_TURN = 1,
        RED_PLAYER_TURN = 2,
        GREEN_PLAYER_TURN = 3
        
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
        GetTile();

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

        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update ()
    {
        //GetTile();
        timerCri += Time.deltaTime;
        if(timerCri >= 15.0f)
        {
            timerCri = 0.0f;
            audio.PlayCri();
        }
        if ((int)turnPlayer > 3)
        {
            turnPlayer = 0;
        }
        if (turnPlayer == STATE_PLAYER_TURN.BLUE_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR BLEU";
            greenPlayer.GetComponent<GreenPlayer>().greenTurn = false;
            bluePlayer.GetComponent<BluePlayer>().blueTurn = true;
            bluePlayer.GetComponent<BluePlayer>().update = true;
            bluePlayer.GetComponent<Players>().colorPlayer = "blue";
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = false;
            redPlayer.GetComponent<RedPlayer>().redTurn = false;
            NameDeplacementButton();
            NameTileButton();
        }
        else if (turnPlayer == STATE_PLAYER_TURN.YELLOW_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR JAUNE";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = false;
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = true;
            yellowPlayer.GetComponent<YellowPlayer>().update = true;
            yellowPlayer.GetComponent<Players>().colorPlayer = "yellow";
            greenPlayer.GetComponent<GreenPlayer>().greenTurn = false;
            redPlayer.GetComponent<RedPlayer>().redTurn = false;
            NameDeplacementButton();
            NameTileButton();
        }
        else if (turnPlayer == STATE_PLAYER_TURN.RED_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR ROUGE";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = false;
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = false;
            greenPlayer.GetComponent<GreenPlayer>().greenTurn = false;
            redPlayer.GetComponent<RedPlayer>().redTurn = true;
            redPlayer.GetComponent<RedPlayer>().update = true;
            redPlayer.GetComponent<Players>().colorPlayer = "red";
            NameDeplacementButton();
            NameTileButton();
        }
        else if (turnPlayer == STATE_PLAYER_TURN.GREEN_PLAYER_TURN)
        {
            textPlayerTurn.text = "TOUR DU JOUEUR VERT";
            bluePlayer.GetComponent<BluePlayer>().blueTurn = false;
            yellowPlayer.GetComponent<YellowPlayer>().yellowTurn = false;
            redPlayer.GetComponent<RedPlayer>().redTurn = false;
            greenPlayer.GetComponent<GreenPlayer>().greenTurn = true;
            greenPlayer.GetComponent<GreenPlayer>().update = true;
            greenPlayer.GetComponent<Players>().colorPlayer = "green";
            NameDeplacementButton();
            NameTileButton();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            /*GameObject go = Instantiate(test);
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
            go4.transform.localScale = scalePlateau;*/
            //nextTurn();
        }

        if (turn == 1 && canLerp)
        {
            rotationCamera4 = new Vector3(55.0f, -90.0f, 0.0f);
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera4, positionCamera1, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera4, rotationCamera1, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera1;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
                rotationCamera4 = new Vector3(55.0f, 270.0f, 0.0f);
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

        RaycastHit hitt;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (state == STATE_GAME.STATE_PLAYER && Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitt))
            {
                //tileName = hitt.transform.gameObject.name;
                if (hitt.collider.gameObject.name == "CaseFantomeBleu1" || hitt.collider.gameObject.name == "CaseFantomeBleu2" || hitt.collider.gameObject.name == "CaseFantomeBleu3"
                    || hitt.collider.gameObject.name == "CaseFantomeRouge1" || hitt.collider.gameObject.name == "CaseFantomeRouge2" || hitt.collider.gameObject.name == "CaseFantomeRouge3"
                    || hitt.collider.gameObject.name == "CaseFantomeVert1" || hitt.collider.gameObject.name == "CaseFantomeVert2" || hitt.collider.gameObject.name == "CaseFantomeVert3"
                    || hitt.collider.gameObject.name == "CaseFantomeJaune1" || hitt.collider.gameObject.name == "CaseFantomeJaune2" || hitt.collider.gameObject.name == "CaseFantomeJaune3")
                {
                    if (hitt.collider.gameObject.transform.childCount == 5)
                    {
                        if (!hitt.collider.gameObject.transform.GetChild(4).name.Contains("Bouddha"))
                        {
                            GameObject cardGhost = hitt.collider.gameObject.transform.GetChild(4).gameObject;
                            PowerGhostInformation(cardGhost);
                            drawedCard.sprite = cardGhost.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                            drawedCard.gameObject.SetActive(true);
                            panelInfoGhostPower.SetActive(true);
                        }
                    }
                }
                else
                {
                    drawedCard.gameObject.SetActive(false);
                    panelInfoGhostPower.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void nextTurn()
    {
        if (turnPlayer == STATE_PLAYER_TURN.BLUE_PLAYER_TURN)
        {
            bluePlayer.GetComponent<BluePlayer>().alreadyMove = false;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.YELLOW_PLAYER_TURN)
        {
            yellowPlayer.GetComponent<YellowPlayer>().alreadyMove = false;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.RED_PLAYER_TURN)
        {
            redPlayer.GetComponent<RedPlayer>().alreadyMove = false;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.GREEN_PLAYER_TURN)
        {
            greenPlayer.GetComponent<GreenPlayer>().alreadyMove = false;
        }

        temporaryPosition = panelOne.transform.position;
        temporaryScale = panelOne.transform.localScale;
        temporaryPositionButtonOne = panelOne.transform.GetChild(0).transform.position;
        temporaryScaleButtonOne = panelOne.transform.GetChild(0).transform.localScale;
        temporaryPositionButtonTwo = panelOne.transform.GetChild(1).transform.position;
        temporaryScaleButtonTwo = panelOne.transform.GetChild(1).transform.localScale;
        temporaryPositionButtonThree = panelOne.transform.GetChild(2).transform.position;
        temporaryScaleButtonThree = panelOne.transform.GetChild(2).transform.localScale;

        panelOne.transform.position = panelFour.transform.position;
        panelOne.transform.localScale = panelFour.transform.localScale;
        panelOne.transform.GetChild(0).transform.position = panelFour.transform.GetChild(0).transform.position;
        panelOne.transform.GetChild(0).transform.localScale = panelFour.transform.GetChild(0).transform.localScale;
        panelOne.transform.GetChild(1).transform.position = panelFour.transform.GetChild(1).transform.position;
        panelOne.transform.GetChild(1).transform.localScale = panelFour.transform.GetChild(1).transform.localScale;
        panelOne.transform.GetChild(2).transform.position = panelFour.transform.GetChild(2).transform.position;
        panelOne.transform.GetChild(2).transform.localScale = panelFour.transform.GetChild(2).transform.localScale;

        panelFour.transform.position = panelThree.transform.position;
        panelFour.transform.localScale = panelThree.transform.localScale;
        panelFour.transform.GetChild(0).transform.position = panelThree.transform.GetChild(0).transform.position;
        panelFour.transform.GetChild(0).transform.localScale = panelThree.transform.GetChild(0).transform.localScale;
        panelFour.transform.GetChild(1).transform.position = panelThree.transform.GetChild(1).transform.position;
        panelFour.transform.GetChild(1).transform.localScale = panelThree.transform.GetChild(1).transform.localScale;
        panelFour.transform.GetChild(2).transform.position = panelThree.transform.GetChild(2).transform.position;
        panelFour.transform.GetChild(2).transform.localScale = panelThree.transform.GetChild(2).transform.localScale;

        panelThree.transform.position = panelTwo.transform.position;
        panelThree.transform.localScale = panelTwo.transform.localScale;
        panelThree.transform.GetChild(0).transform.position = panelTwo.transform.GetChild(0).transform.position;
        panelThree.transform.GetChild(0).transform.localScale = panelTwo.transform.GetChild(0).transform.localScale;
        panelThree.transform.GetChild(1).transform.position = panelTwo.transform.GetChild(1).transform.position;
        panelThree.transform.GetChild(1).transform.localScale = panelTwo.transform.GetChild(1).transform.localScale;
        panelThree.transform.GetChild(2).transform.position = panelTwo.transform.GetChild(2).transform.position;
        panelThree.transform.GetChild(2).transform.localScale = panelTwo.transform.GetChild(2).transform.localScale;

        panelTwo.transform.position = temporaryPosition;
        panelTwo.transform.localScale = temporaryScale;
        panelTwo.transform.GetChild(0).transform.position = temporaryPositionButtonOne;
        panelTwo.transform.GetChild(0).transform.localScale = temporaryScaleButtonOne;
        panelTwo.transform.GetChild(1).transform.position = temporaryPositionButtonTwo;
        panelTwo.transform.GetChild(1).transform.localScale = temporaryScaleButtonTwo;
        panelTwo.transform.GetChild(2).transform.position = temporaryPositionButtonThree;
        panelTwo.transform.GetChild(2).transform.localScale = temporaryScaleButtonThree;

        nextPlayer = true;
        canLerp = true;
        if(nextPlayer)
        {
            //turn++;
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

    public void RegainMantraToken()
    {
        yellowPlayer.GetComponent<YellowPlayer>().NbMantraToken += 1;
        yellowPlayer.GetComponent<YellowPlayer>().ghostToWeakned = null;
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


    public void GetTile()
    {
        RaycastHit hitTile;
        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.forward + Vector3.right, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.forward + Vector3.right);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.forward + Vector3.left, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.forward + Vector3.left);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.back + Vector3.right, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.back + Vector3.right);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.back + Vector3.left, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.back + Vector3.left);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.back, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.back);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.left, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.left);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.forward, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.forward);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down + Vector3.right, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down + Vector3.right);
            GetTileName(hitTile.collider.gameObject.name);
        }

        if (Physics.Raycast(cubeGetTileName.transform.position, Vector3.down, out hitTile, 100.0f))
        {
            Debug.DrawRay(cubeGetTileName.transform.position, Vector3.down);
            GetTileName(hitTile.collider.gameObject.name);
        }
    }

    public void GetTileName(string tileNameCollide)
    {
        switch(tileNameCollide)
        {
            case "EchoppeHerboriste":
                herbalistStallTileName = "Echoppe de L'herboriste";
                break;
            case "HutteSorciere":
                hutOfWitchTileName = "Hutte de la Sorciere";
                break;
            case "MaisonThe":
                houseOfTeaTileName = "Maison du The";
                break;
            case "AutelTaoiste":
                taoisteAutelTileName = "Autel Taoiste";
                break;
            case "Cimetiere":
                graveyardTileName = "Cimetiere";
                break;
            case "PavillonVentCeleste":
                windCelestialFlagTileName = "Pavillon du Vent Celeste";
                break;
            case "TourVeilleurNuit":
                nightTowerTileName = "Tour du Veilleur de Nuit";
                break;
            case "CerclePriere":
                priestCircleTileName = "Cercle de priere";
                break;
            case "TempleBouddhiste":
                bouddhistTempleTileName = "Temple Bouddhiste";
                break;
            default:
                break;
        }
    }

    public void NameDeplacementButton()
    {
        if (turnPlayer == STATE_PLAYER_TURN.BLUE_PLAYER_TURN)
        {
            nightTowerForDeplacement.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
            priestCircleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            bouddhisteTempleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
            taoisteAutelForDeplacement.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            graveyardForDeplacement.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForDeplacement.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            herbalistStallForDeplacement.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
            hutOfWitchForDeplacement.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            houseOfTeaForDeplacement.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.YELLOW_PLAYER_TURN)
        {
            nightTowerForDeplacement.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
            priestCircleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            bouddhisteTempleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
            taoisteAutelForDeplacement.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            graveyardForDeplacement.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForDeplacement.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            herbalistStallForDeplacement.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
            hutOfWitchForDeplacement.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            houseOfTeaForDeplacement.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.RED_PLAYER_TURN)
        {
            nightTowerForDeplacement.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
            priestCircleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            bouddhisteTempleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
            taoisteAutelForDeplacement.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            graveyardForDeplacement.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForDeplacement.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            herbalistStallForDeplacement.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
            hutOfWitchForDeplacement.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            houseOfTeaForDeplacement.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.GREEN_PLAYER_TURN)
        {
            nightTowerForDeplacement.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
            priestCircleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            bouddhisteTempleForDeplacement.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
            taoisteAutelForDeplacement.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            graveyardForDeplacement.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForDeplacement.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            herbalistStallForDeplacement.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
            hutOfWitchForDeplacement.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            houseOfTeaForDeplacement.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
        }
    }

    public void NameTileButton()
    {
        if (turnPlayer == STATE_PLAYER_TURN.BLUE_PLAYER_TURN)
        {
            nightTowerForHaunt.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
            priestCircleForHaunt.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            bouddhisteTempleForHaunt.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
            taoisteAutelForHaunt.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            graveyardForHaunt.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForHaunt.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            herbalistStallForHaunt.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
            hutOfWitchForHaunt.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            houseOfTeaForHaunt.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.YELLOW_PLAYER_TURN)
        {
            nightTowerForHaunt.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
            priestCircleForHaunt.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            bouddhisteTempleForHaunt.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
            taoisteAutelForHaunt.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            graveyardForHaunt.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForHaunt.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            herbalistStallForHaunt.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
            hutOfWitchForHaunt.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            houseOfTeaForHaunt.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.RED_PLAYER_TURN)
        {
            nightTowerForHaunt.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
            priestCircleForHaunt.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            bouddhisteTempleForHaunt.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
            taoisteAutelForHaunt.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            graveyardForHaunt.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForHaunt.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            herbalistStallForHaunt.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
            hutOfWitchForHaunt.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            houseOfTeaForHaunt.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
        }
        else if (turnPlayer == STATE_PLAYER_TURN.GREEN_PLAYER_TURN)
        {
            nightTowerForHaunt.transform.GetChild(0).GetComponent<Text>().text = herbalistStallTileName;
            priestCircleForHaunt.transform.GetChild(0).GetComponent<Text>().text = taoisteAutelTileName;
            bouddhisteTempleForHaunt.transform.GetChild(0).GetComponent<Text>().text = nightTowerTileName;
            taoisteAutelForHaunt.transform.GetChild(0).GetComponent<Text>().text = hutOfWitchTileName;
            graveyardForHaunt.transform.GetChild(0).GetComponent<Text>().text = graveyardTileName;
            windCelestialFlagForHaunt.transform.GetChild(0).GetComponent<Text>().text = priestCircleTileName;
            herbalistStallForHaunt.transform.GetChild(0).GetComponent<Text>().text = houseOfTeaTileName;
            hutOfWitchForHaunt.transform.GetChild(0).GetComponent<Text>().text = windCelestialFlagTileName;
            houseOfTeaForHaunt.transform.GetChild(0).GetComponent<Text>().text = bouddhistTempleTileName;
        }
    }

    public void ActiveDiceFace()
    {
        FaceRouge.gameObject.SetActive(true);
        FaceBleue.gameObject.SetActive(true);
        FaceVerte.gameObject.SetActive(true);
        FaceJaune.gameObject.SetActive(true);
        FaceNoire.gameObject.SetActive(true);
        FaceBlanche.gameObject.SetActive(true);
        FaceDeNoir.gameObject.SetActive(true);

        textNbRedFace.gameObject.SetActive(true);
        textNbBlueFace.gameObject.SetActive(true);
        textNbGreenFace.gameObject.SetActive(true);
        textNbYellowFace.gameObject.SetActive(true);
        textNbBlackFace.gameObject.SetActive(true);
        textNbWhiteFace.gameObject.SetActive(true);
        textBlackDiceFace.gameObject.SetActive(true);
    }

    public void UnactiveDiceFace()
    {
        FaceRouge.gameObject.SetActive(false);
        FaceBleue.gameObject.SetActive(false);
        FaceVerte.gameObject.SetActive(false);
        FaceJaune.gameObject.SetActive(false);
        FaceNoire.gameObject.SetActive(false);
        FaceBlanche.gameObject.SetActive(false);
        FaceDeNoir.gameObject.SetActive(false);

        textNbRedFace.gameObject.SetActive(false);
        textNbBlueFace.gameObject.SetActive(false);
        textNbGreenFace.gameObject.SetActive(false);
        textNbYellowFace.gameObject.SetActive(false);
        textNbBlackFace.gameObject.SetActive(false);
        textNbWhiteFace.gameObject.SetActive(false);
        textBlackDiceFace.gameObject.SetActive(false);
    }
}
