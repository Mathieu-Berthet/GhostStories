using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour {

    public GameObject panelRules;
    public GameObject panelTiles;
    public GameObject panelToken;
    public GameObject panelTokenRules;
    public GameObject panelAttack;
    public GameObject panelGhostPower;
    public GameObject panelHantise;
    public Text infoTurnPlayer;
    public Text infoTurn;
    public Text infoDice;
    public Text infoPhase;
    public Text infoPlayerPower;
    public Text infoMort;
    public Text infoTuile;
    public Text infoDefausse;
    public Button buttonNext;
    public Button buttonPrecedent;
    public Button buttonEndTurn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Next();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Precedent();
        }
    }

    public void Next()
    {
        if(panelRules.activeSelf)
        {
            panelRules.SetActive(false);
            panelTiles.SetActive(true);
            buttonPrecedent.gameObject.SetActive(true);
        }
        else if (panelTiles.activeSelf)
        {
            panelTiles.SetActive(false);
            panelTokenRules.SetActive(true);
            buttonPrecedent.gameObject.SetActive(true);
        }
        else if (panelTokenRules.activeSelf)
        {
            panelTokenRules.SetActive(false);
            panelAttack.SetActive(true);
            buttonPrecedent.gameObject.SetActive(true);
        }
        else if (panelAttack.activeSelf)
        {
            panelAttack.SetActive(false);
            panelGhostPower.SetActive(true);
            buttonPrecedent.gameObject.SetActive(true);
        }
        else if (panelGhostPower.activeSelf)
        {
            panelGhostPower.SetActive(false);
            panelHantise.SetActive(true);
            buttonPrecedent.gameObject.SetActive(true);
        }
        else if(panelHantise.activeSelf)
        {
            panelHantise.SetActive(false);
            buttonNext.gameObject.SetActive(false);
            buttonPrecedent.gameObject.SetActive(false);
            panelToken.SetActive(true);
            //infoMort.gameObject.SetActive(true);
            infoPhase.gameObject.SetActive(true);
            infoPlayerPower.gameObject.SetActive(true);
            infoTuile.gameObject.SetActive(true);
            infoDefausse.gameObject.SetActive(true);
            infoTurnPlayer.gameObject.SetActive(true);
            infoTurn.gameObject.SetActive(true);
            infoDice.gameObject.SetActive(true);
            buttonEndTurn.gameObject.SetActive(true);
        }
    }

    public void Precedent()
    {
        if (panelHantise.activeSelf)
        {
            panelGhostPower.SetActive(true);
            panelHantise.SetActive(false);
        }
        else if(panelGhostPower.activeSelf)
        {
            panelAttack.SetActive(true);
            panelGhostPower.SetActive(false);
        }
        else if (panelAttack.activeSelf)
        {
            panelAttack.SetActive(false);
            panelTokenRules.SetActive(true);
        }
        else if (panelTokenRules.activeSelf)
        {
            panelTokenRules.SetActive(false);
            panelTiles.SetActive(true);
        }
        else if (panelTiles.activeSelf)
        {
            panelTiles.SetActive(false);
            panelRules.SetActive(true);
            buttonPrecedent.gameObject.SetActive(false);
        }
    }
}
