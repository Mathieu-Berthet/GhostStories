using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject menuStart;
    public GameObject menuOptions;
    public GameObject menuDidacticiel;
    public GameObject didacticielRule;
    public GameObject didacticielTilesEffects;
    public GameObject didacticielToken;
    public GameObject didacticielAttack;
    public GameObject didacticielGhostEffects;
    public GameObject didacticielHantise;


    public Button nextButton;
    public Button previousButton;
    public Button returnToStart;
    public Button returnToDidacticiel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log("Debut du jeu");
        SceneManager.LoadScene("GhostStorieGame");
    }

    public void Options()
    {
        Debug.Log("Ouvre le panel option");
        menuStart.SetActive(false);
        menuOptions.SetActive(true);
    }

    public void Didacticiel()
    {
        menuStart.SetActive(false);
        menuDidacticiel.SetActive(true);
    }

    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Fin de l'appli");
            Application.Quit();
        }
    }


    public void returnToStartMenu()
    {
        menuStart.SetActive(true);
        menuOptions.SetActive(false);
        menuDidacticiel.SetActive(false);
    }


    public void returnToDidacticielMenu()
    {
        menuDidacticiel.SetActive(true);
        didacticielRule.SetActive(false);
        didacticielAttack.SetActive(false);
        didacticielGhostEffects.SetActive(false);
        didacticielHantise.SetActive(false);
        didacticielToken.SetActive(false);
        didacticielTilesEffects.SetActive(false);
    }

    public void RuleGlobal()
    {
        menuDidacticiel.SetActive(false);
        didacticielRule.SetActive(true);
        didacticielAttack.SetActive(false);
        didacticielGhostEffects.SetActive(false);
        didacticielHantise.SetActive(false);
        didacticielToken.SetActive(false);
        didacticielTilesEffects.SetActive(false);
    }

    public void RuleAttack()
    {
        menuDidacticiel.SetActive(false);
        didacticielRule.SetActive(false);
        didacticielAttack.SetActive(true);
        didacticielGhostEffects.SetActive(false);
        didacticielHantise.SetActive(false);
        didacticielToken.SetActive(false);
        didacticielTilesEffects.SetActive(false);
    }



    public void RuleGhostEffects()
    {
        menuDidacticiel.SetActive(false);
        didacticielRule.SetActive(false);
        didacticielAttack.SetActive(false);
        didacticielGhostEffects.SetActive(true);
        didacticielHantise.SetActive(false);
        didacticielToken.SetActive(false);
        didacticielTilesEffects.SetActive(false);
    }


    public void RuleHantise()
    {
        menuDidacticiel.SetActive(false);
        didacticielRule.SetActive(false);
        didacticielAttack.SetActive(false);
        didacticielGhostEffects.SetActive(false);
        didacticielHantise.SetActive(true);
        didacticielToken.SetActive(false);
        didacticielTilesEffects.SetActive(false);
    }


    public void RuleToken()
    {
        menuDidacticiel.SetActive(false);
        didacticielRule.SetActive(false);
        didacticielAttack.SetActive(false);
        didacticielGhostEffects.SetActive(false);
        didacticielHantise.SetActive(false);
        didacticielToken.SetActive(true);
        didacticielTilesEffects.SetActive(false);
    }


    public void RuleTilesEffects()
    {
        menuDidacticiel.SetActive(false);
        didacticielRule.SetActive(false);
        didacticielAttack.SetActive(false);
        didacticielGhostEffects.SetActive(false);
        didacticielHantise.SetActive(false);
        didacticielToken.SetActive(false);
        didacticielTilesEffects.SetActive(true);
    }

}
