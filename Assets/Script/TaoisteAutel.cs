using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaoisteAutel : MonoBehaviour
{
    public GameObject panelTile;

    public Text infos;
    public Text infoTaoiste;

    public string tileToUnhaunted;

    public bool hauntedTile = false;
    public bool choose;
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
        if (!hauntedTile)
        {
            if (player.name == "BluePlayer")
            {
                choose = false;

                yield return new WaitForSeconds(0.5f);
                infoTaoiste.text = "Veuillez choisir la tuile à déshanter : ";
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
                        player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().Unhaunted();
                        break;
                    case "Hutte de la Sorciere":
                        player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().Unhaunted();
                        break;
                    case "Echoppe de L'herboriste":
                        player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().Unhaunted();
                        break;
                    case "Autel Taoiste":
                        hauntedTile = false;
                        Debug.Log("Tuile déshantée");
                        Unhaunted();
                        break;
                    case "Cimetiere":
                        player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().Unhaunted();
                        break;
                    case "Pavillon du Vent Celeste":
                        player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().Unhaunted();
                        break;
                    case "Tour du Veilleur de Nuit":
                        player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().Unhaunted();
                        break;
                    case "Cercle de priere":
                        player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().Unhaunted();
                        break;
                    case "Temple Bouddhiste":
                        player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = false;
                        player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().Unhaunted();
                        break;
                    default:
                        break;
                }
                player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_DRAW; //PEUT ETRE
                player.GetComponent<BluePlayer>().DrawAGhost();
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "YellowPlayer")
            {
                choose = false;

                yield return new WaitForSeconds(0.5f);
                infoTaoiste.text = "Veuillez choisir la tuile à déshanter : ";
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
                        player.GetComponent<YellowPlayer>().houseOfTea.GetComponent<HouseOfTea>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().houseOfTea.GetComponent<HouseOfTea>().Unhaunted();
                        break;
                    case "Hutte de la Sorciere":
                        player.GetComponent<YellowPlayer>().witchHut.GetComponent<HutOfWitch>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().witchHut.GetComponent<HutOfWitch>().Unhaunted();
                        break;
                    case "Echoppe de L'herboriste":
                        player.GetComponent<YellowPlayer>().herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().herbalistStall.GetComponent<StallOfHerbalist>().Unhaunted();
                        break;
                    case "Autel Taoiste":
                        hauntedTile = false;
                        Debug.Log("Tuile déshantée");
                        Unhaunted();
                        break;
                    case "Cimetiere":
                        player.GetComponent<YellowPlayer>().taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().taoisteAutel.GetComponent<TaoisteAutel>().Unhaunted();
                        break;
                    case "Pavillon du Vent Celeste":
                        player.GetComponent<YellowPlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().Unhaunted();
                        break;
                    case "Tour du Veilleur de Nuit":
                        player.GetComponent<YellowPlayer>().nightTower.GetComponent<NightTower>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().nightTower.GetComponent<NightTower>().Unhaunted();
                        break;
                    case "Cercle de priere":
                        player.GetComponent<YellowPlayer>().priestCircle.GetComponent<PriestCircle>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().priestCircle.GetComponent<PriestCircle>().Unhaunted();
                        break;
                    case "Temple Bouddhiste":
                        player.GetComponent<YellowPlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = false;
                        player.GetComponent<YellowPlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().Unhaunted();
                        break;
                    default:
                        break;
                }
                player.GetComponent<YellowPlayer>().state = YellowPlayer.STATE_GAME.STATE_DRAW; //PEUT ETRE
                player.GetComponent<YellowPlayer>().DrawAGhost();
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activez son pouvoir";
            infos.gameObject.SetActive(true);
            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
            }
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
