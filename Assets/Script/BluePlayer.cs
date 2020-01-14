using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    public boardColor blueBoard;
    [SerializeField]
    public boardColor redBoard;
    [SerializeField]
    public boardColor greenBoard;
    [SerializeField]
    public boardColor yellowBoard;

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
        STATE_PLAYER = 2
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

        redBoard = GameObject.Find("PlateauJoueurRouge").GetComponent<boardColor>();
        blueBoard = GameObject.Find("PlateauJoueurBleu").GetComponent<boardColor>();
        greenBoard = GameObject.Find("PlateauJoueurVert").GetComponent<boardColor>();
        yellowBoard = GameObject.Find("PlateauJoueurJaune").GetComponent<boardColor>();
        canLaunchDice = true;
        canLaunchBlackDice = true;
        useTilePower = false;
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
        else if (state == STATE_GAME.STATE_PLAYER)
        {
            textInfoPhase.text = " Phase de jeu, vous pouvez : \n\n - Vous déplacer (Clic gauche souris), \n - Attaquer un fantome se trouvant devant vous (Touche D), \n - Utilisez le pouvoir de la tuile sur laquelle vous vous trouvez (Touche E)";
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
            if (blueBoard.nbCardOnBoard == 3 && redBoard.nbCardOnBoard == 3 && greenBoard.nbCardOnBoard == 3 && yellowBoard.nbCardOnBoard == 3)
            {
                textInfo.gameObject.SetActive(true);
                textInfo.text = "Vous ne pouvez pas piocher un autre fantôme, il y en a trop sur le terrain";
                hasDraw = false;
                gameObject.GetComponent<Deplacement>().enabled = true;
                textInfoPhase.gameObject.SetActive(true);
                state = STATE_GAME.STATE_PLAYER;
                return;
            }
            if (blueBoard.nbCardOnBoard == 3 && !useTilePower)
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
            Debug.Log("Coucou coucou coucou");
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
            Debug.Log("Fin fin fin");
        }
    }

    public void SelectGhostPosition(GameObject position)
    {
        if (state == STATE_GAME.STATE_DRAW || useGhostPower || useTilePower)
        {
            if (card.GetComponent<Ghost>().couleur == "black" && position.transform.parent.GetComponent<boardColor>().color != colorPlayer && blueBoard.nbCardOnBoard < 3)
            {
                textInfo.text = "Les fantômes noirs doivent être posés sur le plateau de votre couleur";
                return;
            }
            else if (card.GetComponent<Ghost>().couleur != "black" && card.GetComponent<Ghost>().couleur != position.transform.parent.GetComponent<boardColor>().color)
            {
                if ((card.GetComponent<Ghost>().couleur == "red" && redBoard.nbCardOnBoard < 3) ||
                    (card.GetComponent<Ghost>().couleur == "blue" && blueBoard.nbCardOnBoard < 3) ||
                    (card.GetComponent<Ghost>().couleur == "yellow" && yellowBoard.nbCardOnBoard < 3) ||
                    (card.GetComponent<Ghost>().couleur == "green" && greenBoard.nbCardOnBoard < 3))
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
                blueBoard.nbCardOnBoard++;
            }
            else if (position.transform.parent.GetComponent<boardColor>().color == "green")
            {
                greenBoard.nbCardOnBoard++;
            }
            else if (position.transform.parent.GetComponent<boardColor>().color == "red")
            {
                redBoard.nbCardOnBoard++;
            }
            else if (position.transform.parent.GetComponent<boardColor>().color == "yellow")
            {
                yellowBoard.nbCardOnBoard++;
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

            if (state == STATE_GAME.STATE_DRAW)
            {
                state = STATE_GAME.STATE_PLAYER;
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
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    textInfoPhase.gameObject.SetActive(false);
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    //gameObject.GetComponent<BluePlayer>().enabled = false;
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
                    textInfoTuile.text = "Cette tuile n'as pas encore d'effet";
                    //nightTower.GetComponent<NightTower>().RetreatGhost();
                    break;
                case "CerclePierre":
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
                        Attack(ghost1);
                        yield return new WaitForSeconds(1.5f);
                        Attack(ghost2);
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                    }
                    else
                    {
                        buttonGhost1.gameObject.SetActive(false);
                        buttonGhost2.gameObject.SetActive(false);
                        Attack(ghost2);
                        yield return new WaitForSeconds(1.5f);
                        Attack(ghost1);
                        yield return new WaitForSeconds(0.5f);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                    }
                }
                else if (ghost1 == null && ghost2 != null)
                {
                    Attack(ghost2);
                    yield return new WaitForSeconds(0.5f);
                    gameObject.GetComponent<Deplacement>().enabled = true;
                }
                else if (ghost1 != null && ghost2 == null)
                {
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
                    redBoard.nbCardOnBoard--;
                    nbRedFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "yellow":
                    yellowBoard.nbCardOnBoard--;
                    nbYellowFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "blue":
                    blueBoard.nbCardOnBoard--;
                    nbBlueFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "black":
                    blueBoard.nbCardOnBoard--;
                    nbBlackFace -= ghost.GetComponent<Ghost>().life;
                    break;
                case "green":
                    greenBoard.nbCardOnBoard--;
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
                    redBoard.nbCardOnBoard--;
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
                    blueBoard.nbCardOnBoard--;
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
                    greenBoard.nbCardOnBoard--;
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
                    yellowBoard.nbCardOnBoard--;
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
                    blueBoard.nbCardOnBoard--;
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
        else
        {
            //On a pas assez pour le tuer, alors il ne se passe rien
        }
    }


    public IEnumerator LaunchBlackDice()
    {
        Debug.Log("PAR ICI");
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

        //blackDiceOne = go;
        Debug.Log("De lance");
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
                Debug.Log("Dans le switch");
                //player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_DRAW;
                DrawAGhost();
                //To verify if we need that
                canLaunchBlackDice = true;
                useTilePower = false;
                canLaunchDice = true;
                gameObject.GetComponent<Deplacement>().enabled = true;
                break;
            case "LoseJetonFace":
                Debug.Log("Dans le switch");
                NbBlackToken = 0;
                NbRedToken = 0;
                NbBlueToken = 0;
                NbGreenToken = 0;
                NbYellowToken = 0;
                //To verify if we need that
                update = true;
                canLaunchBlackDice = true;
                canLaunchDice = true;
                useTilePower = false;
                gameObject.GetComponent<Deplacement>().enabled = true; ;
                break;
            case "LoseQIFace":
                Debug.Log("Dans le switch");
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
                Debug.Log("Dans le switch");
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
        state = STATE_GAME.STATE_DRAW; // Par la suite, passer a STATE_GHOSTPOWER
    }
}
