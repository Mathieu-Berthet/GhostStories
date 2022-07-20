using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour
{
    [Header("Game Manager")]
    public GameManager gm;

    [Header("Infos joueur")]

    [SerializeField]
    private int qi = 0; // PV du joueur
    [SerializeField]
    protected int nbBlueToken;
    [SerializeField]
    protected int nbRedToken;
    [SerializeField]
    protected int nbGreenToken;
    [SerializeField]
    protected int nbYellowToken;
    [SerializeField]
    protected int nbBlackToken;

    [SerializeField]
    protected int nbBouddha; // Pour les bouddha du temple bouddhiste

    public string colorPlayer;


    [Header("Booleen bloc")]
    public bool useTilePower;
    public bool useGhostPower;

    //Les dés et leurs résultats
    [Header("Les dés")]
    [SerializeField]
    protected GameObject dice;
    [SerializeField]
    protected CubeScript cube;

    protected GameObject diceOne;
    protected GameObject diceTwo;
    protected GameObject diceThree;

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
    protected GameObject blackDice;
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
    protected PoolManagerDeck deck;
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
    public GameObject panelToken;

    [SerializeField]
    protected GameObject defausse;


    public GameObject panelJeton;
    public Text textInfoPhase;
    public Text textInfoPower;
    public Text textInfo;

    public bool update;

    public bool mustLoseLife;

    //public bool blueTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool VerifyBoard(boardColor board)
    {
        if(board.nbCardOnBoard == 3 && !useTilePower)
        {
            mustLoseLife = true;
        }
        else
        {
            mustLoseLife = false;
        }
        return mustLoseLife;
    }

    public void DrawAGhost()
    {
        gm.cantPause = true;
        card = null;
        if (gm.state == GameManager.STATE_GAME.STATE_DRAW || useTilePower)
        {
            //hasDraw = true;
            panelJeton.SetActive(false);
            textInfoPhase.gameObject.SetActive(false);
            textInfoPower.gameObject.SetActive(false);
            textInfo.text = " ";
            if (gm.blueBoard.nbCardOnBoard == 3 && gm.redBoard.nbCardOnBoard == 3 && gm.greenBoard.nbCardOnBoard == 3 && gm.yellowBoard.nbCardOnBoard == 3)
            {
                textInfo.gameObject.SetActive(true);
                textInfo.text = "Vous ne pouvez pas piocher un autre fantôme, il y en a trop sur le terrain";
                //hasDraw = false;
                textInfoPhase.gameObject.SetActive(true);
                textInfoPower.gameObject.SetActive(true);
                gm.state = GameManager.STATE_GAME.STATE_MOVE;
                gm.cantPause = false;
                return;
            }
            if (gm.turnPlayer == GameManager.STATE_PLAYER_TURN.BLUE_PLAYER_TURN)
            {
                if (VerifyBoard(gm.blueBoard))
                {
                    LoseLife();
                    return;
                }
            }
            else if (gm.turnPlayer == GameManager.STATE_PLAYER_TURN.RED_PLAYER_TURN)
            {
                if (VerifyBoard(gm.redBoard))
                {
                    LoseLife();
                    return;
                }
            }
            else if (gm.turnPlayer == GameManager.STATE_PLAYER_TURN.GREEN_PLAYER_TURN)
            {
                if (VerifyBoard(gm.greenBoard))
                {
                    LoseLife();
                    return;
                }
            }
            else if (gm.turnPlayer == GameManager.STATE_PLAYER_TURN.YELLOW_PLAYER_TURN)
            {
                if (VerifyBoard(gm.yellowBoard))
                {
                    LoseLife();
                    return;
                }
            }

            SetOnPanel();
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

    private void SetOnPanel()
    {
        panelBluePlace.SetActive(true);
        panelRedPlace.SetActive(true);
        panelGreenPlace.SetActive(true);
        panelYellowPlace.SetActive(true);
    }

    private void SetOffPanel()
    {
        panelBluePlace.SetActive(false);
        panelRedPlace.SetActive(false);
        panelGreenPlace.SetActive(false);
        panelYellowPlace.SetActive(false);
    }

    private void LoseLife()
    {
        textInfo.gameObject.SetActive(true);
        textInfo.text = "Votre plateau est plein de fantômes, vous perdez une vie";
        qi -= 1;
        update = true;
        //hasDraw = false;
        textInfoPhase.gameObject.SetActive(true);
        textInfoPower.gameObject.SetActive(true);
        gm.state = GameManager.STATE_GAME.STATE_MOVE;
        gm.cantPause = false;
    }

    public void SelectGhostPosition(GameObject position)
    {
        if ((gm.state == GameManager.STATE_GAME.STATE_DRAW || useTilePower))
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
                if (position.transform.childCount > 4 && position.transform.GetChild(4).name.Contains("Bouddha"))
                {
                    if (card.GetComponent<Ghost>().canBeKillByBouddha)
                    {
                        card.transform.SetParent(defausse.transform);
                        card.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                        card.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                        BouddhisteTemple bouddhisteTempo = bouddhisteTemple.GetComponent<BouddhisteTemple>();
                        bouddhisteTempo.numberOfBouddha += 1;
                        if (bouddhisteTempo.bouddhaFirst == null)
                        {
                            bouddhisteTempo.bouddhaFirst = position.transform.GetChild(4).gameObject;
                            position.transform.GetChild(4).parent = bouddhisteTemple.transform;
                            bouddhisteTempo.bouddhaFirst.transform.localPosition = new Vector3(-0.145f, 3.0f, 0.325f);
                        }
                        else if (bouddhisteTempo.bouddhaSecond == null)
                        {
                            bouddhisteTempo.bouddhaSecond = position.transform.GetChild(4).gameObject;
                            position.transform.GetChild(4).transform.parent = bouddhisteTemple.transform;
                            bouddhisteTempo.bouddhaFirst.transform.localPosition = new Vector3(-0.325f, 3.0f, 0.325f);
                        }
                        SetOffPanel();
                        gm.panelInfoGhostPower.SetActive(false);
                        textInfo.gameObject.SetActive(false);
                        gm.drawedCard.gameObject.SetActive(false);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                        textInfoPhase.gameObject.SetActive(true);
                        textInfoPower.gameObject.SetActive(true);
                        panelJeton.SetActive(true);
                        useTilePower = false;
                        //hasDraw = false;
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
                        SetOffPanel();
                        gm.panelInfoGhostPower.SetActive(false);
                        textInfo.gameObject.SetActive(false);
                        gm.drawedCard.gameObject.SetActive(false);
                        gameObject.GetComponent<Deplacement>().enabled = true;
                        textInfoPhase.gameObject.SetActive(true);
                        textInfoPower.gameObject.SetActive(true);
                        panelJeton.SetActive(true);
                        useTilePower = false;
                        //hasDraw = false;
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
                    StartCoroutine(gm.audio.PlayApparitionFX(gm.audio.GetComponent<AudioManager>().ghostAppearFX, 4.0f));
                    SetOffPanel();
                    gm.panelInfoGhostPower.SetActive(false);
                    textInfo.gameObject.SetActive(false);
                    gm.drawedCard.gameObject.SetActive(false);
                    gameObject.GetComponent<Deplacement>().enabled = true;
                    textInfoPhase.gameObject.SetActive(true);
                    textInfoPower.gameObject.SetActive(true);
                    panelJeton.SetActive(true);
                    useTilePower = false;
                    //hasDraw = false;
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


}
