using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HutOfWitch : MonoBehaviour
{
    public GameManager gm;

    public GameObject ghostToKill;
    public GameObject defausse;

    public GameObject panelBluePlace;
    public GameObject panelRedPlace;
    public GameObject panelGreenPlace;
    public GameObject panelYellowPlace;
    public GameObject fogHaunted;

    public BoardPosition board;
    public Text infos;

    public string chooseenGhost;

    public bool hauntedTile = false;
    public bool choose;
    // Use this for initialization
    void Start ()
    {
        choose = false;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public IEnumerator KillGhost(GameObject player)
    {
        if (!hauntedTile)
        {
            choose = false;
            board.mustChooseGhost = true;
            yield return new WaitForSeconds(0.5f);

            panelBluePlace.SetActive(true);
            panelRedPlace.SetActive(true);
            panelGreenPlace.SetActive(true);
            panelYellowPlace.SetActive(true);
            while (!choose)
            {
                yield return new WaitForSeconds(1.0f);
            }
            if (choose)
            {
                panelBluePlace.SetActive(false);
                panelRedPlace.SetActive(false);
                panelGreenPlace.SetActive(false);
                panelYellowPlace.SetActive(false);
                choose = false;
            }

            if (ghostToKill.transform.parent.parent.GetComponent<boardColor>().color == "blue")
            {
                gm.blueBoard.nbCardOnBoard--;
            }
            else if (ghostToKill.transform.parent.parent.GetComponent<boardColor>().color == "red")
            {
                gm.redBoard.nbCardOnBoard--;
            }
            else if (ghostToKill.transform.parent.parent.GetComponent<boardColor>().color == "green")
            {
                gm.greenBoard.nbCardOnBoard--;
            }
            else if (ghostToKill.transform.parent.parent.GetComponent<boardColor>().color == "yellow")
            {
                gm.yellowBoard.nbCardOnBoard--;
            }

            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().Qi -= 1;
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                player.GetComponent<BluePlayer>().textInfoPhase.gameObject.SetActive(true);
            }
            else if (player.name == "GreenPlayer")
            {
                player.GetComponent<GreenPlayer>().Qi -= 1;
                player.GetComponent<GreenPlayer>().canLaunchDice = true;
                player.GetComponent<GreenPlayer>().canLaunchBlackDice = true;
                player.GetComponent<GreenPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<GreenPlayer>().update = true;
                player.GetComponent<GreenPlayer>().panelJeton.SetActive(true);
                player.GetComponent<GreenPlayer>().textInfoPhase.gameObject.SetActive(true);

            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().Qi -= 1;
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                player.GetComponent<YellowPlayer>().textInfoPhase.gameObject.SetActive(true);

            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().Qi -= 1;
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
                player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                player.GetComponent<RedPlayer>().textInfoPhase.gameObject.SetActive(true);

            }
            ghostToKill.transform.parent.GetChild(0).GetChild(2).GetComponent<ParticleSystem>().Play();
            if (ghostToKill.transform.parent.GetChild(1).childCount >= 1)
            {
                Destroy(ghostToKill.transform.parent.GetChild(1).GetChild(0).gameObject);
            }
            if (ghostToKill.transform.parent.GetChild(2).childCount >= 1)
            {
                Destroy(ghostToKill.transform.parent.GetChild(2).GetChild(0).gameObject);
            }
            ghostToKill.transform.parent = defausse.transform;
            ghostToKill.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            ghostToKill.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
            ghostToKill = null;
            board.mustChooseGhost = false;
        }
        else
        {
            infos.text = "Cette tuile est hantée. Vous ne pouvez pas activer son pouvoir";
            infos.gameObject.SetActive(true);
            if (player.name == "BluePlayer")
            {
                player.GetComponent<BluePlayer>().canLaunchDice = true;
                player.GetComponent<BluePlayer>().canLaunchBlackDice = true;
                player.GetComponent<BluePlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<BluePlayer>().update = true;
                player.GetComponent<BluePlayer>().panelJeton.SetActive(true);
                player.GetComponent<BluePlayer>().textInfoPhase.gameObject.SetActive(true);
            }
            else if (player.name == "YellowPlayer")
            {
                player.GetComponent<YellowPlayer>().canLaunchDice = true;
                player.GetComponent<YellowPlayer>().canLaunchBlackDice = true;
                player.GetComponent<YellowPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<YellowPlayer>().update = true;
                player.GetComponent<YellowPlayer>().panelJeton.SetActive(true);
                player.GetComponent<YellowPlayer>().textInfoPhase.gameObject.SetActive(true);
            }
            else if (player.name == "RedPlayer")
            {
                player.GetComponent<RedPlayer>().canLaunchDice = true;
                player.GetComponent<RedPlayer>().canLaunchBlackDice = true;
                player.GetComponent<RedPlayer>().useTilePower = false;
                player.GetComponent<Deplacement>().enabled = true;
                player.GetComponent<RedPlayer>().update = true;
                player.GetComponent<RedPlayer>().panelJeton.SetActive(true);
                player.GetComponent<RedPlayer>().textInfoPhase.gameObject.SetActive(true);
            }
        }
    }

    public void MustChooseGhost(Button buttonClick)
    {
        chooseenGhost = buttonClick.name;
        switch(chooseenGhost)
        {
            case "BlueOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "BlueThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().bluePositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "RedOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "RedTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "RedThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().redPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "GreenThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().greenPositionThree.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowOne":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionOne.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowTwo":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionTwo.transform.GetChild(4).gameObject;
                }
                break;
            case "YellowThree":
                if (buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.childCount > 4)
                {
                    ghostToKill = buttonClick.transform.parent.parent.GetComponent<BoardPosition>().yellowPositionThree.transform.GetChild(4).gameObject;
                }
                break;
        }
        choose = true;
    }

    public void haunted()
    {
        if (hauntedTile)
        {
            fogHaunted.transform.GetChild(6).GetComponent<ParticleSystem>().Play();
            StartCoroutine(gm.audio.PlayHauntingFX(gm.audio.GetComponent<AudioManager>().hauntingFX, gm.audio.GetComponent<AudioManager>().horrorScreamFX, 3.0f));
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0.25f, 0.25f, 1);
            
        }
    }

    public void Unhaunted()
    {
        if (!hauntedTile)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1);
        }
    }
}
