using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaoisteAutel : MonoBehaviour {

    public bool hauntedTile = false;
    public string tileToUnhaunted;
    public bool choose;
    public GameObject panelTile;
    // Use this for initialization
    void Start ()
    {
        tileToUnhaunted = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator UnhauntTile(GameObject player)
    {
        if (player.name == "BluePlayer")
        {
            choose = false;

            yield return new WaitForSeconds(0.5f);

            panelTile.SetActive(true);
            while (!choose)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (choose)
            {
                Debug.Log("Couocu145");
                panelTile.SetActive(false);
                choose = false;
            }
            Debug.Log(tileToUnhaunted);
            //player.GetComponent<BluePlayer>().tileName = tileToUnhaunted;
            switch (tileToUnhaunted)
            {
                case "Maison du The":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().Unhaunted();
                    break;
                case "Hutte de la Sorciere":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().Unhaunted();
                    break;
                case "Echoppe de L'herboriste":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().Unhaunted();
                    break;
                case "Autel Taoiste":
                    hauntedTile = false;
                    Debug.Log("Tuile déshantée");
                    Unhaunted();
                    break;
                case "Cimetiere":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().Unhaunted();
                    break;
                case "Pavillon du Vent Celeste":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().Unhaunted();
                    break;
                case "Tour du Veilleur de Nuit":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().Unhaunted();
                    break;
                case "Cercle de priere":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().Unhaunted();
                    break;
                case "Temple Bouddhiste":
                    Debug.Log("TESTTE");
                    player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = false;
                    player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().Unhaunted();
                    break;
                default:
                    break;
            }
            player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_DRAW;
            player.GetComponent<BluePlayer>().DrawAGhost();
            player.GetComponent<BluePlayer>().canLaunchDice = true;
            player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
            player.GetComponent<BluePlayer>().useTilePower = false;
            player.GetComponent<Deplacement>().enabled = true;
            player.GetComponent<BluePlayer>().gm.turn++;
            player.GetComponent<BluePlayer>().update = true;
        }
    }

    public void getTileName(Button buttonClick)
    {
        tileToUnhaunted = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
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
