using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : MonoBehaviour
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
    private int nbYinYangGreenToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur
    [SerializeField]
    private int nbBouddha; // Pour les bouddha du temple bouddhiste
    #endregion


    public bool powerForceDeLaMontagne;
    public bool powerFavoriDesDieux;


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
    
    public int NbYinYangGreenToken
    {
        get
        {
            return nbYinYangGreenToken;
        }

        set
        {
            nbYinYangGreenToken = value;
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
        NbBlueToken = 0;
        NbRedToken = 0;
        NbYellowToken = 0;
        NbGreenToken = 1;
        NbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        NbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        NbYinYangGreenToken = 1; //Max possible.
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void UsePowerTile()
    {
        RaycastHit hitt;
        if (Physics.Raycast(transform.position, Vector3.down, out hitt, 1.0f))
        {
            tileName = hitt.transform.gameObject.name;
        }

        switch (tileName)
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
        if(powerFavoriDesDieux)
        {
            //Relancer les dés 1 fois
        }
        else if(powerForceDeLaMontagne)
        {
            //Lancer avec 1 dé supplémentaire et pas de dés noir
        }
    }
}
