using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowPlayer : MonoBehaviour
{
    [Header("Game Manager")]
    public GameManager gm;

    [Header("Infos joueur")]
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
    private int nbYinYangYellowToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur
    [SerializeField]
    private int nbBouddha; // Pour les bouddha du temple bouddhiste
    [SerializeField]
    private int nbMantraToken;

    public GameObject mantraToken;
    public GameObject ghostToWeakned;
    public string chooseenGhost;
    public bool choose;


    public GameObject panelJeton;

    public bool powerMantraAffaiblissement;
    public bool powerPocheSansFond;

    public bool useTilePower;
    public bool useGhostPower;
    public bool canUsePower;
    public bool canLaunchDice;
    public bool canLaunchBlackDice;

    public int nbActionEffect;
    public int nbActionBattle;

    //Les dés et leurs résultats
    [Header("Les dés")]
    [SerializeField]
    private GameObject dice;
    [SerializeField]
    private CubeScript cube;

    private GameObject diceOne;
    private GameObject diceTwo;
    private GameObject diceThree;

    public string resultDiceOne;
    public string resultDiceTwo;
    public string resultDiceThree;

    public int nbRedFace;
    public int nbBlueFace;
    public int nbYellowFace;
    public int nbGreenFace;
    public int nbWhiteFace;
    public int nbBlackFace;

    [SerializeField]
    private GameObject blackDice;
    public GameObject blackDiceOne;
    public string resultFace;

    [Header("Les tuiles")]
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

    //Les positions pour placer les bouddhas
    [Header("Les Bouddhas")]
    public bool choosePriority;
    public bool chooseBouddha;

    public GameObject positionOne;
    public GameObject positionTwo;

    public GameObject bouddhaOne;
    public GameObject bouddhaTwo;

    public string priority;
    public string bouddhaChoice;

    public Button buttonGhost1;
    public Button buttonGhost2;

    public Button buttonBouddha1;
    public Button buttonBouddha2;


    //Les fantômes ciblables
    [Header("Les fantômes")]
    public string ghostName;
    public string ghostName2;

    public GameObject ghost1;
    public GameObject ghost2;

    public GameObject explosion;
    public GameObject explosion2;

    //Le deck et l'emplacement des fantômes pour la pioche
    [Header("La pioche")]
    [SerializeField]
    private PoolManagerDeck deck;
    [SerializeField]
    public GameObject card;
    public BoardPosition board;
    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;
    public GameObject panelPrio;
    public GameObject panelBouddha;
    public GameObject panelYinYang;
    public GameObject panelTile;

    public string effectYinYang;
    public string tileYinYang;

    public string colorPlayer = "blue";

    [SerializeField]
    private GameObject defausse;

    //Booleen utilitaire
    [Header("Booleens")]
    [SerializeField]
    private bool hasDraw;
    public bool update;
    public bool alreadyMove;
    public bool stop;
    public bool yellowTurn;
    public bool useRedPower;
    public bool useWindCelestialPower;
    public bool chooseEffectYinYang;
    public bool chooseTile;
    public bool canKillGhost;
    public bool wantUnhaunted;

    //Les différents textes
    [Header("Les textes")]
    public Text textInfo;
    public Text textNbTokenBlue;
    public Text textNbTokenRed;
    public Text textNbTokenGreen;
    public Text textNbTokenYellow;
    public Text textNbTokenBlack;
    public Text textNbTokenPower;
    public Text textNbTokenYinYangYellow;
    public Text textNbQI;
    public Text textNbBouddha;
    public Text textNbWhiteFace;
    public Text infosWhiteFace;
    public Text textInfoPhase;
    public Text textInfoPower;
    public Text textMort;
    public Text textInfoTuile;
    public Text textNbDice;
    public Text textTurn;
    public Text infoPower;
    public Text textYinYang;
    public Text textUnhaunted;
    public Text textTilePowerDescription;

    public string descriptionPowerYellow;

    //Déplacement
    [Header("Le déplacement")]
    public Transform yellowPosStall;
    public Transform yellowPosHouse;
    public Transform yellowPosHut;
    public Transform yellowPosPavillon;
    public Transform yellowPosGraveyard;
    public Transform yellowPosAutel;
    public Transform yellowPosCircle;
    public Transform yellowPosTemple;
    public Transform yellowPosTower;
    public Vector3 actualPosition;

    public LayerMask layerYellow;

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

    public int NbYinYangYellowToken
    {
        get
        {
            return nbYinYangYellowToken;
        }

        set
        {
            nbYinYangYellowToken = value;
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

    public int NbMantraToken
    {
        get
        {
            return nbMantraToken;
        }

        set
        {
            nbMantraToken = value;
        }
    }

    #endregion

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Qi = 30; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        NbBlueToken = 0;
        NbRedToken = 0;
        NbYellowToken = 1;
        NbGreenToken = 0;
        NbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        NbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        NbYinYangYellowToken = 1; //Max possible.
        nbActionEffect = 1;
        nbActionBattle = 1;

        if (powerMantraAffaiblissement)
        {
            nbMantraToken = 1;
        }
        else
        {
            nbMantraToken = 0;
        }

        hasDraw = false;
        gm.state = GameManager.STATE_GAME.STATE_DRAW;
        deck = GameObject.Find("Deck").GetComponent<PoolManagerDeck>();
        board = GameObject.Find("Canvas").GetComponent<BoardPosition>();
        layerYellow = LayerMask.GetMask("GhostPlaces");
        canLaunchDice = true;
        canLaunchBlackDice = true;
        useTilePower = false;
        stop = false;
        alreadyMove = false;
        updateUI();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire2") && !hasDraw && gm.state == GameManager.STATE_GAME.STATE_DRAW && !gm.cantPlay)
        {
            DrawAGhost();
        }

        if (Input.GetKeyDown(KeyCode.B) && yellowTurn && !gm.cantPlay) // Debug pour moi
        {
            CheckDistance();
            StartCoroutine(gameObject.GetComponent<Deplacement>().PlayerDeplacement());
        }
        if (Input.GetKeyDown(KeyCode.C) && !gm.cantPlay)
        {
            StartCoroutine(PlaceBouddha());
        }

        RaycastHit hitt;
        if (Physics.Raycast(transform.position, Vector3.down, out hitt, 1.0f))
        {
            tileName = hitt.transform.gameObject.name;
        }

        if (Input.GetKeyDown(KeyCode.A) && canLaunchDice && !gm.cantPlay)
        {
            StartCoroutine(LaunchDice());
        }

        if (Input.GetKeyDown(KeyCode.E) && canLaunchDice && canLaunchBlackDice && !gm.cantPlay)
        {
            UsePowerTile();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !gm.cantPlay)
        {
            StartCoroutine(UseYinYangToken());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && yellowTurn && !gm.cantPlay)
        {
            if (powerMantraAffaiblissement)
            {
                StartCoroutine(MantraAffaiblissement());
            }
            else if (powerPocheSansFond)
            {
                StartCoroutine(PocheSansFond());
            }
        }

        if (update)
        {
            updateUI();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            panelJeton.SetActive(!panelJeton.activeSelf);
        }

        if (gm.state == GameManager.STATE_GAME.STATE_DRAW && yellowTurn)
        {
            textInfoPhase.text = " Phase de pioche : \n - Il vous faut piocher une carte fantôme (Clic droit souris)";
            textInfoPower.text = descriptionPowerYellow;
        }
        else if (gm.state == GameManager.STATE_GAME.STATE_MOVE && yellowTurn)
        {
            textInfoPhase.text = " Phase de déplacement : \n - Veuillez choisir où vous voulez vous déplacer";
            textInfoPower.text = descriptionPowerYellow;
        }
        else if (gm.state == GameManager.STATE_GAME.STATE_PLAYER && yellowTurn)
        {
            textInfoPhase.text = " Phase de jeu. Vous pouvez : \n - Attaquer un fantôme se trouvant devant vous (A), \n - Utilisez le pouvoir de la tuile sur laquelle vous vous trouvez (E), \n - Utilisez votre jeton Yin Yang (Ctrl Gauche), \n - Utilisez votre pouvoir (Shift Gauche)";
            textInfoPower.text = descriptionPowerYellow;
        }

        if (Input.GetKeyDown(KeyCode.P) && yellowTurn)
        {
            powerMantraAffaiblissement = false;
            powerPocheSansFond = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && yellowTurn)
        {
            powerMantraAffaiblissement = true;
            powerPocheSansFond = false;
        }

        if (powerMantraAffaiblissement)
        {
            descriptionPowerYellow = "VOTRE POUVOIR : \n - Vous pouvez posez votre jeton mantra sur l'un des fantômes. Il perd 1 point de vie";
        }
        else if (powerPocheSansFond)
        {
            descriptionPowerYellow = "VOTRE POUVOIR : \n - Vous pouvez récupérer un jeton de la couleur de votre choix";
        }

        if (gm.state == GameManager.STATE_GAME.STATE_GHOSTPOWER && yellowTurn)
        {
            gm.state = GameManager.STATE_GAME.STATE_DRAW;
            ActivateInGameEffect();
        }
        else if (gm.state == GameManager.STATE_GAME.STATE_MOVE && !stop && yellowTurn)
        {
            stop = true;
            CheckDistance();
            StartCoroutine(gameObject.GetComponent<Deplacement>().PlayerDeplacement());
        }

        if (Qi <= 0)
        {
            Qi = 0;
            textMort.text = "Vous êtes mort";
            updateUI();
        }

        if (yellowTurn)
        {
            checkTilePower(tileName);
        }

        checkGhost();
        checkPosition();
    }

    public void DrawAGhost()
    {
        gm.cantPause = true;
        card = null;
        if ((gm.state == GameManager.STATE_GAME.STATE_DRAW || useTilePower || useGhostPower) && yellowTurn)
        {
            hasDraw = true;
            gameObject.GetComponent<Deplacement>().enabled = false;
            canLaunchBlackDice = false;
            canLaunchDice = false;
            panelJeton.SetActive(false);
            textInfoPhase.gameObject.SetActive(false);
            textInfoPower.gameObject.SetActive(false);
            textInfo.text = " ";
            if (gm.blueBoard.nbCardOnBoard == 3 && gm.redBoard.nbCardOnBoard == 3 && gm.greenBoard.nbCardOnBoard == 3 && gm.yellowBoard.nbCardOnBoard == 3)
            {
                textInfo.gameObject.SetActive(true);
                textInfo.text = "Vous ne pouvez pas piocher un autre fantôme, il y en a trop sur le terrain";
                hasDraw = false;
                gameObject.GetComponent<Deplacement>().enabled = true;
                textInfoPhase.gameObject.SetActive(true);
                textInfoPower.gameObject.SetActive(true);
                canLaunchBlackDice = true;
                canLaunchDice = true;
                gm.state = GameManager.STATE_GAME.STATE_MOVE;
                return;
            }
            if (gm.yellowBoard.nbCardOnBoard == 3 && !useTilePower)
            {
                textInfo.gameObject.SetActive(true);
                textInfo.text = "Votre plateau est plein de fantômes, vous perdez une vie";
                Qi -= 1;
                update = true;
                hasDraw = false;
                gameObject.GetComponent<Deplacement>().enabled = true;
                textInfoPhase.gameObject.SetActive(true);
                textInfoPower.gameObject.SetActive(true);
                canLaunchBlackDice = true;
                canLaunchDice = true;
                gm.state = GameManager.STATE_GAME.STATE_MOVE;
                return;
            }
            panelBluePlace.SetActive(true);
            panelRedPlace.SetActive(true);
            panelGreenPlace.SetActive(true);
            panelYellowPlace.SetActive(true);
            textInfo.gameObject.SetActive(true);
            gm.drawedCard.gameObject.SetActive(true);
            if (gm.nbCardOnDeck == 40 && gm.nbCardOnBossDeck == 10)
            {
                card = deck.GetPoolByName(PoolNameDeck.boss).GetItem(transform, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, true, false, 0);
                card.transform.parent = null;
                card.transform.position = new Vector3(100.0f, 100.0f, 100.0f);
                card.SetActive(true);
                gm.PowerGhostInformation(card);
                gm.panelInfoGhostPower.SetActive(true);
                gm.nbCardOnBossDeck--;
            }
            else
            {
                card = deck.GetPoolByName(PoolNameDeck.ghost).GetItem(transform, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, true, false, 0);
                card.transform.parent = null;
                card.transform.position = new Vector3(100.0f, 100.0f, 100.0f);
                card.SetActive(true);
                gm.PowerGhostInformation(card);
                gm.panelInfoGhostPower.SetActive(true);
                gm.nbCardOnDeck--;
            }
            gm.drawedCard.sprite = card.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void SelectGhostPosition(GameObject position)
    {
        if ((gm.state == GameManager.STATE_GAME.STATE_DRAW || useGhostPower || useTilePower) && yellowTurn)
        {
            if (card != null)
            {
                if (card.GetComponent<Ghost>().couleur == "black" && position.transform.parent.GetComponent<boardColor>().color != colorPlayer && gm.yellowBoard.nbCardOnBoard < 3)
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
                if (position.transform.childCount > 4 && position.transform.GetChild(4).name.Contains("Bouddha"))
                {
                    if (card.GetComponent<Ghost>().canBeKillByBouddha)
                    {
                        card.transform.SetParent(defausse.transform);
                        card.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                        card.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                        bouddhisteTemple.GetComponent<BouddhisteTemple>().numberOfBouddha += 1;
                        if (bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst == null)
                        {
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst = position.transform.GetChild(4).gameObject;
                            position.transform.GetChild(4).parent = bouddhisteTemple.transform;
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst.transform.localPosition = new Vector3(-0.145f, 3.0f, 0.325f);
                        }
                        else if (bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaSecond == null)
                        {
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaSecond = position.transform.GetChild(4).gameObject;
                            position.transform.GetChild(4).transform.parent = bouddhisteTemple.transform;
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst.transform.localPosition = new Vector3(-0.325f, 3.0f, 0.325f);
                        }

                        panelBluePlace.SetActive(false);
                        panelRedPlace.SetActive(false);
                        panelGreenPlace.SetActive(false);
                        panelYellowPlace.SetActive(false);
                        gm.panelInfoGhostPower.SetActive(false);
                        textInfo.gameObject.SetActive(false);
                        gm.drawedCard.gameObject.SetActive(false);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                        textInfoPhase.gameObject.SetActive(true);
                        textInfoPower.gameObject.SetActive(true);
                        panelJeton.SetActive(true);
                        useTilePower = false;
                        canLaunchBlackDice = true;
                        canLaunchDice = true;
                        hasDraw = false;
                        useGhostPower = false;
                        gm.cantPause = false;
                    }
                    else
                    {
                        bouddhisteTemple.GetComponent<BouddhisteTemple>().numberOfBouddha += 1;
                        if (bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst == null)
                        {
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst = position.transform.GetChild(4).gameObject;
                            position.transform.GetChild(4).parent = bouddhisteTemple.transform;
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst.transform.localPosition = new Vector3(-0.145f, 3.0f, 0.325f);
                        }
                        else if (bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaSecond == null)
                        {
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaSecond = position.transform.GetChild(4).gameObject;
                            position.transform.GetChild(4).transform.parent = bouddhisteTemple.transform;
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().bouddhaFirst.transform.localPosition = new Vector3(-0.325f, 3.0f, 0.325f);
                        }
                        card.transform.SetParent(position.transform);
                        card.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                        card.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
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
                        gm.panelInfoGhostPower.SetActive(false);
                        textInfo.gameObject.SetActive(false);
                        gm.drawedCard.gameObject.SetActive(false);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                        textInfoPhase.gameObject.SetActive(true);
                        textInfoPower.gameObject.SetActive(true);
                        panelJeton.SetActive(true);
                        useTilePower = false;
                        canLaunchBlackDice = true;
                        canLaunchDice = true;
                        hasDraw = false;
                        useGhostPower = false;
                        gm.cantPause = false;
                        if (card != null && card.GetComponent<Ghost>().entryPower)
                        {
                            if (card.GetComponent<Ghost>().hasDrawAGhostPower)
                            {
                                useGhostPower = true;
                            }
                            card.GetComponent<Ghost>().UseEntryPower(gameObject);
                        }
                        if (card.name == "Uncatchable(Clone)")
                        {
                            card.GetComponent<GhostPower>().UninsensibleWithBouddha();
                        }
                    }
                }
                else
                {
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
                    gm.panelInfoGhostPower.SetActive(false);
                    textInfo.gameObject.SetActive(false);
                    gm.drawedCard.gameObject.SetActive(false);
                    gameObject.GetComponent<Deplacement>().enabled = true;
                    textInfoPhase.gameObject.SetActive(true);
                    textInfoPower.gameObject.SetActive(true);
                    panelJeton.SetActive(true);
                    useTilePower = false;
                    canLaunchBlackDice = true;
                    canLaunchDice = true;
                    hasDraw = false;
                    gm.cantPause = false;
                    useGhostPower = false;
                    if (card != null && card.GetComponent<Ghost>().entryPower)
                    {
                        if (card.GetComponent<Ghost>().hasDrawAGhostPower)
                        {
                            useGhostPower = true;
                        }
                        card.GetComponent<Ghost>().UseEntryPower(gameObject);
                    }
                }
            }

            if (gm.state == GameManager.STATE_GAME.STATE_DRAW && !useGhostPower)
            {
                if (!alreadyMove)
                {
                    gm.state = GameManager.STATE_GAME.STATE_MOVE;
                }
                else
                {
                    gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                }
            }
        }
    }


    public void UsePowerTile()
    {
        gm.cantPause = true;
        textInfo.gameObject.SetActive(false);
        useGhostPower = false;
        if (gm.state == GameManager.STATE_GAME.STATE_PLAYER && nbActionEffect > 0 && yellowTurn)
        {
            useTilePower = true;
            switch (tileName)
            {
                case "MaisonThe":
                    textInfoTuile.text = "Maison du Thé";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(houseOfTea.GetComponent<HouseOfTea>().GainTokenAndQI(gameObject));
                    break;
                case "HutteSorciere":
                    textInfoTuile.text = "Hutte de la sorcière";
                    card = null;
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    panelJeton.SetActive(false);
                    textInfoPhase.gameObject.SetActive(false);
                    StartCoroutine(witchHut.GetComponent<HutOfWitch>().KillGhost(gameObject));
                    break;
                case "EchoppeHerboriste":
                    textInfoTuile.text = "Echoppe de l'herboriste";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(herbalistStall.GetComponent<StallOfHerbalist>().getToken(gameObject));
                    break;
                case "AutelTaoiste":
                    textInfoTuile.text = "Autel Taoiste";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(taoisteAutel.GetComponent<TaoisteAutel>().UnhauntTile(gameObject));
                    break;
                case "Cimetiere":
                    textInfoTuile.text = "Le cimetière";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    graveyard.GetComponent<Graveyard>().Resurrect(gameObject);
                    break;
                case "PavillonVentCeleste":
                    textInfoTuile.text = "Le pavillon du vent celeste";
                    card = null;
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    textInfoPhase.gameObject.SetActive(false);
                    panelJeton.SetActive(false);
                    StartCoroutine(windCelestialFlag.GetComponent<WindCelestialFlag>().MovePlayerAndGhost(gameObject));
                    break;
                case "TourVeilleurNuit":
                    textInfoTuile.text = "Tour du veilleur de nuit";
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    StartCoroutine(nightTower.GetComponent<NightTower>().RetreatGhost(gameObject));
                    break;
                case "CerclePriere":
                    textInfoTuile.text = "Le cercle de prière";
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    StartCoroutine(priestCircle.GetComponent<PriestCircle>().reduceGhostLife(gameObject));
                    break;
                case "TempleBouddhiste":
                    textInfoTuile.text = "Temple Bouddhiste";
                    gameObject.GetComponent<Deplacement>().enabled = false;
                    canLaunchDice = false;
                    canLaunchBlackDice = false;
                    bouddhisteTemple.GetComponent<BouddhisteTemple>().getBouddha(gameObject);
                    break;
                default:
                    break;
            }
            nbActionEffect -= 1;
            nbActionBattle = 0;
        }
    }


    public IEnumerator PocheSansFond()
    {
        gm.cantPause = true;
        gm.choose = false;
        gm.panelButtonChoice.SetActive(true);
        infoPower = gm.panelButtonChoice.transform.GetChild(0).GetComponent<Text>();
        infoPower.text = "Veuillez choisir votre jeton : ";
        while (!gm.choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (gm.choose)
        {
            gm.panelButtonChoice.SetActive(false);
            gm.choose = false;
        }
        switch (gm.choseenToken)
        {
            case "Red":
                if (gm.tokenStock.nbRedToken == 0)
                {
                    textInfo.text = "Il n'y a plus de jetons rouges, veuillez choisir une autre couleur";
                    textInfo.gameObject.SetActive(true);
                    StopCoroutine(PocheSansFond());
                    StartCoroutine(PocheSansFond());
                }
                else
                {
                    gm.tokenStock.nbRedToken -= 1;
                    NbRedToken += 1;
                    gm.cantPause = false;
                }
                break;
            case "Blue":
                if (gm.tokenStock.nbBlueToken == 0)
                {
                    textInfo.text = "Il n'y a plus de jetons bleus, veuillez choisir une autre couleur";
                    textInfo.gameObject.SetActive(true);
                    StopCoroutine(PocheSansFond());
                    StartCoroutine(PocheSansFond());
                }
                else
                {
                    gm.tokenStock.nbBlueToken -= 1;
                    gm.cantPause = false;
                    NbBlueToken += 1;

                }
                break;
            case "Green":
                if (gm.tokenStock.nbGreenToken == 0)
                {
                    textInfo.text = "Il n'y a plus de jetons verts, veuillez choisir une autre couleur";
                    textInfo.gameObject.SetActive(true);
                    StopCoroutine(PocheSansFond());
                    StartCoroutine(PocheSansFond());
                }
                else
                {
                    gm.tokenStock.nbGreenToken -= 1;
                    NbGreenToken += 1;
                    gm.cantPause = false;
                }
                break;
            case "Yellow":
                if (gm.tokenStock.nbYellowToken == 0)
                {
                    textInfo.text = "Il n'y a plus de jetons jaunes, veuillez choisir une autre couleur";
                    textInfo.gameObject.SetActive(true);
                    StopCoroutine(PocheSansFond());
                    StartCoroutine(PocheSansFond());
                }
                else
                {
                    gm.tokenStock.nbYellowToken -= 1;
                    NbYellowToken += 1;
                    gm.cantPause = false;
                }
                break;
            case "Black":
                if (gm.tokenStock.nbBlackToken == 0)
                {
                    textInfo.text = "Il n'y a plus de jetons noirs, veuillez choisir une autre couleur";
                    textInfo.gameObject.SetActive(true);
                    StopCoroutine(PocheSansFond());
                    StartCoroutine(PocheSansFond());
                }
                else
                {
                    gm.tokenStock.nbBlackToken -= 1;
                    NbBlackToken += 1;
                    gm.cantPause = false;
                }
                break;
            default:
                break;
        }
    }

    public IEnumerator MantraAffaiblissement()
    {
        gm.cantPause = true;
        if (nbMantraToken > 0)
        {
            //Recupérer le fantôme ciblé // Seulement si le joueur a encore son jeton mantra // Doit le jouer AVANT le combat
            choose = false;
            textInfoPhase.gameObject.SetActive(false);
            board.mustChooseGhost = true;
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
                panelBluePlace.SetActive(false);
                panelRedPlace.SetActive(false);
                panelGreenPlace.SetActive(false);
                panelYellowPlace.SetActive(false);
                textInfoPhase.gameObject.SetActive(true);
                choose = false;
            }
            GameObject newMantraToken = Instantiate(mantraToken);
            newMantraToken.transform.SetParent(ghostToWeakned.transform);
            newMantraToken.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            board.mustChooseGhost = false;
            gm.cantPause = false;
        }
    }

    public IEnumerator LaunchDice()
    {
        gm.cantPause = true;
        if (gm.state == GameManager.STATE_GAME.STATE_PLAYER && nbActionBattle > 0 && yellowTurn)
        {
            useGhostPower = false; // A Voir si utile
            textInfo.gameObject.SetActive(false);
            gm.choose = false;
            choosePriority = false;
            gameObject.GetComponent<Deplacement>().enabled = false;
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
                    textNbWhiteFace.text = "Nombre de face blanches restantes : " + nbWhiteFace.ToString();
                    textNbWhiteFace.gameObject.SetActive(true);
                    infosWhiteFace = gm.panelButtonChoice.transform.GetChild(0).GetComponent<Text>();
                    infosWhiteFace.text = "Veuillez choisir la couleur de vos faces blanches : ";
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
            textNbWhiteFace.gameObject.SetActive(false);
            yield return new WaitForSeconds(2.0f);
            gm.panelButtonChoice.SetActive(false);

            //Partie combat
            if (ghost1 != null || ghost2 != null)
            {
                if (ghost1 != null && ghost2 != null)
                {
                    panelPrio.SetActive(true);
                    string nameOne = ghost1.name;
                    nameOne = nameOne.Replace("(Clone)", "");
                    buttonGhost1.transform.GetChild(0).GetComponent<Text>().text = nameOne;
                    string nameTwo = ghost2.name;
                    nameTwo = nameTwo.Replace("(Clone)", "");
                    buttonGhost2.transform.GetChild(0).GetComponent<Text>().text = nameTwo;
                    while (!choosePriority)
                    {
                        yield return new WaitForSeconds(1.0f);
                    }
                    if (priority == ghost1.name)
                    {
                        panelPrio.SetActive(false);
                        if (ghost1.name == "HowlingNightmare(Clone)")
                        {
                            if (ghost1.GetComponent<Ghost>().hasMustBeLonelyOnLinePower)
                            {
                                ghost1.GetComponent<GhostPower>().CheckIfLonely();
                            }
                            if (ghost1.GetComponent<GhostPower>().lineIsEmpty)
                            {
                                Attack(ghost1);
                            }
                        }
                        else
                        {
                            Attack(ghost1);
                        }
                        yield return new WaitForSeconds(1.5f);
                        if (ghost2.name == "HowlingNightmare(Clone)")
                        {
                            if (ghost2.GetComponent<Ghost>().hasMustBeLonelyOnLinePower)
                            {
                                ghost2.GetComponent<GhostPower>().CheckIfLonely();
                            }
                            if (ghost2.GetComponent<GhostPower>().lineIsEmpty)
                            {
                                Attack(ghost2);
                                nbActionBattle -= 1;
                            }
                        }
                        else
                        {
                            Attack(ghost2);
                            nbActionBattle -= 1;
                        }
                        yield return new WaitForSeconds(0.5f);
                    }
                    else
                    {
                        panelPrio.SetActive(false);
                        if (ghost2.name == "HowlingNightmare(Clone)")
                        {
                            if (ghost2.GetComponent<Ghost>().hasMustBeLonelyOnLinePower)
                            {
                                ghost2.GetComponent<GhostPower>().CheckIfLonely();
                            }
                            if (ghost2.GetComponent<GhostPower>().lineIsEmpty)
                            {
                                Attack(ghost2);
                            }
                        }
                        else
                        {
                            Attack(ghost2);
                        }
                        yield return new WaitForSeconds(1.5f);
                        if (ghost1.name == "HowlingNightmare(Clone)")
                        {
                            if (ghost1.GetComponent<Ghost>().hasMustBeLonelyOnLinePower)
                            {
                                ghost1.GetComponent<GhostPower>().CheckIfLonely();
                            }
                            if (ghost1.GetComponent<GhostPower>().lineIsEmpty)
                            {
                                Attack(ghost1);
                                nbActionBattle -= 1;
                            }
                        }
                        else
                        {
                            Attack(ghost1);
                            nbActionBattle -= 1;
                        }
                        yield return new WaitForSeconds(0.5f);
                    }
                }
                else if (ghost1 == null && ghost2 != null)
                {
                    if (ghost2.name == "HowlingNightmare(Clone)")
                    {
                        if (ghost2.GetComponent<Ghost>().hasMustBeLonelyOnLinePower)
                        {
                            ghost2.GetComponent<GhostPower>().CheckIfLonely();
                        }
                        if (ghost2.GetComponent<GhostPower>().lineIsEmpty)
                        {
                            Attack(ghost2);
                            nbActionBattle -= 1;
                        }
                    }
                    else
                    {
                        Attack(ghost2);
                        nbActionBattle -= 1;
                    }
                    yield return new WaitForSeconds(0.5f);
                }
                else if (ghost1 != null && ghost2 == null)
                {
                    if (ghost1.name == "HowlingNightmare(Clone)")
                    {
                        if (ghost1.GetComponent<Ghost>().hasMustBeLonelyOnLinePower)
                        {
                            ghost1.GetComponent<GhostPower>().CheckIfLonely();
                        }
                        if (ghost1.GetComponent<GhostPower>().lineIsEmpty)
                        {
                            Attack(ghost1);
                            nbActionBattle -= 1;
                        }
                    }
                    else
                    {
                        Attack(ghost1);
                        nbActionBattle -= 1;
                    }
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (ghost1 == null && ghost2 == null)
            {
                nbActionBattle -= 1;
            }
            yield return new WaitForSeconds(0.5f);
            nbActionEffect = 0;
            gm.cantPause = false;
            nbRedFace = 0;
            nbBlackFace = 0;
            nbBlueFace = 0;
            nbYellowFace = 0;
            nbGreenFace = 0;
            canLaunchDice = true;
            canLaunchBlackDice = true;
            gameObject.GetComponent<Deplacement>().enabled = true;
            updateUI();
        }
    }

    public void checkPosition()
    {
        RaycastHit hitXdirection;
        RaycastHit hitZdirection;
        if (Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitXdirection.collider.gameObject;
            positionTwo = hitZdirection.collider.gameObject;
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitXdirection.collider.gameObject;
            positionTwo = hitZdirection.collider.gameObject;
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitXdirection.collider.gameObject;
            positionTwo = hitZdirection.collider.gameObject;
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitXdirection.collider.gameObject;
            positionTwo = hitZdirection.collider.gameObject;
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitXdirection.collider.gameObject;
            positionTwo = null;
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitZdirection.collider.gameObject;
            positionTwo = null;
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitXdirection.collider.gameObject;
            positionTwo = null;
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f, layerYellow))
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            Debug.DrawRay(transform.position, Vector3.back, Color.red);
            positionOne = hitZdirection.collider.gameObject;
            positionTwo = null;
        }
        else
        {
            positionOne = null;
            positionTwo = null;
        }
    }

    public void checkGhost()
    {
        RaycastHit hitXdirection;
        RaycastHit hitZdirection;
        if (Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f, layerYellow))
        {
            if (hitXdirection.collider.transform.childCount > 4)
            {
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion = null;
                ghost1 = null;
            }

            if (hitZdirection.collider.transform.childCount > 4)
            {
                explosion2 = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion2 = null;
                ghost2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f, layerYellow))
        {
            if (hitZdirection.collider.transform.childCount > 4)
            {
                explosion = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion = null;
                ghost1 = null;
            }

            if (hitXdirection.collider.transform.childCount > 4)
            {
                explosion2 = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitXdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion2 = null;
                ghost2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f, layerYellow))
        {
            if (hitXdirection.collider.transform.childCount > 4)
            {
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion = null;
                ghost1 = null;
            }

            if (hitZdirection.collider.transform.childCount > 4)
            {
                explosion2 = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion2 = null;
                ghost2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f, layerYellow) && Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f, layerYellow))
        {
            if (hitZdirection.collider.transform.childCount > 4)
            {
                explosion = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitZdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion = null;
                ghost1 = null;
            }

            if (hitXdirection.collider.transform.childCount > 4)
            {
                explosion2 = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitXdirection.collider.transform.GetChild(4).gameObject;
            }
            else
            {
                explosion2 = null;
                ghost2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f, layerYellow))
        {
            if (hitXdirection.collider.transform.childCount > 4)
            {
                Debug.Log("CICIICICIC");
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = null;
                explosion2 = null;
            }
            else
            {
                explosion = null;
                ghost1 = null;
                ghost2 = null;
                explosion2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f, layerYellow))
        {
            if (hitZdirection.collider.transform.childCount > 4)
            {
                explosion = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitZdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = null;
                explosion2 = null;
            }
            else
            {
                explosion = null;
                ghost1 = null;
                ghost2 = null;
                explosion2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f, layerYellow))
        {
            if (hitXdirection.collider.transform.childCount > 4)
            {
                explosion = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitXdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = null;
                explosion2 = null;
            }
            else
            {
                explosion = null;
                ghost1 = null;
                ghost2 = null;
                explosion2 = null;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f, layerYellow))
        {
            if (hitZdirection.collider.transform.childCount > 4)
            {
                explosion = hitZdirection.collider.transform.GetChild(0).gameObject;
                ghost1 = hitZdirection.collider.transform.GetChild(4).gameObject;
                ghost2 = null;
                explosion2 = null;
            }
            else
            {
                explosion = null;
                ghost1 = null;
                ghost2 = null;
                explosion2 = null;
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
        textNbTokenYinYangYellow.text = "x " + NbYinYangYellowToken;
        textNbTokenPower.text = "x " + NbPowerToken;
        textNbBouddha.text = "x " + NbBouddha;
        //textNbTokenPower.text = "x " + NbBlackToken; // Jeton mantra, juste pour le joueur jaune
        textNbDice.text = "Dés en stock : " + gm.nbDice.ToString();
        textTurn.text = "Tour : " + gm.turn.ToString();
        update = false;
    }

    public void SetPriority(Button buttonClick)
    {
        if (yellowTurn)
        {
            priority = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
            choosePriority = true;
        }
    }

    public void Attack(GameObject ghost)
    {
        if (ghost.GetComponent<Ghost>().canBeDestroyByDice)
        {
            //On ajouteras des particules à la mort du fantome (style explosion)
            canKillGhost = true;
            int tempLife = ghost.GetComponent<Ghost>().life;
            switch (ghost.GetComponent<Ghost>().couleur)
            {
                case "red":
                    int tempRed = nbRedFace;
                    nbRedFace -= ghost.GetComponent<Ghost>().life;
                    ghost.GetComponent<Ghost>().life -= tempRed;
                    Debug.Log(ghost.GetComponent<Ghost>().life);
                    break;
                case "yellow":
                    int tempYellow = nbYellowFace;
                    nbYellowFace -= ghost.GetComponent<Ghost>().life;
                    ghost.GetComponent<Ghost>().life -= tempYellow;
                    Debug.Log(ghost.GetComponent<Ghost>().life);
                    break;
                case "blue":
                    int tempBlue = nbBlueFace;
                    nbBlueFace -= ghost.GetComponent<Ghost>().life;
                    ghost.GetComponent<Ghost>().life -= tempBlue;
                    Debug.Log(ghost.GetComponent<Ghost>().life);
                    break;
                case "black":
                    int tempBlack = nbBlackFace;
                    nbBlackFace -= ghost.GetComponent<Ghost>().life;
                    ghost.GetComponent<Ghost>().life -= tempBlack;
                    Debug.Log(ghost.GetComponent<Ghost>().life);
                    break;
                case "green":
                    int tempGreen = nbGreenFace;
                    nbGreenFace -= ghost.GetComponent<Ghost>().life;
                    ghost.GetComponent<Ghost>().life -= tempGreen;
                    Debug.Log(ghost.GetComponent<Ghost>().life);
                    break;
                default:
                    break;
            }

            if (ghost.GetComponent<Ghost>().life <= 0 && canKillGhost)
            {
                canKillGhost = false;
                KillGhost(ghost);
            }

            //Si on l'as pas tué avec les dés, on lui baisse sa vie avec le cercle de prière et/ou le jeton mantra
            ghost.GetComponent<Ghost>().ReduceLife();

            if (ghost.GetComponent<Ghost>().life <= 0 && canKillGhost)
            {
                canKillGhost = false;
                KillGhost(ghost);
            }

            //Ensuite on décomptera les jetons
            if (gm.canUseTaoToken)
            {
                if (ghost.GetComponent<Ghost>().couleur == "red")
                {
                    if (nbRedToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempRedToken = nbRedToken;
                        nbRedToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempRedToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "blue")
                {
                    if (nbBlueToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempBlueToken = nbBlueToken;
                        nbBlueToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempBlueToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "green")
                {

                    if (nbGreenToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempGreenToken = nbGreenToken;
                        nbGreenToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempGreenToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "yellow")
                {
                    if (nbYellowToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempYellowToken = nbYellowToken;
                        nbYellowToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempYellowToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "black")
                {
                    if (nbBlackToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempBlackToken = nbBlackToken;
                        nbBlackToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempBlackToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }

                if (ghost.GetComponent<Ghost>().life <= 0 && canKillGhost)
                {
                    canKillGhost = false;
                    KillGhost(ghost);
                }
            }

            ghost.GetComponent<Ghost>().life = tempLife;
            return;

        }
        else
        {
            canKillGhost = true;
            int tempLife = ghost.GetComponent<Ghost>().life;
            //Si on l'as pas tué avec les dés, on lui baisse sa vie avec le cercle de prière et/ou le jeton mantra
            ghost.GetComponent<Ghost>().ReduceLife();

            if (ghost.GetComponent<Ghost>().life <= 0 && canKillGhost)
            {
                canKillGhost = false;
                KillGhost(ghost);
            }

            //Ensuite on décomptera les jetons
            if (gm.canUseTaoToken)
            {
                if (ghost.GetComponent<Ghost>().couleur == "red")
                {
                    if (nbRedToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempRedToken = nbRedToken;
                        nbRedToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempRedToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "blue")
                {
                    if (nbBlueToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempBlueToken = nbBlueToken;
                        nbBlueToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempBlueToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "green")
                {

                    if (nbGreenToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempGreenToken = nbGreenToken;
                        nbGreenToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempGreenToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "yellow")
                {
                    if (nbYellowToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempYellowToken = nbYellowToken;
                        nbYellowToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempYellowToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }
                else if (ghost.GetComponent<Ghost>().couleur == "black")
                {
                    if (nbBlackToken >= ghost.GetComponent<Ghost>().life)
                    {
                        int tempBlackToken = nbBlackToken;
                        nbBlackToken -= ghost.GetComponent<Ghost>().life;
                        ghost.GetComponent<Ghost>().life -= tempBlackToken;
                        Debug.Log(ghost.GetComponent<Ghost>().life);
                    }
                }

                if (ghost.GetComponent<Ghost>().life <= 0 && canKillGhost)
                {
                    canKillGhost = false;
                    KillGhost(ghost);
                }
            }
            ghost.GetComponent<Ghost>().life = tempLife;
            return;
        }
    }

    public void KillGhost(GameObject ghost)
    {
        //Décompte du nombre de fantômes sur le plateau
        if (ghost.transform.parent.parent.GetComponent<boardColor>().color == "blue")
        {
            gm.blueBoard.nbCardOnBoard--;
        }
        else if (ghost.transform.parent.parent.GetComponent<boardColor>().color == "red")
        {
            gm.redBoard.nbCardOnBoard--;
        }
        else if (ghost.transform.parent.parent.GetComponent<boardColor>().color == "green")
        {
            gm.greenBoard.nbCardOnBoard--;
        }
        else if (ghost.transform.parent.parent.GetComponent<boardColor>().color == "yellow")
        {
            gm.yellowBoard.nbCardOnBoard--;
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
        gm.RegainMantraToken();
    }

    public IEnumerator LaunchBlackDice()
    {
        if (yellowTurn)
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
                /*textInfo.text = resultFace;
                textInfo.gameObject.SetActive(true);*/
            }
            switch (resultFace)
            {
                case "HauntedFace":
                    textInfo.text = "Hante la tuile sur laquelle vous vous trouvez";
                    textInfo.gameObject.SetActive(true);
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
                        case "CerclePriere":
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
                    textInfo.text = "Piochez un nouveau fantôme";
                    textInfo.gameObject.SetActive(true);
                    //player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_DRAW;
                    DrawAGhost();
                    //To verify if we need that
                    canLaunchBlackDice = true;
                    useTilePower = false;
                    canLaunchDice = true;
                    gameObject.GetComponent<Deplacement>().enabled = true;
                    break;
                case "LoseJetonFace":
                    textInfo.text = "Perdez tous vos jetons";
                    textInfo.gameObject.SetActive(true);
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
                    textInfo.text = "Perdez 1 QI";
                    textInfo.gameObject.SetActive(true);
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
                    textInfo.text = "Pas d'effet";
                    textInfo.gameObject.SetActive(true);
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
            //textInfo.gameObject.SetActive(false);
        }
    }


    public void EndTurn()
    {
        if (gm.state == GameManager.STATE_GAME.STATE_PLAYER && yellowTurn && nbActionBattle == 0 && nbActionEffect == 0)
        {
            gm.state = GameManager.STATE_GAME.STATE_GHOSTPOWER;
            gm.turn++;
            gm.turnPlayer++;
            gm.nextTurn();
            alreadyMove = false;
            stop = false;
            updateUI();
            nbActionBattle = 1;
            nbActionEffect = 1;
        }
    }


    public void ActivateInGameEffect()
    {
        if (yellowTurn)
        {
            int maxChild = gm.yellowBoard.gameObject.transform.childCount;
            for (int i = 0; i < maxChild; i++)
            {
                if (gm.yellowBoard.gameObject.transform.GetChild(i).childCount >= 5)
                {
                    if (gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(4).GetComponent<Ghost>().inGamePower && !gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(4).name.Contains("Bouddha"))
                    {
                        gm.yellowBoard.gameObject.transform.GetChild(i).GetChild(4).GetComponent<Ghost>().UseInGamePower(gameObject);
                    }
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


    public void CheckDistance()
    {
        if (yellowTurn || useRedPower || useWindCelestialPower)
        {
            switch (tileName)
            {
                case "MaisonThe":
                    gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    if (Vector3.Distance(houseOfTea.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(houseOfTea.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    break;
                case "HutteSorciere":
                    gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    if (Vector3.Distance(witchHut.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(witchHut.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    break;
                case "EchoppeHerboriste":
                    gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    if (Vector3.Distance(herbalistStall.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(herbalistStall.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    break;
                case "AutelTaoiste":
                    gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    if (Vector3.Distance(taoisteAutel.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(taoisteAutel.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    break;
                case "Cimetiere":
                    gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    if (Vector3.Distance(graveyard.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(graveyard.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    break;
                case "PavillonVentCeleste":
                    gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    if (Vector3.Distance(windCelestialFlag.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(windCelestialFlag.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    break;
                case "TourVeilleurNuit":
                    gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    if (Vector3.Distance(nightTower.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(nightTower.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    break;
                case "CerclePriere":
                    gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    if (Vector3.Distance(priestCircle.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, bouddhisteTemple.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(priestCircle.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    break;
                case "TempleBouddhiste":
                    gm.GetComponent<GameManager>().bouddhisteTempleForDeplacement.interactable = true;
                    if (Vector3.Distance(bouddhisteTemple.transform.position, houseOfTea.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().houseOfTeaForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, witchHut.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().hutOfWitchForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, graveyard.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().graveyardForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, taoisteAutel.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().taoisteAutelForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, herbalistStall.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().herbalistStallForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, priestCircle.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().priestCircleForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, nightTower.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().nightTowerForDeplacement.interactable = false;
                    }
                    if (Vector3.Distance(bouddhisteTemple.transform.position, windCelestialFlag.transform.position) < 1.5f)
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = true;
                    }
                    else
                    {
                        gm.GetComponent<GameManager>().windCelestialFlagForDeplacement.interactable = false;
                    }
                    break;
                default:
                    break;
            }
            useRedPower = false;
        }
    }


    public void SetBouddha(Button buttonClick)
    {
        if (yellowTurn)
        {
            bouddhaChoice = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
            chooseBouddha = true;
        }
    }

    public IEnumerator PlaceBouddha()
    {
        gm.cantPause = true;
        if (yellowTurn)
        {
            chooseBouddha = false;
            if (NbBouddha > 0)
            {
                if (positionOne == null && positionTwo == null)
                {
                    textInfo.text = "Vous êtes trop loin d'une case. Vous ne pouvez pas placer de bouddha";
                    textInfo.gameObject.SetActive(true);
                    gm.cantPause = false;
                }
                else if (positionOne != null && positionTwo != null)
                {
                    //Demander un choix si qu'un bouddha. Sinon placer les 2 ?
                    if (NbBouddha == 1)
                    {
                        panelBouddha.SetActive(true);
                        buttonBouddha1.transform.GetChild(0).GetComponent<Text>().text = positionOne.name;
                        buttonBouddha2.transform.GetChild(0).GetComponent<Text>().text = positionTwo.name;
                        //Définir priorité pour ghost puis ghost2 ou ghost2 puis ghost
                        while (!chooseBouddha)
                        {
                            yield return new WaitForSeconds(1.0f);
                        }

                        if (bouddhaChoice == positionOne.name)
                        {
                            if (positionOne.transform.childCount > 4)
                            {
                                textInfo.text = "Il y a un fantôme sur cette case, vous ne pouvez pas placer de bouddha";
                                textInfo.gameObject.SetActive(true);
                                panelBouddha.SetActive(false);
                                StopCoroutine(PlaceBouddha());
                                StartCoroutine(PlaceBouddha());
                            }
                            else
                            {
                                panelBouddha.SetActive(false);
                                NbBouddha -= 1;
                                if(bouddhaOne != null)
                                {
                                    bouddhaOne.transform.parent = positionOne.transform;
                                    bouddhaOne.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                                    bouddhaOne.SetActive(true);
                                    bouddhaOne = null;
                                }
                                else if(bouddhaTwo != null)
                                {
                                    bouddhaTwo.transform.parent = positionOne.transform;
                                    bouddhaTwo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                                    bouddhaTwo.SetActive(true);
                                    bouddhaTwo = null;
                                }
                                yield return new WaitForSeconds(0.5f);
                                gm.cantPause = false;
                            }
                        }
                        else if (bouddhaChoice == positionTwo.name)
                        {
                            if (positionTwo.transform.childCount > 4)
                            {
                                textInfo.text = "Il y a un fantôme sur cette case, vous ne pouvez pas placer de bouddha";
                                textInfo.gameObject.SetActive(true);
                                panelBouddha.SetActive(false);
                                StopCoroutine(PlaceBouddha());
                                StartCoroutine(PlaceBouddha());
                            }
                            else
                            {
                                panelBouddha.SetActive(false);
                                NbBouddha -= 1;
                                if (bouddhaOne != null)
                                {
                                    bouddhaOne.transform.parent = positionOne.transform;
                                    bouddhaOne.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                                    bouddhaOne.SetActive(true);
                                    bouddhaOne = null;
                                }
                                else if (bouddhaTwo != null)
                                {
                                    bouddhaTwo.transform.parent = positionOne.transform;
                                    bouddhaTwo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                                    bouddhaTwo.SetActive(true);
                                    bouddhaTwo = null;
                                }
                                yield return new WaitForSeconds(0.5f);
                                gm.cantPause = false;
                            }
                        }
                    }
                    else if (NbBouddha == 2)
                    {
                        if (positionTwo.transform.childCount > 4)
                        {
                            textInfo.text = "Il y a un fantôme sur cette case, vous ne pouvez pas placer de bouddha";
                            textInfo.gameObject.SetActive(true);
                        }
                        else
                        {
                            NbBouddha -= 1;
                            bouddhaTwo.transform.parent = positionTwo.transform;
                            bouddhaTwo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            bouddhaTwo.SetActive(true);
                            bouddhaTwo = null;

                        }

                        if (positionOne.transform.childCount > 4)
                        {
                            textInfo.text = "Il y a un fantôme sur cette case, vous ne pouvez pas placer de bouddha";
                            textInfo.gameObject.SetActive(true);
                        }
                        else
                        {
                            bouddhaOne.transform.parent = positionOne.transform;
                            bouddhaOne.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            bouddhaOne.SetActive(true);
                            bouddhaOne = null;
                        }
                        gm.cantPause = false;
                    }
                }
                else if (positionTwo != null && positionOne == null)
                {
                    //Verif 
                    if (positionTwo.transform.childCount > 4)
                    {
                        textInfo.text = "Il y a un fantôme sur cette case, vous ne pouvez pas placer de bouddha";
                        textInfo.gameObject.SetActive(true);
                    }
                    else
                    {
                        NbBouddha -= 1;
                        if (bouddhaOne != null)
                        {
                            bouddhaOne.transform.parent = positionOne.transform;
                            bouddhaOne.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            bouddhaOne.SetActive(true);
                            bouddhaOne = null;
                        }
                        else if (bouddhaTwo != null)
                        {
                            bouddhaTwo.transform.parent = positionOne.transform;
                            bouddhaTwo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            bouddhaTwo.SetActive(true);
                            bouddhaTwo = null;
                        }
                        gm.cantPause = false;
                    }
                }
                else if (positionOne != null && positionTwo == null)
                {
                    //Verif
                    if (positionOne.transform.childCount > 4)
                    {
                        textInfo.text = "Il y a un fantôme sur cette case, vous ne pouvez pas placer de bouddha";
                        textInfo.gameObject.SetActive(true);
                    }
                    else
                    {
                        if (bouddhaOne != null)
                        {
                            bouddhaOne.transform.parent = positionOne.transform;
                            bouddhaOne.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            bouddhaOne.SetActive(true);
                            bouddhaOne = null;
                        }
                        else if (bouddhaTwo != null)
                        {
                            bouddhaTwo.transform.parent = positionOne.transform;
                            bouddhaTwo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                            bouddhaTwo.SetActive(true);
                            bouddhaTwo = null;
                        }
                        gm.cantPause = false;
                    }
                }
            }
            else
            {
                textInfo.text = "Vous n'avez pas de bouddha, pourquoi voulez vous en placer ?";
                textInfo.gameObject.SetActive(true);
                gm.cantPause = false;
            }
        }
    }

    public void MustChooseGhost(Button buttonClick)
    {
        chooseenGhost = buttonClick.name;
        switch (chooseenGhost)
        {
            case "BlueOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "RedOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "RedTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "RedThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount > 4)
                {
                    ghostToWeakned = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.GetChild(4).gameObject;
                }
                break;
        }
        choose = true;
    }

    public void SetYinYang(Button buttonClick)
    {
        if (yellowTurn)
        {
            effectYinYang = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
            chooseEffectYinYang = true;
        }
    }

    public void SetTileYinYang(Button buttonClick)
    {
        if (yellowTurn)
        {
            tileYinYang = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
            chooseTile = true;
        }
    }

    public IEnumerator UseYinYangToken()
    {
        gm.cantPause = true;
        wantUnhaunted = true;
        if (yellowTurn && nbYinYangYellowToken > 0)
        {
            chooseEffectYinYang = false;
            panelYinYang.SetActive(true);
            CheckTileToUnhaunted();
            //On choisit quel effet on veut faire
            while (!chooseEffectYinYang)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseEffectYinYang)
            {
                panelYinYang.SetActive(false);
                chooseEffectYinYang = false;
            }

            //On choisit la tuile
            textUnhaunted.text = "Veuillez choisir la tuile sur laquelle vous voulez agir : ";
            panelTile.SetActive(true);
            while (!chooseTile)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseTile)
            {
                panelTile.SetActive(false);
                chooseTile = false;
            }
            switch (effectYinYang)
            {
                case "Déshanter une tuile":
                    switch (tileYinYang)
                    {
                        case "Maison du The":
                            houseOfTea.GetComponent<HouseOfTea>().hauntedTile = false;
                            houseOfTea.GetComponent<HouseOfTea>().Unhaunted();
                            break;
                        case "Hutte de la Sorciere":
                            witchHut.GetComponent<HutOfWitch>().hauntedTile = false;
                            witchHut.GetComponent<HutOfWitch>().Unhaunted();
                            break;
                        case "Echoppe de L'herboriste":
                            herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = false;
                            herbalistStall.GetComponent<StallOfHerbalist>().Unhaunted();
                            break;
                        case "Autel Taoiste":
                            taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = false;
                            taoisteAutel.GetComponent<TaoisteAutel>().Unhaunted();
                            break;
                        case "Cimetiere":
                            graveyard.GetComponent<Graveyard>().hauntedTile = false;
                            graveyard.GetComponent<Graveyard>().Unhaunted();
                            break;
                        case "Pavillon du Vent Celeste":
                            windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = false;
                            windCelestialFlag.GetComponent<WindCelestialFlag>().Unhaunted();
                            break;
                        case "Tour du Veilleur de Nuit":
                            nightTower.GetComponent<NightTower>().hauntedTile = false;
                            nightTower.GetComponent<NightTower>().Unhaunted();
                            break;
                        case "Cercle de priere":
                            priestCircle.GetComponent<PriestCircle>().hauntedTile = false;
                            priestCircle.GetComponent<PriestCircle>().Unhaunted();
                            break;
                        case "Temple Bouddhiste":
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = false;
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().Unhaunted();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Utiliser une tuile":
                    switch (tileYinYang)
                    {
                        case "Maison du The":
                            StartCoroutine(houseOfTea.GetComponent<HouseOfTea>().GainTokenAndQI(gameObject));
                            break;
                        case "Hutte de la Sorciere":
                            StartCoroutine(witchHut.GetComponent<HutOfWitch>().KillGhost(gameObject));
                            break;
                        case "Echoppe de L'herboriste":
                            StartCoroutine(herbalistStall.GetComponent<StallOfHerbalist>().getToken(gameObject));
                            break;
                        case "Autel Taoiste":
                            StartCoroutine(taoisteAutel.GetComponent<TaoisteAutel>().UnhauntTile(gameObject));
                            break;
                        case "Cimetiere":
                            graveyard.GetComponent<Graveyard>().Resurrect(gameObject);
                            break;
                        case "Pavillon du Vent Celeste":
                            StartCoroutine(windCelestialFlag.GetComponent<WindCelestialFlag>().MovePlayerAndGhost(gameObject));
                            break;
                        case "Tour du Veilleur de Nuit":
                            StartCoroutine(nightTower.GetComponent<NightTower>().RetreatGhost(gameObject));
                            break;
                        case "Cercle de priere":
                            StartCoroutine(priestCircle.GetComponent<PriestCircle>().reduceGhostLife(gameObject));
                            break;
                        case "Temple Bouddhiste":
                            bouddhisteTemple.GetComponent<BouddhisteTemple>().getBouddha(gameObject);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            wantUnhaunted = false;
            nbYinYangYellowToken = 0;
            gm.cantPause = false;
            update = true;
        }
    }

    public void CheckTileToUnhaunted()
    {
        if (yellowTurn && wantUnhaunted)
        {
            if (houseOfTea.GetComponent<HouseOfTea>().hauntedTile)
            {
                gm.GetComponent<GameManager>().houseOfTeaForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().houseOfTeaForHaunt.interactable = false;
            }
            if (witchHut.GetComponent<HutOfWitch>().hauntedTile)
            {
                gm.GetComponent<GameManager>().hutOfWitchForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().hutOfWitchForHaunt.interactable = false;
            }

            if (priestCircle.GetComponent<PriestCircle>().hauntedTile)
            {
                gm.GetComponent<GameManager>().priestCircleForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().priestCircleForHaunt.interactable = false;
            }

            if (taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile)
            {
                gm.GetComponent<GameManager>().taoisteAutelForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().taoisteAutelForHaunt.interactable = false;
            }

            if (nightTower.GetComponent<NightTower>().hauntedTile)
            {
                gm.GetComponent<GameManager>().nightTowerForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().nightTowerForHaunt.interactable = false;
            }

            if (graveyard.GetComponent<Graveyard>().hauntedTile)
            {
                gm.GetComponent<GameManager>().graveyardForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().graveyardForHaunt.interactable = false;
            }

            if (herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile)
            {
                gm.GetComponent<GameManager>().herbalistStallForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().herbalistStallForHaunt.interactable = false;
            }

            if (windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile)
            {
                gm.GetComponent<GameManager>().windCelestialFlagForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().windCelestialFlagForHaunt.interactable = false;
            }

            if (bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile)
            {
                gm.GetComponent<GameManager>().bouddhisteTempleForHaunt.interactable = true;
            }
            else
            {
                gm.GetComponent<GameManager>().bouddhisteTempleForHaunt.interactable = false;
            }
        }
    }

    public void checkTilePower(string tile)
    {
        switch (tile)
        {
            case "MaisonThe":
                textTilePowerDescription.text = "Maison de Thé: \n\n- Gagnez 1 QI et 1 jeton de la couleur de votre choix, puis piochez une carte fantôme.";
                break;
            case "HutteSorciere":
                textTilePowerDescription.text = "Hutte de la sorcière : \n\n- Perdez 1 QI pour éliminer n’importe quel fantôme du plateau.Les pouvoirs de ce dernier ne sont pas appliqués.Vous ne pouvez pas éliminer les boss de cette manière. Pas de récompense/malus en éliminant un fantôme de cette manière.";
                break;
            case "EchoppeHerboriste":
                textTilePowerDescription.text = "Echoppe de l’Herboriste : \n\n- Lancez 2 dés et obtenez les jetons des couleurs correspondantes(blanc compte pour n’importe qu’elle couleur). Mais attention, s’il n’y a plus assez de type de jeton dans la réserve, vous ne gagnez rien.";
                break;
            case "AutelTaoiste":
                textTilePowerDescription.text = "Autel Taoiste: \n\n- Déshantez une tuile puis piochez une carte fantôme.";
                break;
            case "Cimetiere":
                textTilePowerDescription.text = "Cimetière : \n\n- Ressuscitez un joueur avec 2 QI.Puis lancez le dé noir.";
                break;
            case "PavillonVentCeleste":
                textTilePowerDescription.text = "Pavillon du vent céleste : \n\n- Déplacez un autre joueur d’une case puis déplacez un fantôme sur un autre emplacement libre.";
                break;
            case "TourVeilleurNuit":
                textTilePowerDescription.text = "Tour du veilleur de nuit : \n\n- Reculez tous les fantômes hanteurs d’un plateau sur leur case de départ.";
                break;
            case "CerclePriere":
                textTilePowerDescription.text = "Cercle de Prière : \n\n- Permet de mettre un pion de la réserve sur la tuile et d'affaiblir tout les fantômes de la couleur concernée de 1 point. Cet effet reste jusqu’à qu’un autre joueur change la couleur du jeton.";
                break;
            case "TempleBouddhiste":
                textTilePowerDescription.text = "Temple Bouddhiste : \n\n- Prenez un bouddha. A votre prochain tour, vous pouvez le poser sur un emplacement de fantôme libre adjacent à votre position. Le Bouddha reste jusqu'à ce qu’il élimine un fantôme, puis revient dans le stock. Ne marche pas sur les boss. Les récompense/malus ne sont pas appliqués.";
                break;
            default:
                break;
        }
    }
}
