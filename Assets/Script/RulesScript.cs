using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour {

    public GameObject panelRules;
    public GameObject panelTiles;
    public GameObject panelToken;
    public Text infoTurnPlayer;
    public Text infoTurn;
    public Text infoDice;
    public Text infoPhase;
    public Text infoMort;
    public Text infoTuile;
    public Text infoDefausse;
    public Text infoDebug;
    public Button buttonNext;
    public Button buttonPrecedent;
    public Button buttonTile;
    public Button buttonRules;
    public Button buttonFermer;
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
        else if(panelTiles.activeSelf)
        {
            panelTiles.SetActive(false);
            buttonNext.gameObject.SetActive(false);
            buttonPrecedent.gameObject.SetActive(false);
            panelToken.SetActive(true);
            //infoMort.gameObject.SetActive(true);
            infoPhase.gameObject.SetActive(true);
            infoTuile.gameObject.SetActive(true);
            infoDefausse.gameObject.SetActive(true);
            infoTurnPlayer.gameObject.SetActive(true);
            infoTurn.gameObject.SetActive(true);
            infoDice.gameObject.SetActive(true);
            //infoDebug.gameObject.SetActive(true);
            buttonRules.gameObject.SetActive(true);
            buttonTile.gameObject.SetActive(true);
            buttonFermer.gameObject.SetActive(false);
            buttonEndTurn.gameObject.SetActive(true);
        }
    }

    public void Precedent()
    {
        if (panelTiles.activeSelf)
        {
            panelRules.SetActive(true);
            panelTiles.SetActive(false);
            buttonPrecedent.gameObject.SetActive(false);
        }
    }


    public void TileEffect()
    {
        buttonTile.gameObject.SetActive(false);
        buttonRules.gameObject.SetActive(false);
        buttonFermer.gameObject.SetActive(true);
        buttonEndTurn.gameObject.SetActive(false);
        panelTiles.SetActive(true);
        buttonPrecedent.gameObject.SetActive(true);
        buttonNext.gameObject.SetActive(true);
        panelToken.SetActive(false);
        //infoMort.gameObject.SetActive(false);
        infoPhase.gameObject.SetActive(false);
        infoTuile.gameObject.SetActive(false);
        infoDefausse.gameObject.SetActive(false);
        infoTurnPlayer.gameObject.SetActive(false);
        infoTurn.gameObject.SetActive(false);
        infoDice.gameObject.SetActive(false);
        //infoDebug.gameObject.SetActive(false);
    }

    public void Rules()
    {
        buttonTile.gameObject.SetActive(false);
        buttonRules.gameObject.SetActive(false);
        buttonFermer.gameObject.SetActive(true);
        buttonEndTurn.gameObject.SetActive(false);
        panelRules.SetActive(true);
        buttonPrecedent.gameObject.SetActive(false);
        buttonNext.gameObject.SetActive(true);
        panelToken.SetActive(false);
        //infoMort.gameObject.SetActive(false);
        infoPhase.gameObject.SetActive(false);
        infoTuile.gameObject.SetActive(false);
        infoDefausse.gameObject.SetActive(false);
        infoTurnPlayer.gameObject.SetActive(false);
        infoTurn.gameObject.SetActive(false);
        infoDice.gameObject.SetActive(false);
        //infoDebug.gameObject.SetActive(false);
    }

    public void Fermer()
    {
        panelTiles.SetActive(false);
        panelRules.SetActive(false);
        buttonPrecedent.gameObject.SetActive(false);
        buttonNext.gameObject.SetActive(false);
        buttonTile.gameObject.SetActive(true);
        buttonRules.gameObject.SetActive(true);
        buttonFermer.gameObject.SetActive(false);
        buttonEndTurn.gameObject.SetActive(true);
        panelToken.SetActive(true);
        //infoMort.gameObject.SetActive(true);
        infoPhase.gameObject.SetActive(true);
        infoTuile.gameObject.SetActive(true);
        infoDefausse.gameObject.SetActive(true);
        infoTurnPlayer.gameObject.SetActive(true);
        infoTurn.gameObject.SetActive(true);
        infoDice.gameObject.SetActive(true);
        //infoDebug.gameObject.SetActive(true);
    }
}
