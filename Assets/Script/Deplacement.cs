﻿using System.Collections;
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

    public Button houseOfTea;
    public Button hutOfWitch;
    public Button herbalistStall;

    public Button taoisteAutel;
    public Button graveyard;
    public Button windCelestialFlag;

    public Button priestCircle;
    public Button bouddhisteTemple;
    public Button nightTower;

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
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().CheckDistance();
        }
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
                Debug.Log("Couocu145");
                panelTileDeplacement.SetActive(false);
                chooseDepla = false;
            }
            Debug.Log(tileToMove);
            switch (tileToMove)
            {
                case "Maison du The":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosHouse;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Hutte de la Sorciere":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosHut;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Echoppe de L'herboriste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosStall;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Autel Taoiste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosAutel;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Cimetiere":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosGraveyard;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Pavillon du Vent Celeste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosPavillon;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Tour du Veilleur de Nuit":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosTower;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Cercle de priere":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosCircle;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Temple Bouddhiste":
                    player.transform.parent = player.GetComponent<BluePlayer>().bluePosTemple;
                    player.transform.localPosition = new Vector3(0, 8.25f, 0);
                    player.transform.parent = null;
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                case "Rester sur la tuile":
                    player.GetComponent<BluePlayer>().state = BluePlayer.STATE_GAME.STATE_PLAYER;
                    player.GetComponent<BluePlayer>().alreadyMove = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void getTileToDepla(Button buttonClick)
    {
        tileToMove = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        Debug.Log("HEY");
        chooseDepla = true;
    }
}