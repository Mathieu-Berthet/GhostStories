using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntingGhostDeplacement : MonoBehaviour
{

    public bool hasHauntedTile;
    public float actualTime;
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void HauntedTile()
    {
        hasHauntedTile = false;
        RaycastHit hitTiledirection;
        GameObject tileToCheck;
        do
        {
            if (Physics.Raycast(transform.position, Vector3.back, out hitTiledirection, 6.5f) || Physics.Raycast(transform.position, Vector3.forward, out hitTiledirection, 6.5f) ||
               Physics.Raycast(transform.position, Vector3.right, out hitTiledirection, 6.5f) || Physics.Raycast(transform.position, Vector3.left, out hitTiledirection, 6.5f))
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
                        }
                        else
                        {
                            tileToCheck.GetComponent<BoxCollider>().enabled = false;
                        }
                        break;
                    case "CerclePierre":
                        if (!tileToCheck.GetComponent<PriestCircle>().hauntedTile)
                        {
                            tileToCheck.GetComponent<PriestCircle>().hauntedTile = true;
                            tileToCheck.GetComponent<PriestCircle>().haunted();
                            hasHauntedTile = true;
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
        while (!hasHauntedTile);
        //GhostMove(); // Pour replacer le fantome sur la case de départ
    }

    public void GhostMove()
    {
        if(gameObject.transform.parent.name.Contains("Depart"))
        {
            //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
            //gameObject.transform.parent = middlePosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (gameObject.transform.parent.name.Contains("Case"))
        {
            //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
            //gameObject.transform.parent = endPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (gameObject.transform.parent.name.Contains("Arrive"))
        {
            //gameObject.transform.position = Vector3.Lerp(startPosition.position, middlePosition.position, actualTime); // To see later
            HauntedTile();
            //gameObject.transform.parent = startPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);

        }
    }
}
