using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Deplacement : MonoBehaviour {

    public Rigidbody rb;
    public NavMeshAgent navMeshPlayer;
    public RaycastHit hit;
    public GameObject panelTileDeplacement;

    public GameObject player;

    public string tileToMove;
    public bool chooseDepla;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMeshPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                navMeshPlayer.destination = hit.point;
                Debug.Log(hit.transform.name);
            }
        }*/
        /*if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().CheckDistance();
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().CheckDistance();
        }*/
    }

    public IEnumerator PlayerDeplacement()
    {
        if (player.name == "BluePlayer")
        {
            chooseDepla = false;

            yield return new WaitForSeconds(0.5f);

            panelTileDeplacement.SetActive(true);
            while (!chooseDepla)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseDepla)
            {
                panelTileDeplacement.SetActive(false);
                chooseDepla = false;
            }
            switch (tileToMove)
            {
                case "Maison du The":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosHouse;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Hutte de la Sorciere":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosHut;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Echoppe de L'herboriste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosStall;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Autel Taoiste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosAutel;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Cimetiere":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosGraveyard;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Pavillon du Vent Celeste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosPavillon;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Tour du Veilleur de Nuit":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosTower;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Cercle de priere":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosCircle;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Temple Bouddhiste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosTemple;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                case "Rester sur la tuile":
                    player.GetComponent<BluePlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else if (player.name == "YellowPlayer")
        {
            chooseDepla = false;

            yield return new WaitForSeconds(0.5f);

            panelTileDeplacement.SetActive(true);
            while (!chooseDepla)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseDepla)
            {
                panelTileDeplacement.SetActive(false);
                chooseDepla = false;
            }
            switch (tileToMove)
            {
                case "Maison du The":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosHouse;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Hutte de la Sorciere":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosHut;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Echoppe de L'herboriste":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosStall;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Autel Taoiste":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosAutel;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Cimetiere":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosGraveyard;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Pavillon du Vent Celeste":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosPavillon;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Tour du Veilleur de Nuit":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosTower;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Cercle de priere":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosCircle;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Temple Bouddhiste":
                    player.transform.parent = player.GetComponent<YellowPlayer>().yellowPosTemple;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                case "Rester sur la tuile":
                    player.GetComponent<YellowPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<YellowPlayer>().alreadyMove = true;
                    player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else if(player.name == "RedPlayer")
        {
            chooseDepla = false;

            yield return new WaitForSeconds(0.5f);

            panelTileDeplacement.SetActive(true);
            while (!chooseDepla)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseDepla)
            {
                panelTileDeplacement.SetActive(false);
                chooseDepla = false;
            }
            switch (tileToMove)
            {
                case "Maison du The":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosHouse;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Hutte de la Sorciere":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosHut;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Echoppe de L'herboriste":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosStall;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Autel Taoiste":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosAutel;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Cimetiere":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosGraveyard;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Pavillon du Vent Celeste":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosPavillon;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Tour du Veilleur de Nuit":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosTower;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Cercle de priere":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosCircle;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Temple Bouddhiste":
                    player.transform.parent = player.GetComponent<RedPlayer>().redPosTemple;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                case "Rester sur la tuile":
                    player.GetComponent<RedPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<RedPlayer>().alreadyMove = true;
                    player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else if (player.name == "GreenPlayer")
        {
            chooseDepla = false;

            yield return new WaitForSeconds(0.5f);

            panelTileDeplacement.SetActive(true);
            while (!chooseDepla)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (chooseDepla)
            {
                panelTileDeplacement.SetActive(false);
                chooseDepla = false;
            }
            switch (tileToMove)
            {
                case "Maison du The":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosHouse;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Hutte de la Sorciere":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosHut;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Echoppe de L'herboriste":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosStall;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Autel Taoiste":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosAutel;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Cimetiere":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosGraveyard;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Pavillon du Vent Celeste":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosPavillon;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Tour du Veilleur de Nuit":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosTower;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Cercle de priere":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosCircle;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Temple Bouddhiste":
                    player.transform.parent = player.GetComponent<GreenPlayer>().greenPosTemple;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                case "Rester sur la tuile":
                    player.GetComponent<GreenPlayer>().gm.state = GameManager.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<GreenPlayer>().alreadyMove = true;
                    player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void getTileToDepla(Button buttonClick)
    {
        tileToMove = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        chooseDepla = true;
        Debug.Log(tileToMove);
    }
}