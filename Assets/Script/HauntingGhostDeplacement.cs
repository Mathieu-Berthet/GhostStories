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

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {

    }


    public void HauntedTile() //Okay 
    {
        hasHauntedTile = false;
        RaycastHit hitTiledirection;
        //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = false;
        transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = false;
        transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = false;
        transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = false;
        for (int i = 0; i < 3; i++)
        {
            if (!hasHauntedTile)
            {
                if (Physics.Raycast(gameObject.transform.position, Vector3.back, out hitTiledirection, 100.0f) || Physics.Raycast(gameObject.transform.position, Vector3.forward, out hitTiledirection, 100.0f) ||
                   Physics.Raycast(gameObject.transform.position, Vector3.right, out hitTiledirection, 100.0f) || Physics.Raycast(gameObject.transform.position, Vector3.left, out hitTiledirection, 100.0f))
                {
                    tileToCheck = hitTiledirection.collider.gameObject;
                    switch (tileToCheck.name)
                    {
                        case "MaisonThe":
                            if (!tileToCheck.GetComponent<HouseOfTea>().hauntedTile)
                            {
                                tileToCheck.GetComponent<HouseOfTea>().hauntedTile = true;
                                tileToCheck.GetComponent<HouseOfTea>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "HutteSorciere":
                            if (!tileToCheck.GetComponent<HutOfWitch>().hauntedTile)
                            {
                                tileToCheck.GetComponent<HutOfWitch>().hauntedTile = true;
                                tileToCheck.GetComponent<HutOfWitch>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "EchoppeHerboriste":
                            if (!tileToCheck.GetComponent<StallOfHerbalist>().hauntedTile)
                            {
                                tileToCheck.GetComponent<StallOfHerbalist>().hauntedTile = true;
                                tileToCheck.GetComponent<StallOfHerbalist>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "AutelTaoiste":
                            if (!tileToCheck.GetComponent<TaoisteAutel>().hauntedTile)
                            {
                                tileToCheck.GetComponent<TaoisteAutel>().hauntedTile = true;
                                tileToCheck.GetComponent<TaoisteAutel>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "Cimetiere":
                            if (!tileToCheck.GetComponent<Graveyard>().hauntedTile)
                            {
                                tileToCheck.GetComponent<Graveyard>().hauntedTile = true;
                                tileToCheck.GetComponent<Graveyard>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "PavillonVentCeleste":
                            if (!tileToCheck.GetComponent<WindCelestialFlag>().hauntedTile)
                            {
                                tileToCheck.GetComponent<WindCelestialFlag>().hauntedTile = true;
                                tileToCheck.GetComponent<WindCelestialFlag>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "TourVeilleurNuit":
                            if (!tileToCheck.GetComponent<NightTower>().hauntedTile)
                            {
                                tileToCheck.GetComponent<NightTower>().hauntedTile = true;
                                tileToCheck.GetComponent<NightTower>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "CerclePriere":
                            if (!tileToCheck.GetComponent<PriestCircle>().hauntedTile)
                            {
                                tileToCheck.GetComponent<PriestCircle>().hauntedTile = true;
                                tileToCheck.GetComponent<PriestCircle>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        case "TempleBouddhiste":
                            if (!tileToCheck.GetComponent<BouddhisteTemple>().hauntedTile)
                            {
                                tileToCheck.GetComponent<BouddhisteTemple>().hauntedTile = true;
                                tileToCheck.GetComponent<BouddhisteTemple>().haunted();
                                hasHauntedTile = true;
                                //gameObject.transform.parent.GetComponent<BoxCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(1).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(2).GetComponent<CapsuleCollider>().enabled = true;
                                gameObject.transform.parent.parent.GetChild(3).GetComponent<CapsuleCollider>().enabled = true;
                            }
                            else
                            {
                                tileToCheck.GetComponent<BoxCollider>().enabled = false;
                            }
                            break;
                        default:
                            break;
                    }
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
                firstTileCheck.GetComponent<BoxCollider>().enabled = true;
                secondTileCheck.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    public void GhostMove(GameObject ghost)
    {
        if(gameObject.transform.parent.name.Contains("Depart"))
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
