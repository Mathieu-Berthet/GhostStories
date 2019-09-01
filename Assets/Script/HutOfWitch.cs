using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HutOfWitch : MonoBehaviour {

    public bool hauntedTile = false;

    public GameObject ghostToKill;
    public GameObject defausse;
    public string chooseenGhost;
    public bool choose;
    public GameObject panelGhost;
    // Use this for initialization
    void Start ()
    {
        choose = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.K))
        {
            //StartCoroutine(KillGhost())
        }
	}

    public IEnumerator KillGhost(GameObject player)
    {
        choose = false;
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().Qi -= 1;
            player.GetComponent<BluePlayer>().board.usingTile = true;
        }
        else if (player.name == "GreenPlayer")
        {
            player.GetComponent<GreenPlayer>().Qi -= 1;
            //player.GetComponent<GreenPlayer>().board.usingTile = true;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().Qi -= 1;
            //player.GetComponent<YellowPlayer>().board.usingTile = true;
        }
        else if (player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().Qi -= 1;
            //player.GetComponent<RedPlayer>().board.usingTile = true;
        }

        panelGhost.SetActive(true);
        while (!choose)
        {
            yield return new WaitForSeconds(1.0f);
        }
        if (choose)
        {
            Debug.Log("Couocu");
            panelGhost.SetActive(false);
            choose = false;
        }

        ghostToKill.transform.parent = defausse.transform;
        ghostToKill.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        ghostToKill = null;
    }

    public void MustChooseGhost(Button buttonClick)
    {
        Debug.Log("coucou");
        chooseenGhost = buttonClick.name;
        switch(chooseenGhost)
        {
            case "BlueOne":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(0).gameObject;
                break;
            case "BlueTwo":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(0).gameObject;
                break;
            case "BlueThree":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(0).gameObject;
                break;
            case "RedOne":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(0).gameObject;
                break;
            case "RedTwo":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(0).gameObject;
                break;
            case "RedThree":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(0).gameObject;
                break;
            case "GreenOne":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(0).gameObject;
                break;
            case "GreenTwo":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(0).gameObject;
                break;
            case "GreenThree":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(0).gameObject;
                break;
            case "YellowOne":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(0).gameObject;
                break;
            case "YellowTwo":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(0).gameObject;
                break;
            case "YellowThree":
                ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.GetChild(0).gameObject;
                break;
        }
        choose = true;
    }
}
