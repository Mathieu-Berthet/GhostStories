using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private GameObject[] playerToResurrect;

    [SerializeField]
    private GameObject dice;
    [SerializeField]
    private GameObject blackDice;

    [SerializeField]
    private CubeScript cube;
    public string resultFace;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Resurrect(GameObject player)
    {
        StartCoroutine(LaunchBlackDice(player));
    }

    public IEnumerator LaunchBlackDice(GameObject player)
    {
        GameObject go = Instantiate(dice, new Vector3(0, 2, 0), Quaternion.identity);
        go.AddComponent<CubeScript>();
        cube = go.GetComponent<CubeScript>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            cube.rb.AddForce(hit.point * cube.force);
        }

        blackDice = go;

        yield return new WaitForSeconds(2.0f);

        resultFace = blackDice.GetComponent<CubeScript>().face;

        switch(resultFace)
        {
            case "HauntedFace":
                if (player.name == "BluePlayer")
                {
                    switch(player.GetComponent<BluePlayer>().tileName)
                    {
                        case "MaisonThe":
                            player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().houseOfTea.GetComponent<HouseOfTea>().haunted();
                            break;
                        case "HutteSorciere":
                            player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().witchHut.GetComponent<HutOfWitch>().haunted();
                            break;
                        case "EchoppeHerboriste":
                            player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().herbalistStall.GetComponent<StallOfHerbalist>().haunted();
                            break;
                        case "AutelTaoiste":
                            player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().taoisteAutel.GetComponent<TaoisteAutel>().haunted();
                            break;
                        case "Cimetiere":
                            hauntedTile = true;
                            haunted();
                            break;
                        case "PavillonVentCeleste":
                            player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().windCelestialFlag.GetComponent<WindCelestialFlag>().haunted();
                            break;
                        case "TourVeilleurNuit":
                            player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().nightTower.GetComponent<NightTower>().haunted();
                            break;
                        case "CerclePierre":
                            player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().priestCircle.GetComponent<PriestCircle>().haunted();
                            break;
                        case "TempleBouddhiste":
                            player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().hauntedTile = true;
                            player.GetComponent<BluePlayer>().bouddhisteTemple.GetComponent<BouddhisteTemple>().haunted();
                            break;
                        default:
                            break;
                    }
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                break;
            case "DrawGhostFace":
                if (player.name == "BluePlayer")
                {
                    player.GetComponent<BluePlayer>().DrawAGhost();
                }
                else if (player.name == "RedPlayer")
                {
                    //player.GetComponent<RedPlayer>().DrawAGhost();
                }
                else if (player.name == "GreenPlayer")
                {
                    //player.GetComponent<GreenPlayer>().DrawAGhost();
                }
                else if (player.name == "YellowPlayer")
                {
                    //player.GetComponent<YellowPlayer>().DrawAGhost();
                }
                break;
            case "LoseJetonFace":
                if (player.name == "BluePlayer")
                {
                    player.GetComponent<BluePlayer>().NbBlackToken = 0;
                    player.GetComponent<BluePlayer>().NbRedToken = 0;
                    player.GetComponent<BluePlayer>().NbBlueToken = 0;
                    player.GetComponent<BluePlayer>().NbGreenToken = 0;
                    player.GetComponent<BluePlayer>().NbYellowToken = 0;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "RedPlayer")
                {
                    player.GetComponent<RedPlayer>().NbBlackToken = 0;
                    player.GetComponent<RedPlayer>().NbRedToken = 0;
                    player.GetComponent<RedPlayer>().NbBlueToken = 0;
                    player.GetComponent<RedPlayer>().NbGreenToken = 0;
                    player.GetComponent<RedPlayer>().NbYellowToken = 0;
                    //player.GetComponent<RedPlayer>().update = true;
                    //player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "GreenPlayer")
                {
                    player.GetComponent<GreenPlayer>().NbBlackToken = 0;
                    player.GetComponent<GreenPlayer>().NbRedToken = 0;
                    player.GetComponent<GreenPlayer>().NbBlueToken = 0;
                    player.GetComponent<GreenPlayer>().NbGreenToken = 0;
                    player.GetComponent<GreenPlayer>().NbYellowToken = 0;
                    //player.GetComponent<GreenPlayer>().update = true;
                    //player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "YellowPlayer")
                {
                    player.GetComponent<YellowPlayer>().NbBlackToken = 0;
                    player.GetComponent<YellowPlayer>().NbRedToken = 0;
                    player.GetComponent<YellowPlayer>().NbBlueToken = 0;
                    player.GetComponent<YellowPlayer>().NbGreenToken = 0;
                    player.GetComponent<YellowPlayer>().NbYellowToken = 0;
                    //player.GetComponent<YellowPlayer>().update = true;
                    //player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                }
                break;
            case "LoseQIFace":
                if (player.name == "BluePlayer")
                {
                    player.GetComponent<BluePlayer>().Qi -= 1;
                    player.GetComponent<BluePlayer>().update = true;
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "RedPlayer")
                {
                    player.GetComponent<RedPlayer>().Qi -= 1;
                    //player.GetComponent<RedPlayer>().update = true;
                    //player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "GreenPlayer")
                {
                    player.GetComponent<GreenPlayer>().Qi -= 1;
                    //player.GetComponent<GreenPlayer>().update = true;
                    //player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                }
                else if (player.name == "YellowPlayer")
                {
                    player.GetComponent<YellowPlayer>().Qi -= 1;
                    //player.GetComponent<YellowPlayer>().update = true;
                    //player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                }
                break;
            case "EmptyFace":
            case "EmptyFaceTwo":
                if (player.name == "BluePlayer")
                {
                    player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                }
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(0.5f);

        Destroy(blackDice);
    }

    public void haunted()
    {
        if (hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
    }
}
