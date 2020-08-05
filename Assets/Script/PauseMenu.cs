using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameManager gm;

    public RulesScript rules;

    public Button returnOnPause;

    public GameObject panelPause;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gm.cantPause)
        {
            gm.cantPlay = true;
            Pause();
        }
    }

    public void Pause()
    {
        rules.buttonEndTurn.gameObject.SetActive(false);
        panelPause.SetActive(true);
        rules.panelToken.SetActive(false);
        rules.infoPhase.gameObject.SetActive(false);
        rules.infoPlayerPower.gameObject.SetActive(false);
        rules.infoTuile.gameObject.SetActive(false);
        rules.infoDefausse.gameObject.SetActive(false);
        rules.infoTurnPlayer.gameObject.SetActive(false);
        rules.infoTurn.gameObject.SetActive(false);
        rules.infoDice.gameObject.SetActive(false);
    }

    public void Resume()
    {
        panelPause.SetActive(false);
        rules.buttonEndTurn.gameObject.SetActive(true);
        rules.panelToken.SetActive(true);
        rules.infoPhase.gameObject.SetActive(true);
        rules.infoPlayerPower.gameObject.SetActive(true);
        rules.infoTuile.gameObject.SetActive(true);
        rules.infoDefausse.gameObject.SetActive(true);
        rules.infoTurnPlayer.gameObject.SetActive(true);
        rules.infoTurn.gameObject.SetActive(true);
        rules.infoDice.gameObject.SetActive(true);
        gm.cantPlay = false;
    }

    public void DisplayHelp()
    {
        rules.panelRules.SetActive(true);
        rules.buttonNext.gameObject.SetActive(true);
        panelPause.SetActive(false);
        returnOnPause.gameObject.SetActive(true);
    }


    public void GoBackPause()
    {
        rules.panelRules.SetActive(false);
        rules.panelTiles.SetActive(false);
        rules.panelToken.SetActive(false);
        rules.panelAttack.SetActive(false);
        rules.panelGhostPower.SetActive(false);
        rules.panelTokenRules.SetActive(false);
        rules.panelHantise.SetActive(false);
        rules.buttonNext.gameObject.SetActive(false);
        rules.buttonPrecedent.gameObject.SetActive(false);
        returnOnPause.gameObject.SetActive(false);
        panelPause.SetActive(true);
    }
}
