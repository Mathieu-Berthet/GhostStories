using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour {

    public GameObject panelRules;
    public GameObject panelTiles;
    public GameObject panelToken;
    public Button buttonNext;
    public Button buttonPrecedent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (panelTiles.activeSelf)
            {
                panelRules.SetActive(true);
                panelTiles.SetActive(false);
                buttonNext.gameObject.SetActive(true);
                buttonPrecedent.gameObject.SetActive(false);
            }
            else
            {
                panelRules.SetActive(!panelRules.activeSelf);
                buttonNext.gameObject.SetActive(!buttonNext.gameObject.activeSelf);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (panelRules.activeSelf)
            {
                panelTiles.SetActive(true);
                panelRules.SetActive(false);
                buttonNext.gameObject.SetActive(true);
                buttonPrecedent.gameObject.SetActive(true);
            }
            else
            {
                panelTiles.SetActive(!panelTiles.activeSelf);
                buttonNext.gameObject.SetActive(!buttonNext.gameObject.activeSelf);
                buttonPrecedent.gameObject.SetActive(!buttonPrecedent.gameObject.activeSelf);
            }
        }

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
}
