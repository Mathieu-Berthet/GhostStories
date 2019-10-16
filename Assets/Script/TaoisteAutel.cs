using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaoisteAutel : MonoBehaviour {

    public bool hauntedTile = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnhauntTile(GameObject player)
    {
        if (player.name == "BluePlayer")
        {
            switch (player.GetComponent<BluePlayer>().tileName)
            {
                case "MaisonThe":
                    player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().Unhaunted();
                    break;
                case "HutteSorciere":
                    player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().Unhaunted();
                    break;
                case "EchoppeHerboriste":
                    player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().Unhaunted();
                    break;
                case "AutelTaoiste":
                    hauntedTile = false;
                    Debug.Log("Tuile déshantée");
                    Unhaunted();
                    break;
                case "Cimetiere":
                    
                    player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().Unhaunted();
                    break;
                case "PavillonVentCeleste":
                    player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().Unhaunted();
                    break;
                case "TourVeilleurNuit":
                    player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().Unhaunted();
                    break;
                case "CerclePierre":
                    player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().Unhaunted();
                    break;
                case "TempleBouddhiste":
                    player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().Unhaunted();
                    break;
                default:
                    break;
            }
            //player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
        }
    }

    public void haunted()
    {
        if (hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
    }

    public void Unhaunted()
    {
        if (!hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
    }
}
