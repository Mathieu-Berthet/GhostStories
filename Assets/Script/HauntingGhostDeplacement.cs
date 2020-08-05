using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntingGhostDeplacement : MonoBehaviour
{

    public bool hasHauntedTile;
    public float actualTime;

    public GameObject tileToCheck;
    public GameObject firstTileCheck;
    public GameObject secondTileCheck;

    public GameObject boardParent;
    public LayerMask layerTile;
    public GameManager gm;
    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }


    public void HauntedTile() //Okay 
    {
        hasHauntedTile = false;
        RaycastHit hitTiledirection;
        layerTile = LayerMask.GetMask("Tile");
        boardParent = gameObject.transform.parent.parent.parent.gameObject;
        for (int i = 0; i < 3; i++)
        {
            if (!hasHauntedTile)
            {
                if (boardParent.transform.eulerAngles.y == 0.0f)
                {
                    if (Physics.Raycast(transform.position, Vector3.back, out hitTiledirection, 100.0f, layerTile))
                    {
                        tileToCheck = hitTiledirection.collider.gameObject;
                    }
                }
                else if (boardParent.transform.eulerAngles.y == 180.0f)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hitTiledirection, 100.0f, layerTile))
                    {
                        tileToCheck = hitTiledirection.collider.gameObject;
                    }
                }
                else if (boardParent.transform.eulerAngles.y == 270.0f)
                {
                    if (Physics.Raycast(transform.position, Vector3.right, out hitTiledirection, 100.0f, layerTile))
                    {
                        tileToCheck = hitTiledirection.collider.gameObject;
                    }
                }
                else if (boardParent.transform.eulerAngles.y == 90.0f)
                {
                    if (Physics.Raycast(transform.position, Vector3.left, out hitTiledirection, 100.0f, layerTile))
                    {
                        tileToCheck = hitTiledirection.collider.gameObject;
                    }
                }
                Debug.Log(tileToCheck.name);
                switch (tileToCheck.name)
                {
                    case "MaisonThe":
                        if (!tileToCheck.GetComponent<HouseOfTea>().hauntedTile)
                        {
                            tileToCheck.GetComponent<HouseOfTea>().hauntedTile = true;
                            tileToCheck.GetComponent<HouseOfTea>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "HutteSorciere":
                        if (!tileToCheck.GetComponent<HutOfWitch>().hauntedTile)
                        {
                            tileToCheck.GetComponent<HutOfWitch>().hauntedTile = true;
                            tileToCheck.GetComponent<HutOfWitch>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "EchoppeHerboriste":
                        if (!tileToCheck.GetComponent<StallOfHerbalist>().hauntedTile)
                        {
                            tileToCheck.GetComponent<StallOfHerbalist>().hauntedTile = true;
                            tileToCheck.GetComponent<StallOfHerbalist>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "AutelTaoiste":
                        if (!tileToCheck.GetComponent<TaoisteAutel>().hauntedTile)
                        {
                            tileToCheck.GetComponent<TaoisteAutel>().hauntedTile = true;
                            tileToCheck.GetComponent<TaoisteAutel>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "Cimetiere":
                        if (!tileToCheck.GetComponent<Graveyard>().hauntedTile)
                        {
                            tileToCheck.GetComponent<Graveyard>().hauntedTile = true;
                            tileToCheck.GetComponent<Graveyard>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "PavillonVentCeleste":
                        if (!tileToCheck.GetComponent<WindCelestialFlag>().hauntedTile)
                        {
                            tileToCheck.GetComponent<WindCelestialFlag>().hauntedTile = true;
                            tileToCheck.GetComponent<WindCelestialFlag>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "TourVeilleurNuit":
                        if (!tileToCheck.GetComponent<NightTower>().hauntedTile)
                        {
                            tileToCheck.GetComponent<NightTower>().hauntedTile = true;
                            tileToCheck.GetComponent<NightTower>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "CerclePriere":
                        if (!tileToCheck.GetComponent<PriestCircle>().hauntedTile)
                        {
                            tileToCheck.GetComponent<PriestCircle>().hauntedTile = true;
                            tileToCheck.GetComponent<PriestCircle>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    case "TempleBouddhiste":
                        if (!tileToCheck.GetComponent<BouddhisteTemple>().hauntedTile)
                        {
                            tileToCheck.GetComponent<BouddhisteTemple>().hauntedTile = true;
                            tileToCheck.GetComponent<BouddhisteTemple>().haunted();
                            hasHauntedTile = true;
                        }
                        else
                        {
                            tileToCheck.layer = 0;
                        }
                        break;
                    default:
                        break;
                }
            }
            if (i == 0)
            {
                firstTileCheck = tileToCheck;
            }
            if (i == 1)
            {
                secondTileCheck = tileToCheck;
            }
            if (i == 2)
            {
                firstTileCheck.layer = 10;
                secondTileCheck.layer = 10;
            }
        }
    }

    public void GhostMove(GameObject ghost)
    {
        StartCoroutine(gm.audio.PlayHauntingAdvanceFX(gm.audio.GetComponent<AudioManager>().hauntingAdvanceFX));
        if (gameObject.transform.parent.name.Contains("Depart"))
        {
            //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
            gameObject.transform.parent = ghost.GetComponent<Ghost>().power.middlePosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (gameObject.transform.parent.name.Contains("Case"))
        {
            //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
            gameObject.transform.parent = ghost.GetComponent<Ghost>().power.endPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }


        if (gameObject.transform.parent.name.Contains("Arrive"))
        {
            //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
            HauntedTile();
            gameObject.transform.parent = ghost.GetComponent<Ghost>().power.startPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
