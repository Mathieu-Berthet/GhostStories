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

    private bool useTilePower;
    private bool fight;


    //Les tuiles
    [SerializeField]
    private GameObject houseOfTea;
    [SerializeField]
    private GameObject graveyard;
    [SerializeField]
    private GameObject bouddhisteTemple;
    [SerializeField]
    private GameObject priestCircle;
    [SerializeField]
    private GameObject taoisteAutel;
    [SerializeField]
    private GameObject herbalistStall;
    [SerializeField]
    private GameObject witchHut;
    [SerializeField]
    private GameObject windCelestialFlag;
    [SerializeField]
    private GameObject nightTower;

    public string tileName;

    [SerializeField]
    private PoolManagerDeck deck;
    [SerializeField]
    private GameObject card;
    public Image drawedCard;

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




    // Use this for initialization
    void Start ()
    {
        Qi = 4; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        NbBlueToken = 1;
        NbRedToken = 0;
        NbYellowToken = 0;
        NbGreenToken = 0;
        NbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        NbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        NbYinYangBlueToken = 1; //Max possible.

        deck = GameObject.Find("Deck").GetComponent<PoolManagerDeck>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DrawAGhost();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            SelectGhostPosition();
        }
    }


    public void DrawAGhost()
    {
        card = deck.GetPoolByName(PoolNameDeck.ghost).GetItem(transform, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, true, false, 0);
        card.transform.SetParent(gameObject.transform);
        drawedCard.material = card.transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    public void SelectGhostPosition()
    {
        //Must change the selected case. With a real selection.
        card.transform.SetParent(GameObject.Find("PlateauJoueurRouge").transform.GetChild(0).transform);
        card.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        card.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 180.0f);
        card.transform.localScale = new Vector3(10.0f, 10.0f, 1);
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
        RaycastHit hitt;
        if (Physics.Raycast(transform.position, Vector3.down, out hitt, 1.0f))
        {
            tileName = hitt.transform.gameObject.name;
        }

        switch(tileName)
        {
            case "MaisonThe":
                Debug.Log("Maison du Thé");
                //houseOfTea.GetComponent<HouseOfTea>().GainTokenAndQI(gameObject);
                break;
            case "HutteSorciere":
                Debug.Log("Hutte de la sorcière");
                //witchHut.GetComponent<HutOfWitch>().KillGhost();
                break;
            case "EchoppeHerboriste":
                Debug.Log("Echoppe de l'herboriste");
                //herbalistStall.GetComponent<StallOfHerbalist>().getToken();
                break;
            case "AutelTaoiste":
                Debug.Log("Autel Taoiste");
                //taoisteAutel.GetComponent<TaoisteAutel>().UnhauntTile();
                break;
            case "Cimetiere":
                Debug.Log("Le cimetière");
                //graveyard.GetComponent<Graveyard>().Resurrect();
                break;
            case "PavillonVentCeleste":
                Debug.Log("Le pavillon du vent celeste");
                //windCelestialFlag.GetComponent<WindCelestialFlag>().MovePlayerAndGhost();
                break;
            case "TourVeilleurNuit":
                Debug.Log("Tour du veilleur de nuit");
                //nightTower.GetComponent<NightTower>().RetreatGhost();
                break;
            case "CerclePierre":
                Debug.Log("Le cercle de prière");
                //priestCircle.GetComponent<PriestCircle>().reduceGhostLife();
                break;
            case "TempleBouddhiste":
                Debug.Log("Temple Bouddhiste");
                //bouddhisteTemple.GetComponent<BouddhisteTemple>().getBouddha();
                break;
            default:
                break;
        }
    }

    public void LaunchDice()
    {
        //A voir plus tard
    }
}
