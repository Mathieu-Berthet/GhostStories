using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour {

    public GameObject panelRules;
    public GameObject panelTiles;
    public GameObject panelToken;
    public Button buttonNext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Next()
    {
        if(panelRules.activeSelf)
        {
            panelRules.SetActive(false);
            panelTiles.SetActive(true);
        }
        else if(panelTiles.activeSelf)
        {
            panelTiles.SetActive(false);
            buttonNext.gameObject.SetActive(false);
            panelToken.SetActive(true);
        }
    }
}
