using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BluePlayer : MonoBehaviour
{
    #region variableJeton
    [SerializeField]
    private int qi = 0; // PV du joueur
    [SerializeField]
    private int nbBlueToken;
    [SerializeField]
    private int nbRedToken;
    [SerializeField]
    private int nbGreenToken;
    [SerializeField]
    private int nbYellowToken;
    [SerializeField]
    private int nbBlackToken;
    [SerializeField]
    private int nbPowerToken; // Pour une partie ou il n'y a pas 4 joueur
    [SerializeField]
    private int nbYinYangBlueToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur
    [SerializeField]
    private int nbBouddha; // Pour les bouddha du temple bouddhiste
    #endregion

    public bool powerSecondSouffle;
    public bool powerSouffleCeleste;

    public bool useTilePower;
    public bool useGhostPower;
    private bool fight;
    public bool canUsePower;

    [SerializeField]
    private GameObject dice;

    private GameObject diceOne;
    private GameObject diceTwo;
    private GameObject diceThree;

    //TODO : Faire remplir ces variables
    public string resultDiceOne;
    public string resultDiceTwo;
    public string resultDiceThree;

    public int nbRedFace;
    public int nbBlueFace;
    public int nbYellowFace;
    public int nbGreenFace;
    public int nbWhiteFace;
    public int nbBlackFace;

    public bool choosePriority;

    [SerializeField]
    private CubeScript cube;

    //Les tuiles
    public GameObject houseOfTea;
    public GameObject graveyard;
    public GameObject bouddhisteTemple;
    public GameObject priestCircle;
    public GameObject taoisteAutel;
    public GameObject herbalistStall;
    public GameObject witchHut;
    public GameObject windCelestialFlag;
    public GameObject nightTower;

    public string tileName;
    public string ghostName;
    public string ghostName2;

    public GameObject ghost1;
    public GameObject ghost2;
    public bool canLaunchDice;
    public bool canLaunchBlackDice;

    [SerializeField]
    private PoolManagerDeck deck;
    [SerializeField]
    public GameObject card;
    public Image drawedCard;
    public BoardPosition board;
    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;

    [SerializeField]
    private GameObject defausse;

    //public BoxCollider boxCollider;

    [SerializeField]
    private bool hasDraw;

    public Text textInfo;
    public string colorPlayer = "blue";

    public GameManager gm;

    public Text textNbTokenBlue;
    public Text textNbTokenRed;
    public Text textNbTokenGreen;
    public Text textNbTokenYellow;
    public Text textNbTokenBlack;
    public Text textNbTokenPower;
    public Text textNbTokenYinYangBlue;
    public Text textNbQI;
    public bool update;

    public GameObject explosion;
    public GameObject explosion2;

    public GameObject panelJeton;
    public Button buttonGhost1;
    public Button buttonGhost2;
    public string priority;

    [SerializeField]
    private GameObject blackDice;
    public GameObject blackDiceOne;
    public string resultFace;

    public Transform bluePosStall;
    public Transform bluePosHouse;
    public Transform bluePosHut;
    public Transform bluePosPavillon;
    public Transform bluePosGraveyard;
    public Transform bluePosAutel;
    public Transform bluePosCircle;
    public Transform bluePosTemple;
    public Transform bluePosTower;

    public Vector3 actualPosition;

    public bool stop;
    /*public NavMeshModifier navMeshEchoppe;
    public NavMeshModifier navMeshHut;
    public NavMeshModifier navMeshHouse;
    public NavMeshModifier navMeshAutel;
    public NavMeshModifier navMeshGraveyard;
    public NavMeshModifier navMeshPavillon;
    public NavMeshModifier navMeshTower;
    public NavMeshModifier navMeshCircle;
    public NavMeshModifier navMeshTemple;*/


    #region accesseurs
    public int Qi
    {
        get
        {
            return qi;
        }

        set
        {
            qi = value;
        }
    }

    public int NbBlueToken
    {
        get
        {
            return nbBlueToken;
        }

        set
        {
            nbBlueToken = value;
        }
    }

    public int NbRedToken
    {
        get
        {
            return nbRedToken;
        }

        set
        {
            nbRedToken = value;
        }
    }

    public int NbGreenToken
    {
        get
        {
            return nbGreenToken;
        }

        set
        {
            nbGreenToken = value;
        }
    }

    public int NbYellowToken
    {
        get
        {
            return nbYellowToken;
        }

        set
        {
            nbYellowToken = value;
        }
    }

    public int NbBlackToken
    {
        get
        {
            return nbBlackToken;
        }

        set
        {
            nbBlackToken = value;
        }
    }

    public int NbPowerToken
    {
        get
        {
            return nbPowerToken;
        }

        set
        {
            nbPowerToken = value;
        }
    }

    public int NbYinYangBlueToken
    {
        get
        {
            return nbYinYangBlueToken;
        }

        set
        {
            nbYinYangBlueToken = value;
        }
    }

    public int NbBouddha
    {
        get
        {
            return nbBouddha;
        }

        set
        {
            nbBouddha = value;
        }
    }
    #endregion

    public enum STATE_GAME
    {
        STATE_GHOSTPOWER = 0,
        STATE_DRAW = 1,
        STATE_MOVE = 2,
        STATE_PLAYER = 3
    }

    public STATE_GAME state;
    public Text textPlayerTurn;
    public Text textInfoPhase;
    public Text textMort;
    public Text textInfoTuile;
    public Text textNbDice;
    public Text textTurn;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Qi = 100;//Test des pouvoirs. Donc faut etre large // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        NbBlueToken = 1;
        NbRedToken = 0;
        NbYellowToken = 0;
        NbGreenToken = 0;
        NbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        NbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        NbYinYangBlueToken = 1; //Max possible.

        hasDraw = false;
        state = STATE_GAME.STATE_DRAW;
        deck = GameObject.Find("Deck").GetComponent<PoolManagerDeck>();
        board = GameObject.Find("Canvas").GetComponent<BoardPosition>();

        canLaunchDice = true;
        canLaunchBlackDice = true;
        useTilePower = false;
        stop = false;
        updateUI();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire2") && !hasDraw)
        {
            DrawAGhost();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Sortie");
            Application.Quit();
        }


        if(Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(gameObject.GetComponent<Deplacement>().PlayerDeplacement());
        }

        RaycastHit hitt;
        if (Physics.Raycast(transform.position, Vector3.down, out hitt, 1.0f))
        {
            tileName = hitt.transform.gameObject.name;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            gm.nextTurn();
        }

        if (Input.GetKeyDown(KeyCode.D) && canLaunchDice)
        {
            StartCoroutine(LaunchDice());
        }

        if(Input.GetKeyDown(KeyCode.E) && canLaunchDice && canLaunchBlackDice)
        {
            UsePowerTile();
        }

        if (update)
        {
            updateUI();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            panelJeton.SetActive(!panelJeton.activeSelf);
        }

        if(state == STATE_GAME.STATE_DRAW)
        {
            textInfoPhase.text = " Phase de pioche : \n\n - Il vous faut piochez une carte fantôme (Clic droit souris)";
        }
        else if(state == STATE_GAME.STATE_MOVE)
        {
            textInfoPhase.text = " Phase de déplacement : \n\n - Veuillez choisir ou vous voulez vous déplacer";
        }
        else if (state == STATE_GAME.STATE_PLAYER)
        {
            textInfoPhase.text = " Phase de jeu, vous pouvez : \n\n - Attaquer un fantome se trouvant devant vous (Touche D), \n - Utilisez le pouvoir de la tuile sur laquelle vous vous trouvez (Touche E)";
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            canLaunchBlackDice = true;
            canLaunchDice = true;
            gameObject.GetComponent<Deplacement>().enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(state == STATE_GAME.STATE_DRAW)
            {
                state = STATE_GAME.STATE_PLAYER;
            }
            else if (state == STATE_GAME.STATE_PLAYER)
            {
                state = STATE_GAME.STATE_DRAW;
            }
        }

        if(state == STATE_GAME.STATE_GHOSTPOWER)
        {
            state = STATE_GAME.STATE_DRAW;
            stop = false;
            ActivateInGameEffect();
        }
        else if(state == STATE_GAME.STATE_MOVE && !stop)
        {
            stop = true;
            StartCoroutine(gameObject.GetComponent<Deplacement>().PlayerDeplacement());
        }

        if(Qi <= 0)
        {
            Qi = 0;
            textMort.text = "Vous êtes mort";
            updateUI();
        }

        checkGhost();
    }
    
    public void DrawAGhost()
    {
        card = null;
        if (state == STATE_GAME.STATE_DRAW || useTilePower || useGhostPower)
        {
            hasDraw = true;
            gameObject.GetComponent<Deplacement>().enabled = false;
            textInfoPhase.gameObject.SetActive(false);
            textInfo.text = " ";
            if (gm.blueBoard.nbCardOnBoard == 3 && gm.redBoard.nbCardOnBoard == 3 && gm.greenBoard.nbCardOnBoard == 3 && gm.yellowBoard.nbCardOnBoard == 3)
            {
                textInfo.gameObject.SetActive(true);
                textInfo.text = "Vous ne pouvez pas piocher un autre fantôme, il y en a trop sur le terrain";
                hasDraw = false;
                gameObject.GetComponent<Deplacement>().enabled = true;
                textInfoPhase.gameObject.SetActive(true);
                state = STATE_GAME.STATE_PLAYER;
                return;
            }
            if (gm.blueBoard.nbCardOnBoard == 3 && !useTilePower)
            {
                textInfo.gameObject.SetActive(true);
                textInfo.text = "Votre plateau est plein de fantômes, vous perdez une vie";
                Qi -= 1;
                update = true;
                hasDraw = false;
                gameObject.GetComponent<Deplacement>().enabled = true;
                textInfoPhase.gameObject.SetActive(true);
                state = STATE_GAME.STATE_PLAYER;
                return;
            }
            panelBluePlace.SetActive(true);
            panelRedPlace.SetActive(true);
            panelGreenPlace.SetActive(true);
            panelYellowPlace.SetActive(true);
            textInfo.gameObject.SetActive(true);
            drawedCard.gameObject.SetActive(true);
            card = deck.GetPoolByName(PoolNameDeck.ghost).GetItem(transform, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, true, false, 0);
            card.transform.parent = null;
            card.transform.position = new Vector3(100.0f, 100.0f, 100.0f);
            card.SetActive(true);
            drawedCard.sprite = card.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void SelectGhostPosition(GameObject position)
    {
        if (state == STATE_GAME.STATE_DRAW || useGhostPower || useTilePower)
        {
            if (card != null)
            {
                if (card.GetComponent<Ghost>().couleur == "black" && position.transform.parent.GetComponent<boardColor>().color != colorPlayer && gm.blueBoard.nbCardOnBoard < 3)
                {
                    textInfo.text = "Les fantômes noirs doivent être posés sur le plateau de votre couleur";
                    return;
                }
                else if (card.GetComponent<Ghost>().couleur != "black" && card.GetComponent<Ghost>().couleur != position.transform.parent.GetComponent<boardColor>().color)
                {
                    if ((card.GetComponent<Ghost>().couleur == "red" && gm.redBoard.nbCardOnBoard < 3) ||
                        (card.GetComponent<Ghost>().couleur == "blue" && gm.blueBoard.nbCardOnBoard < 3) ||
                        (card.GetComponent<Ghost>().couleur == "yellow" && gm.yellowBoard.nbCardOnBoard < 3) ||
                        (card.GetComponent<Ghost>().couleur == "green" && gm.greenBoard.nbCardOnBoard < 3))
                    {
                        textInfo.text = "Vous ne pouvez pas placer le fantôme ici. Il n'est pas de la bonne couleur";
                        return;
                    }
                }
                card.transform.SetParent(position.transform);
                card.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                card.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 180.0f);
                card.transform.localScale = new Vector3(15.0f, 10.0f, 1);
                card.SetActive(true);
                card.transform.parent.GetComponent<BoxCollider>().enabled = true;
                card.GetComponent<GhostPower>().startPosition = card.transform.parent.GetChild(1);
                card.GetComponent<GhostPower>().middlePosition = card.transform.parent.GetChild(2);
                card.GetComponent<GhostPower>().endPosition = card.transform.parent.GetChild(3);
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
                textInfo.gameObject.SetActive(false);
                drawedCard.gameObject.SetActive(false);
                gameObject.GetComponent<Deplacement>().enabled = true;
                textInfoPhase.gameObject.SetActive(true);
                useTilePower = false;
                canLaunchBlackDice = true;
                hasDraw = false;
                if (card.GetComponent<Ghost>().entryPower)
                {
                    if (card.GetComponent<Ghost>().hasDrawAGhostPower)
                    {
                        useGhostPower = true;
                    }
                    card.GetComponent<Ghost>().UseEntryPower(gameObject);
                }
            }
            if (state == STATE_GAME.STATE_DRAW)
            {
                state = STATE_GAME.STATE_MOVE;
            }
        }
    }

    public void SecondSouffle()
    {
        if(useTilePower)
        {
            //Relancer la fonction de la tuile en question
        }
        else if (fight)
        {
            //LaunchDice(); // Relancer les dès pour un 2e combat
        }
    }

    public void SouffleCeleste()
    {

    }

    public void UsePowerTile()
    {
        textInfo.gameObject.SetActive(false);
        useGhostPower = false;
        if (state == STATE_GAME.STATE_PLAYER)
        {
            useTilePower = true;
            switch (tileName)
            {
                case "MaisonThe":
                    Debug.Log("Maison du Thé");
                    textInfoTuile.text = "Maison du Thé";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(houseOfTea.GetComponent<HouseOfTea>().GainTokenAndQI(gameObject));
                    break;
                case "HutteSorciere":
                    Debug.Log("Hutte de la sorcière");
                    textInfoTuile.text = "Hutte de la sorcière";
                    card = null;
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(witchHut.GetComponent<HutOfWitch>().KillGhost(gameObject));
                    break;
                case "EchoppeHerboriste":
                    Debug.Log("Echoppe de l'herboriste");
                    textInfoTuile.text = "Echoppe de l'herboriste";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(herbalistStall.GetComponent<StallOfHerbalist>().getToken(gameObject));
                    break;
                case "AutelTaoiste":
                    Debug.Log("Autel Taoiste");
                    textInfoTuile.text = "Autel Taoiste";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(taoisteAutel.GetComponent<TaoisteAutel>().UnhauntTile(gameObject));
                    break;
                case "Cimetiere":
                    Debug.Log("Le cimetière");
                    textInfoTuile.text = "Le cimetière";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    graveyard.GetComponent<Graveyard>().Resurrect(gameObject);
                    break;
                case "PavillonVentCeleste":
                    Debug.Log("Le pavillon du vent celeste");
                    textInfoTuile.text = "Cette tuile n'as pas encore d'effet";
                    //windCelestialFlag.GetComponent<WindCelestialFlag>().MovePlayerAndGhost();
                    break;
                case "TourVeilleurNuit":
                    Debug.Log("Tour du veilleur de nuit");
                    textInfoTuile.text = "Tour du veilleur de nuit";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(nightTower.GetComponent<NightTower>().RetreatGhost(gameObject));
                    break;
                case "CerclePriere":
                    Debug.Log("Le cercle de prière");
                    textInfoTuile.text = "Le cercle de prière";
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    StartCoroutine(priestCircle.GetComponent<PriestCircle>().reduceGhostLife(gameObject));
                    break;
                case "TempleBouddhiste":
                    Debug.Log("Temple Bouddhiste");
                    textInfoTuile.text = "Cette tuile n'as pas encore d'effet";
                    //bouddhisteTemple.GetComponent<BouddhisteTemple>().getBouddha();
                    break;
                default:
                    break;
            }
        }
    }

    public IEnumerator LaunchDice()
    {
        useGhostPower = false; // A Voir si utile
        textInfo.gameObject.SetActive(false);
        gm.choose = false;
        gameObject.GetComponent<Deplacement>().enabled = false;
        if (state == STATE_GAME.STATE_PLAYER)
        {
            canLaunchDice = false;
            nbRedFace = 0;
            nbBlueFace = 0;
            nbBlackFace = 0;
            nbWhiteFace = 0;
            nbGreenFace = 0;
            nbYellowFace = 0;

            for (int i = 0; i < gm.nbDice; i++)
            {
                GameObject go = Instantiate(dice, new Vector3(i, 2, 0), Quaternion.identity);
                go.AddComponent<CubeScript>();
                cube = go.GetComponent<CubeScript>();
                if (i == 0)
                {
                    diceOne = go;
                }
                else if (i == 1)
                {
                    diceTwo = go;
                }
                else if (i == 2)
                {
                    diceThree = go;
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    cube.rb.AddForce(hit.point * cube.force);
                }
            }
            yield return new WaitForSeconds(5.0f);
            if (diceOne != null)
            {
                resultDiceOne = diceOne.GetComponent<CubeScript>().face;
                switch (resultDiceOne)
                {
                    case "RedFace":
                        nbRedFace++;
                        Destroy(diceOne);
                        break;
                    case "BlueFace":
                        nbBlueFace++;
                        Destroy(diceOne);
                        break;
                    case "YellowFace":
                        nbYellowFace++;
                        Destroy(diceOne);
                        break;
                    case "GreenFace":
                        nbGreenFace++;
                        Destroy(diceOne);
                        break;
                    case "WhiteFace":
                        nbWhiteFace++;
                        Destroy(diceOne);
                        break;
                    case "BlackFace":
                        nbBlackFace++;
                        Destroy(diceOne);
                        break;
                    default:
                        break;
                }
            }
            if (diceTwo != null)
            {
                resultDiceTwo = diceTwo.GetComponent<CubeScript>().face;
                switch (resultDiceTwo)
                {
                    case "RedFace":
                        nbRedFace++;
                        Destroy(diceTwo);
                        break;
                    case "BlueFace":
                        nbBlueFace++;
                        Destroy(diceTwo);
                        break;
                    case "YellowFace":
                        nbYellowFace++;
                        Destroy(diceTwo);
                        break;
                    case "GreenFace":
                        nbGreenFace++;
                        Destroy(diceTwo);
                        break;
                    case "WhiteFace":
                        nbWhiteFace++;
                        Destroy(diceTwo);
                        break;
                    case "BlackFace":
                        nbBlackFace++;
                        Destroy(diceTwo);
                        break;
                    default:
                        break;
                }
            }
            if (diceThree != null)
            {
                resultDiceThree = diceThree.GetComponent<CubeScript>().face;
                switch (resultDiceThree)
                {
                    case "RedFace":
                        nbRedFace++;
                        Destroy(diceThree);
                        break;
                    case "BlueFace":
                        nbBlueFace++;
                        Destroy(diceThree);
                        break;
                    case "YellowFace":
                        nbYellowFace++;
                        Destroy(diceThree);
                        break;
                    case "GreenFace":
                        nbGreenFace++;
                        Destroy(diceThree);
                        break;
                    case "WhiteFace":
                        nbWhiteFace++;
                        Destroy(diceThree);
                        break;
                    case "BlackFace":
                        nbBlackFace++;
                        Destroy(diceThree);
                        break;
                    default:
                        break;
                }
            }

            yield return new WaitForSeconds(2.0f);
            if (!gm.cantTransformWhiteFace)
            {
                while (nbWhiteFace > 0)
                {
                    gm.panelButtonChoice.SetActive(true);
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    while (!gm.choose)
                    {
                        yield return new WaitForSeconds(2.0f);
                    }
                    if (gm.choose)
                    {
                        switch (gm.choseenToken)
                        {
                            case "Red":
                                nbRedFace++;
                                break;
                            case "Blue":
                                nbBlueFace++;
                                break;
                            case "Yellow":
                                nbYellowFace++;
                                break;
                            case "Green":
                                nbGreenFace++;
                                break;
                            case "Black":
                                nbBlackFace++;
                                break;
                            default:
                                break;
                        }
                        gm.choose = false;
                        gm.panelButtonChoice.SetActive(false);
                    }
                    nbWhiteFace--;
                }
            }

            yield return new WaitForSeconds(2.0f);
            gm.panelButtonChoice.SetActive(false);

            //Partie combat
            if (ghost1 != null || ghost2 != null)
            {
                if (ghost1 != null && ghost2 != null)
                {
                    buttonGhost1.gameObject.SetActive(true);
                    buttonGhost1.transform.GetChild(0).GetComponent<Text>().text = ghost1.name;
                    buttonGhost2.gameObject.SetActive(true);
                    buttonGhost2.transform.GetChild(0).GetComponent<Text>().text = ghost2.name;
                    //Définir priorité pour ghost puis ghost2 ou ghost2 puis ghost

                    while (!choosePriority)
                    {
                        yield return new WaitForSeconds(1.0f);
                    }
                    if (priority == ghost1.name)
                    {
                        buttonGhost1.gameObject.SetActive(false);
                        buttonGhost2.gameObject.SetActive(false);
                        ghost1.GetComponent<Ghost>().ReduceLife();
                        Attack(ghost1);
                        yield return new WaitForSeconds(1.5f);
                        ghost2.GetComponent<Ghost>().ReduceLife();
                        Attack(ghost2);
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                    }
                    else
                    {
                        buttonGhost1.gameObject.SetActive(false);
                        buttonGhost2.gameObject.SetActive(false);
                        ghost2.GetComponent<Ghost>().ReduceLife();
                        Attack(ghost2);
                        yield return new WaitForSeconds(1.5f);
                        ghost1.GetComponent<Ghost>().ReduceLife();
                        Attack(ghost1);
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                    }
                }
                else if (ghost1 == null && ghost2 != null)
                {
                    ghost2.GetComponent<Ghost>().ReduceLife();
                    Attack(ghost2);
                    yield return new WaitForSeconds(0.5f);
                    gameObject.GetComponent<Deplacement>().enabled = true;
                }
                else if (ghost1 != null && ghost2 == null)
                {
                    ghost1.GetComponent<Ghost>().ReduceLife();
                    Attack(ghost1);
                    yield return new WaitForSeconds(0.5f);
                    gameObject.GetComponent<Deplacement>().enabled = true;
                }
            }
            yield return new WaitForSeconds(0.5f);
            nbRedFace = 0;
            nbBlackFace = 0;
            nbBlueFace = 0;
            nbYellowFace = 0;
            nbGreenFace = 0;
            canLaunchDice = true;
            gameObject.GetComponent<Deplacement>().enabled = true;
            state = STATE_GAME.STATE_DRAW;
            gm.turn++;
            updateUI();
        }
    }

    public void checkGhost()
    {
        RaycastHit hitXdirection;
        RaycastHit hitZdirection;
        if(Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 4 && hitZdirection.collider.transform.childCount > 4)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                /*ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;*/
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                explosion2 = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 4 && hitZdirection.collider.transform.childCount > 4)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                /*ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;*/
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                explosion2 = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 4 && hitZdirection.collider.transform.childCount > 4)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                /*ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;*/
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                explosion2 = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 4 && hitZdirection.collider.transform.childCount > 4)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                /*ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;*/
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                explosion2 = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 4)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                //ghostName = hitXdirection.collider.transform.GetChild(0).name;
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f))
        {
            if (hitZdirection.collider.transform.childCount > 4)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                //ghostName = hitZdirection.collider.transform.GetChild(0).name;
                explosion = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 4)
            {
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                //ghostName = hitXdirection.collider.transform.GetChild(0).name;
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f))
        {
            if (hitZdirection.collider.transform.childCount > 4)
            {
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                //ghostName = hitZdirection.collider.transform.GetChild(0).name;
                explosion = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
        }
        else
        {
            ghostName = "";
            ghostName2 = "";
            ghost1 = null;
            ghost2 = null;
            explosion = null;
            explosion2 = null;
        }
    }

    private void updateUI()
    {
        textNbTokenBlue.text = "x " + NbBlueToken;
        textNbTokenRed.text = "x " + NbRedToken;
        textNbTokenGreen.text = "x " + NbGreenToken;
        textNbTokenYellow.text = "x " + NbYellowToken;
        textNbTokenBlack.text = "x " + NbBlackToken;
        textNbQI.text = "QI : x " + Qi;
        textNbTokenYinYangBlue.text = "x " + NbYinYangBlueToken;
        textNbTokenPower.text = "x " + NbPowerToken;
        //textNbTokenPower.text = "x " + NbBlackToken; // Jeton mantra, juste pour le joueur jaune
        textNbDice.text = "Dés en stock : " + gm.nbDice.ToString();
        textTurn.text = "Tour : " + gm.turn.ToString();
        textPlayerTurn.text = "TOUR DU JOUEUR BLEU";
        update = false;
    }

    public void SetPriority(Button buttonClick)
    {
        priority = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choosePriority = true;
    }


    public void Attack(GameObject ghost)
    {
        if ( (ghost.GetComponent<Ghost>().canBeDestroyByDice) && ((ghost.GetComponent<Ghost>().couleur == "red" && nbRedFace >= ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "blue" && nbBlueFace >= ghost.GetComponent<Ghost>().life)
                    || (ghost.GetComponent<Ghost>().couleur == "green" && nbGreenFace >= ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "yellow" && nbYellowFace >= ghost.GetComponent<Ghost>().life)
                    || (ghost.GetComponent<Ghost>().couleur == "black" && nbBlackFace >= ghost.GetComponent<Ghost>().life)) )
        {
            //On ajouteras des particules à la mort du fantome (style explosion)
            switch (ghost.GetComponent<Ghost>().couleur)
            {
                case "red":
                    gm.redBoard.nbCardOnBoard--;
                    nbRedFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "yellow":
                    gm.yellowBoard.nbCardOnBoard--;
                    nbYellowFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "blue":
                    gm.blueBoard.nbCardOnBoard--;
                    nbBlueFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "black":
                    gm.blueBoard.nbCardOnBoard--;
                    nbBlackFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "green":
                    gm.greenBoard.nbCardOnBoard--;
                    nbGreenFace -= ghost.GetComponent<Ghost>().life;
                    break;
                default:
                    break;
            }
            explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
            if (ghost.transform.parent.GetChild(1).childCount >= 1)
            {
                Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
            }
            if (ghost.transform.parent.GetChild(2).childCount >= 1)
            {
                Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
            }

            ghost.transform.parent = defausse.transform;
            ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
            if (ghost.GetComponent<Ghost>().deathPower)
            {
                ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
            }
            ghost = null;
        }
        else if ((gm.canUseTaoToken) && ((ghost.GetComponent<Ghost>().couleur == "red" && nbRedFace < ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "blue" && nbBlueFace < ghost.GetComponent<Ghost>().life)
            || (ghost.GetComponent<Ghost>().couleur == "green" && nbGreenFace < ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "yellow" && nbYellowFace < ghost.GetComponent<Ghost>().life)
            || (ghost.GetComponent<Ghost>().couleur == "black" && nbBlackFace < ghost.GetComponent<Ghost>().life)))
        {
            //D'abord, check si on a un autre joueur (ou plusieurs) sur la meme case que nous.
            // Check résultat Dés + jetons pour tuer le fantome
            if (ghost.GetComponent<Ghost>().couleur == "red")
            {
                int resultRed = ghost.GetComponent<Ghost>().life - nbRedFace;
                if (nbRedToken >= resultRed)
                {
                    nbRedToken -= resultRed;
                    gm.redBoard.nbCardOnBoard--;
                    nbRedFace = 0;
                    explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                    if (ghost.transform.parent.GetChild(1).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
                    }
                    if (ghost.transform.parent.GetChild(2).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
                    }
                    ghost.transform.parent = defausse.transform;
                    ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                    if (ghost.GetComponent<Ghost>().deathPower)
                    {
                        ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
                    }
                    ghost = null;
                    update = true;
                }
            }
            else if (ghost.GetComponent<Ghost>().couleur == "blue")
            {
                int resultBlue = ghost.GetComponent<Ghost>().life - nbBlueFace;
                if (nbBlueToken >= resultBlue)
                {
                    nbBlueToken -= resultBlue;
                    gm.blueBoard.nbCardOnBoard--;
                    nbBlueFace = 0;
                    explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                    if (ghost.transform.parent.GetChild(1).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
                    }
                    if (ghost.transform.parent.GetChild(2).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
                    }
                    ghost.transform.parent = defausse.transform;
                    ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                    if (ghost.GetComponent<Ghost>().deathPower)
                    {
                        ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
                    }
                    ghost = null;
                    update = true;
                }
            }
            else if (ghost.GetComponent<Ghost>().couleur == "green")
            {
                int resultGreen = ghost.GetComponent<Ghost>().life - nbGreenFace;
                if (nbGreenToken >= resultGreen)
                {
                    nbGreenToken -= resultGreen;
                    gm.greenBoard.nbCardOnBoard--;
                    nbGreenFace = 0;
                    explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                    if (ghost.transform.parent.GetChild(1).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
                    }
                    if (ghost.transform.parent.GetChild(2).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
                    }
                    ghost.transform.parent = defausse.transform;
                    ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                    if (ghost.GetComponent<Ghost>().deathPower)
                    {
                        ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
                    }
                    ghost = null;
                    update = true;
                }
            }
            else if (ghost.GetComponent<Ghost>().couleur == "yellow")
            {
                int resultYellow = ghost.GetComponent<Ghost>().life - nbYellowFace;
                if (nbYellowToken >= resultYellow)
                {
                    nbYellowToken -= resultYellow;
                    gm.yellowBoard.nbCardOnBoard--;
                    nbYellowFace = 0;
                    explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                    if (ghost.transform.parent.GetChild(1).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
                    }
                    if (ghost.transform.parent.GetChild(2).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
                    }
                    ghost.transform.parent = defausse.transform;
                    ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                    if (ghost.GetComponent<Ghost>().deathPower)
                    {
                        ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
                    }
                    ghost = null;
                    update = true;
                }
            }
            else if (ghost.GetComponent<Ghost>().couleur == "black")
            {
                int resultBlack = ghost.GetComponent<Ghost>().life - nbBlackFace;
                if (nbBlackToken >= resultBlack)
                {
                    nbBlackToken -= resultBlack;
                    gm.blueBoard.nbCardOnBoard--;
                    nbBlackFace = 0;
                    explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                    if (ghost.transform.parent.GetChild(1).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
                    }
                    if (ghost.transform.parent.GetChild(2).childCount >= 1)
                    {
                        Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
                    }
                    ghost.transform.parent = defausse.transform;
                    ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                    if (ghost.GetComponent<Ghost>().deathPower)
                    {
                        ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
                    }
                    ghost = null;
                    update = true;
                }
            }
        }
        else if(!ghost.GetComponent<Ghost>().canBeDestroyByDice && ghost.GetComponent<Ghost>().life == 0)
        {
            switch (ghost.GetComponent<Ghost>().couleur)
            {
                case "red":
                    gm.redBoard.nbCardOnBoard--;
                    break;
                case "yellow":
                    gm.yellowBoard.nbCardOnBoard--;
                    break;
                case "blue":
                    gm.blueBoard.nbCardOnBoard--;
                    break;
                case "black":
                    gm.blueBoard.nbCardOnBoard--;
                    break;
                case "green":
                    gm.greenBoard.nbCardOnBoard--;
                    break;
                default:
                    break;
            }
            explosion.transform.GetChild(2).GetComponent<ParticleSystem>().Play();
            if (ghost.transform.parent.GetChild(1).childCount >= 1)
            {
                Destroy(ghost.transform.parent.GetChild(1).GetChild(0).gameObject);
            }
            if (ghost.transform.parent.GetChild(2).childCount >= 1)
            {
                Destroy(ghost.transform.parent.GetChild(2).GetChild(0).gameObject);
            }

            ghost.transform.parent = defausse.transform;
            ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            ghost.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
            if (ghost.GetComponent<Ghost>().deathPower)
            {
                ghost.GetComponent<Ghost>().UseDeathPower(gameObject);
            }
            ghost = null;
        }
        else
        {
            //On a pas assez pour le tuer, alors il ne se passe rien
        }
    }


    public IEnumerator LaunchBlackDice()
    {
        canLaunchBlackDice = false;
        canLaunchDice = false;
        gameObject.GetComponent<Deplacement>().enabled = false;

        yield return new WaitForSeconds(0.2f);

        GameObject go = Instantiate(blackDice, new Vector3(0, 2, 0), Quaternion.identity);
        go.AddComponent<CubeScript>();
        cube = go.GetComponent<CubeScript>();
        blackDiceOne = go;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            cube.rb.AddForce(hit.point * cube.force);
        }

        yield return new WaitForSeconds(5.0f);
        if (blackDiceOne != null)
        {
            resultFace = blackDiceOne.GetComponent<CubeScript>().face;
        }
        switch (resultFace)
        {
            case "HauntedFace":
                switch (tileName)
                {
                    case "MaisonThe":
                        houseOfTea.GetComponent<HouseOfTea>().hauntedTile = true;
                        houseOfTea.GetComponent<HouseOfTea>().haunted();
                        break;
                    case "HutteSorciere":
                        witchHut.GetComponent<HutOfWitch>().hauntedTile = true;
                        witchHut.GetComponent<HutOfWitch>().haunted();
                        break;
                    case "EchoppeHerboriste":
                        herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = true;
                        herbalistStall.GetComponent<StallOfHerbalist>().haunted();
                        break;
                    case "AutelTaoiste":
                        taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = true;
                        taoisteAutel.GetComponent<TaoisteAutel>().haunted();
                        break;
                    case "Cimetiere":
                        graveyard.GetComponent<Graveyard>().hauntedTile = true;
                        graveyard.GetComponent<Graveyard>().haunted();
                        break;
                    case "PavillonVentCeleste":
                        windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = true;
                        windCelestialFlag.GetComponent<WindCelestialFlag>().haunted();
                        break;
                    case "TourVeilleurNuit":
                        nightTower.GetComponent<NightTower>().hauntedTile = true;
                        nightTower.GetComponent<NightTower>().haunted();
                        break;
                    case "CerclePierre":
                        priestCircle.GetComponent<PriestCircle>().hauntedTile = true;
                        priestCircle.GetComponent<PriestCircle>().haunted();
                        break;
                    case "TempleBouddhiste":
                        bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = true;
                        bouddhisteTemple.GetComponent<BouddhisteTemple>().haunted();
                        break;
                    default:
                        break;
                }
                //To verify if we need that
                canLaunchBlackDice = true;
                useTilePower = false;
                canLaunchDice = true;
                gameObject.GetComponent<Deplacement>().enabled = true;
                break;
            case "DrawGhostFace":
                //player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_DRAW;
                DrawAGhost();
                //To verify if we need that
                canLaunchBlackDice = true;
                useTilePower = false;
                canLaunchDice = true;
                gameObject.GetComponent<Deplacement>().enabled = true;
                break;
            case "LoseJetonFace":
                gm.tokenStock.nbBlackToken += NbBlackToken;
                NbBlackToken = 0;
                gm.tokenStock.nbRedToken += NbRedToken;
                NbRedToken = 0;
                gm.tokenStock.nbBlueToken += NbBlueToken;
                NbBlueToken = 0;
                gm.tokenStock.nbGreenToken += NbGreenToken;
                NbGreenToken = 0;
                gm.tokenStock.nbYellowToken += NbYellowToken;
                NbYellowToken = 0;
                //To verify if we need that
                update = true;
                canLaunchBlackDice = true;
                canLaunchDice = true;
                useTilePower = false;
                gameObject.GetComponent<Deplacement>().enabled = true; ;
                break;
            case "LoseQIFace":
                Qi -= 1;
                //To verify if we need that
                update = true;
                canLaunchBlackDice = true;
                useTilePower = false;
                canLaunchDice = true;
                gameObject.GetComponent<Deplacement>().enabled = true;
                break;
            case "EmptyFace":
            case "EmptyFaceTwo":
                //To verify if we need that
                canLaunchBlackDice = true;
                useTilePower = false;
                canLaunchDice = true;
                gameObject.GetComponent<Deplacement>().enabled = true;
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(0.5f);

        Destroy(blackDiceOne);
    }


    public void EndTurn()
    {
        state = STATE_GAME.STATE_GHOSTPOWER; // Par la suite, passer a STATE_GHOSTPOWER
    }


    public void ActivateInGameEffect()
    {
        int maxChild = gm.blueBoard.gameObject.transform.childCount;
        for(int i = 0; i < maxChild; i++)
        {
            if (gm.blueBoard.gameObject.transform.GetChild(i).childCount >= 5)
            {
               if(gm.blueBoard.gameObject.transform.GetChild(i).GetChild(4).GetComponent<Ghost>().inGamePower)
                {
                    gm.blueBoard.gameObject.transform.GetChild(i).GetChild(4).GetComponent<Ghost>().UseInGamePower(gameObject);
                }
            }
        }
    }


    /*public void CheckDeplacement()
    {
        switch (tileName)
        {
            case "MaisonThe":
                if(Vector3.Distance(houseOfTea.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                    Debug.Log("Test : " + navMeshHut.area);
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(houseOfTea.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                break;
            case "HutteSorciere":
                if (Vector3.Distance(witchHut.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(witchHut.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                break;
            case "EchoppeHerboriste":
                if (Vector3.Distance(herbalistStall.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(herbalistStall.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                break;
            case "AutelTaoiste":
                if (Vector3.Distance(taoisteAutel.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(taoisteAutel.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                break;
            case "Cimetiere":
                if (Vector3.Distance(graveyard.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(graveyard.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                break;
            case "PavillonVentCeleste":
                if (Vector3.Distance(windCelestialFlag.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(windCelestialFlag.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                break;
            case "TourVeilleurNuit":
                if (Vector3.Distance(nightTower.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(nightTower.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                break;
            case "CerclePriere":
                if (Vector3.Distance(priestCircle.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                {
                    navMeshTemple.area = 0;
                }
                else
                {
                    navMeshTemple.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                if (Vector3.Distance(priestCircle.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                break;
            case "TempleBouddhiste":
                if (Vector3.Distance(bouddhisteTemple.transform.position, houseOfTea.transform.position) < 1.5f)
                {
                    navMeshHouse.area = 0;
                }
                else
                {
                    navMeshHouse.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, witchHut.transform.position) < 1.5f)
                {
                    navMeshHut.area = 0;
                }
                else
                {
                    navMeshHut.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, graveyard.transform.position) < 1.5f)
                {
                    navMeshGraveyard.area = 0;
                }
                else
                {
                    navMeshGraveyard.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, taoisteAutel.transform.position) < 1.5f)
                {
                    navMeshAutel.area = 0;
                }
                else
                {
                    navMeshAutel.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, herbalistStall.transform.position) < 1.5f)
                {
                    navMeshEchoppe.area = 0;
                }
                else
                {
                    navMeshEchoppe.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, priestCircle.transform.position) < 1.5f)
                {
                    navMeshCircle.area = 0;
                }
                else
                {
                    navMeshCircle.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, nightTower.transform.position) < 1.5f)
                {
                    navMeshTower.area = 0;
                }
                else
                {
                    navMeshTower.area = 1;
                }
                if (Vector3.Distance(bouddhisteTemple.transform.position, windCelestialFlag.transform.position) < 1.5f)
                {
                    navMeshPavillon.area = 0;
                }
                else
                {
                    navMeshPavillon.area = 1;
                }
                break;
            default:
                break;
        }
    }*/
}
