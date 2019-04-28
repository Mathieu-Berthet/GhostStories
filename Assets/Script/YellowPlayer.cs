using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlayer : MonoBehaviour
{

    public int qi = 0; // PV du joueur

    public int nbBlueToken;
    public int nbRedToken;
    public int nbGreenToken;
    public int nbYellowToken;
    public int nbBlackToken;

    public int nbPowerToken; // Pour une partie ou il n'y a pas 4 joueur

    public int nbYinYangYellowToken; // Jeton yin yang. Max possible 1, et uniquement de sa couleur

    public int nbBouddha; // Pour les bouddha du temple bouddhiste


    public bool powerPocheSansFond;
    public bool powerMantraAffaiblissement;

    public int nbMantraToken;

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

    // Use this for initialization
    void Start ()
    {
        qi = 4; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        nbBlueToken = 0;
        nbRedToken = 0;
        nbYellowToken = 1;
        nbGreenToken = 0;
        nbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        nbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        nbYinYangYellowToken = 1; //Max possible.

        if(powerMantraAffaiblissement)
        {
            nbMantraToken = 1;
        }
        else
        {
            nbMantraToken = 0;
        }
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


    public void PocheSansFond()
    {

    }

    public void MantraAffaiblissement()
    {
        //Recupérer le fantôme ciblé // Seulement si le joueur a encore son jeton mantra // Doit le jouer AVANT le combat
        nbMantraToken -= 1;
        //Si fantome mort
        nbMantraToken += 1;
    }

    public void LaunchDice()
    {

    }
}
