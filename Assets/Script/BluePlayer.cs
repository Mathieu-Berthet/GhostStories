﻿using System.Collections;
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

    public bool choose;
    public string choosenToken = "";
    public GameObject panelButtonChoice;

    [SerializeField]
    private CubeScript cube;

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
    public string ghostName;
    public string ghostName2;

    public GameObject ghost;
    public GameObject ghost2;
    public bool canLaunchDice;

    [SerializeField]
    private PoolManagerDeck deck;
    [SerializeField]
    private GameObject card;
    public Image drawedCard;
    public BoardPosition board;
    public GameObject panel;

    [SerializeField]
    private GameObject defausse;

    //public BoxCollider boxCollider;

    [SerializeField]
    private bool hasDraw;

    [SerializeField]
    private boardColor blueBoard;
    [SerializeField]
    private boardColor redBoard;
    [SerializeField]
    private boardColor greenBoard;
    [SerializeField]
    private boardColor yellowBoard;

    public Text textInfo;
    public string colorPlayer = "blue";

    public GameManager gm;

    public Text textNbTokenBlue;
    public Text textNbTokenRed;
    public Text textNbTokenGreen;
    public Text textNbTokenYellow;
    public Text textNbTokenBlack;
    public bool update;

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
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Qi = 4; // Mode facile, seulement 3 pour les autres modes. Mais pour l'instant, test avec 4.
        NbBlueToken = 1;
        NbRedToken = 0;
        NbYellowToken = 0;
        NbGreenToken = 0;
        NbBlackToken = 1; //Mode facile, 0 pour les autres modes. Mais pour l'instant, test avec 1
        NbPowerToken = 1; //Si pas 4 joueur. 0 Sinon
        NbYinYangBlueToken = 1; //Max possible.

        hasDraw = false;

        deck = GameObject.Find("Deck").GetComponent<PoolManagerDeck>();
        board = GameObject.Find("Canvas").GetComponent<BoardPosition>();

        redBoard = GameObject.Find("PlateauJoueurRouge").GetComponent<boardColor>();
        blueBoard = GameObject.Find("PlateauJoueurBleu").GetComponent<boardColor>();
        greenBoard = GameObject.Find("PlateauJoueurVert").GetComponent<boardColor>();
        yellowBoard = GameObject.Find("PlateauJoueurJaune").GetComponent<boardColor>();
        canLaunchDice = true;
        updateUI();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire2") && !hasDraw)
        {
            hasDraw = true;
            DrawAGhost();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Sortie");
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            gm.nextTurn();
        }

        if (Input.GetKeyDown(KeyCode.D) && canLaunchDice)
        {
            //StartCoroutine(herbalistStall.GetComponent<StallOfHerbalist>().getToken(gameObject));
            StartCoroutine(LaunchDice());
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(witchHut.GetComponent<HutOfWitch>().KillGhost(gameObject));
        }
        if (update)
        {
            updateUI();
        }
        checkGhost();
    }

    void FixedUpdate()
    {

    }

    public void DrawAGhost()
    {
        gameObject.GetComponent<Deplacement>().enabled = false;
        panel.SetActive(true);
        textInfo.gameObject.SetActive(true);
        drawedCard.gameObject.SetActive(true);
        card = deck.GetPoolByName(PoolNameDeck.ghost).GetItem(transform, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, true, false, 0);
        card.transform.parent = null;
        card.SetActive(false);
        drawedCard.sprite = card.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    public void SelectGhostPosition(GameObject position)
    {
        if (card.GetComponent<Ghost>().couleur == "black" && position.transform.parent.GetComponent<boardColor>().color != colorPlayer && blueBoard.nbCardOnBoard < 3)
        {
            textInfo.text = "Black ghost must be played on your board";
            return;
        }
        else if (card.GetComponent<Ghost>().couleur != "black" && card.GetComponent<Ghost>().couleur != position.transform.parent.GetComponent<boardColor>().color)
        {
            if ((card.GetComponent<Ghost>().couleur == "red" && redBoard.nbCardOnBoard < 3) ||
                (card.GetComponent<Ghost>().couleur == "blue" && blueBoard.nbCardOnBoard < 3) ||
                (card.GetComponent<Ghost>().couleur == "yellow" && yellowBoard.nbCardOnBoard < 3) ||
                (card.GetComponent<Ghost>().couleur == "green" && greenBoard.nbCardOnBoard < 3))
            {
                textInfo.text = "You can't choose this place. It is not the same color as the card";
                return;
            }
        }
        card.transform.SetParent(position.transform);
        card.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        card.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 180.0f);
        card.transform.localScale = new Vector3(15.0f, 10.0f, 1);
        card.SetActive(true);
        card.transform.parent.GetComponent<BoxCollider>().enabled = true;
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
        panel.SetActive(false);
        textInfo.gameObject.SetActive(false);
        drawedCard.gameObject.SetActive(false);
        gameObject.GetComponent<Deplacement>().enabled = true;
        hasDraw = false;
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

    public IEnumerator LaunchDice()
    {
        canLaunchDice = false;
        nbRedFace = 0;
        nbBlueFace = 0;
        nbBlackFace = 0;
        nbWhiteFace = 0;
        nbGreenFace = 0;
        nbYellowFace = 0;

        for (int i = 0; i < 3; i++)
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
        resultDiceThree = diceThree.GetComponent<CubeScript>().face;
        switch (resultDiceThree)
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


        yield return new WaitForSeconds(2.0f);
        while (nbWhiteFace > 0)
        {
            panelButtonChoice.SetActive(true);
            gameObject.GetComponent<Deplacement>().enabled = false;
            while (!choose)
            {
                yield return new WaitForSeconds(2.0f);
            }
            if (choose)
            {
                switch (choosenToken)
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
                choose = false;
                panelButtonChoice.SetActive(false);
            }
            nbWhiteFace--;
        }

        yield return new WaitForSeconds(2.0f);
        panelButtonChoice.SetActive(false);

        //Partie combat
        if((ghost.GetComponent<Ghost>().couleur == "red" && nbRedFace >= ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "blue" && nbBlueFace >= ghost.GetComponent<Ghost>().life) 
            || (ghost.GetComponent<Ghost>().couleur == "green" && nbGreenFace >= ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "yellow" && nbYellowFace >= ghost.GetComponent<Ghost>().life)
            || (ghost.GetComponent<Ghost>().couleur == "black" && nbBlackFace >= ghost.GetComponent<Ghost>().life))
        {
            //On ajouteras des particules à la mort du fantome (style explosion)
            ghost.transform.parent = defausse.transform;
            ghost.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }

        else if((ghost.GetComponent<Ghost>().couleur == "red" && nbRedFace < ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "blue" && nbBlueFace < ghost.GetComponent<Ghost>().life)
            || (ghost.GetComponent<Ghost>().couleur == "green" && nbGreenFace < ghost.GetComponent<Ghost>().life) || (ghost.GetComponent<Ghost>().couleur == "yellow" && nbYellowFace < ghost.GetComponent<Ghost>().life)
            || (ghost.GetComponent<Ghost>().couleur == "black" && nbBlackFace < ghost.GetComponent<Ghost>().life))
        {
            //D'abord, check si on a un autre joueur (ou plusieurs) sur la meme case que nous.
            // Check résultat Dés + jetons pour tuer le fantome
        }
        else
        {
            //On a pas assez pour le tuer, alors il ne se passe rien
        }
        canLaunchDice = true;
        gameObject.GetComponent<Deplacement>().enabled = true;
    }

    public void checkGhost()
    {
        RaycastHit hitXdirection;
        RaycastHit hitZdirection;
        if(Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 0 && hitZdirection.collider.transform.childCount > 0)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;
                ghost = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 0 && hitZdirection.collider.transform.childCount > 0)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;
                ghost = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 0 && hitZdirection.collider.transform.childCount > 0)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;
                ghost = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f) && Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 0 && hitZdirection.collider.transform.childCount > 0)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghostName2 = hitZdirection.collider.transform.GetChild(0).name;
                ghost = hitXdirection.collider.transform.GetChild(0).gameObject;
                ghost2 = hitZdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 0)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghost = hitXdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if(Physics.Raycast(transform.position, Vector3.back, out hitZdirection, 1.5f))
        {
            if (hitZdirection.collider.transform.childCount > 0)
            {
                //tileName = hitt.transform.gameObject.name;
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitZdirection.collider.transform.GetChild(0).name;
                ghost = hitZdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hitXdirection, 1.5f))
        {
            if (hitXdirection.collider.transform.childCount > 0)
            {
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitXdirection.collider.transform.GetChild(0).name;
                ghost = hitXdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.forward, out hitZdirection, 1.5f))
        {
            if (hitZdirection.collider.transform.childCount > 0)
            {
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
                Debug.DrawRay(transform.position, Vector3.back, Color.red);
                ghostName = hitZdirection.collider.transform.GetChild(0).name;
                ghost = hitZdirection.collider.transform.GetChild(0).gameObject;
            }
        }
        else
        {
            ghostName = "";
            ghostName2 = "";
            ghost = null;
            ghost2 = null;
        }
    }

    private void updateUI()
    {
        textNbTokenBlue.text = "x " + NbBlueToken;
        textNbTokenRed.text = "x " + NbRedToken;
        textNbTokenGreen.text = "x " + NbGreenToken;
        textNbTokenYellow.text = "x " + NbYellowToken;
        textNbTokenBlack.text = "x " + NbBlackToken;
        update = false;
    }

    public void MustChooseToken(Button buttonClick)
    {
        choosenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
    }
}
