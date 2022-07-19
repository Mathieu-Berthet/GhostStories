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


    [Header("Booleen bloc")]
    public bool canUsePower;

    public bool useTilePower;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
