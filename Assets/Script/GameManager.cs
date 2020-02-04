using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public StockOfToken tokenStock;

    public Vector3 positionPlateau1;
    public Vector3 rotationPlateau1;

    public Vector3 positionPlateau2;
    public Vector3 rotationPlateau2;

    public Vector3 positionPlateau3;
    public Vector3 rotationPlateau3;

    public Vector3 positionPlateau4;
    public Vector3 rotationPlateau4;

    public Vector3 scalePlateau;


    public GameObject test;
    public GameObject test2;
    public GameObject test3;
    public GameObject test4;

    public Vector3 positionCamera1;
    public Vector3 positionCamera2;
    public Vector3 positionCamera3;
    public Vector3 positionCamera4;

    public Vector3 rotationCamera1;
    public Vector3 rotationCamera2;
    public Vector3 rotationCamera3;
    public Vector3 rotationCamera4;

    public Camera mainCamera;
    public bool canLerp;

    public float speed = 1.5f;
    public float startTime;
    public float actualTime;
    public int turn;
    public bool nextPlayer;

    public boardColor blueBoard;
    public boardColor redBoard;
    public boardColor greenBoard;
    public boardColor yellowBoard;

    public int nbDice;
    public bool canUseTaoToken;
    public bool cantTransformWhiteFace;

    public GameObject panelButtonChoice;
    public GameObject panelAwardChoice;

    public string choseenToken;
    public bool choose;

    public string choseenAward;
    public bool chooseAward;
    // Use this for initialization
    void Start ()
    {
        //startTime = Time.time;
        canUseTaoToken = true;
        nbDice = 3;
        turn = 1;
        nextPlayer = false;
        canLerp = false;
        scalePlateau = new Vector3(3.0f, 0.03f, 2.0f);

        positionPlateau1 = new Vector3(4.0f, 0.0f, 1.5f);
        rotationPlateau1 = new Vector3(0.0f, 90.0f, 0.0f);

        positionPlateau2 = new Vector3(1.5f, 0.0f, -1.0f);
        rotationPlateau2 = new Vector3(0.0f, 180.0f, 0.0f);

        positionPlateau3 = new Vector3(-1.0f, 0.0f, 1.5f);
        rotationPlateau3 = new Vector3(0.0f, -90.0f, 0.0f);

        positionPlateau4 = new Vector3(1.5f, 0.0f, 4.0f);
        rotationPlateau4 = new Vector3(0.0f, 0.0f, 0.0f);

        positionCamera1 = new Vector3(1.5f, 3.65f, -2.4f);
        rotationCamera1 = new Vector3(55.0f, 0.0f, 0.0f);

        positionCamera2 = new Vector3(-2.4f, 3.65f, 1.5f);
        rotationCamera2 = new Vector3(55.0f, 90.0f, 0.0f);

        positionCamera3 = new Vector3(1.5f, 3.65f, 5.4f);
        rotationCamera3 = new Vector3(55.0f, 180.0f, 0.0f);

        positionCamera4 = new Vector3(5.4f, 3.65f, 1.5f);
        rotationCamera4 = new Vector3(55.0f, 270.0f, 0.0f);

        redBoard = GameObject.Find("PlateauJoueurRouge").GetComponent<boardColor>();
        blueBoard = GameObject.Find("PlateauJoueurBleu").GetComponent<boardColor>();
        greenBoard = GameObject.Find("PlateauJoueurVert").GetComponent<boardColor>();
        yellowBoard = GameObject.Find("PlateauJoueurJaune").GetComponent<boardColor>();
        tokenStock = GameObject.Find("TokenStock").GetComponent<StockOfToken>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject go = Instantiate(test);
            go.transform.eulerAngles = rotationPlateau1;
            go.transform.position = positionPlateau1;
            go.transform.localScale = scalePlateau;

            GameObject go2 = Instantiate(test2);
            go2.transform.eulerAngles = rotationPlateau2;
            go2.transform.position = positionPlateau2;
            go2.transform.localScale = scalePlateau;

            GameObject go3 = Instantiate(test3);
            go3.transform.eulerAngles = rotationPlateau3;
            go3.transform.position = positionPlateau3;
            go3.transform.localScale = scalePlateau;

            GameObject go4 = Instantiate(test4);
            go4.transform.eulerAngles = rotationPlateau4;
            go4.transform.position = positionPlateau4;
            go4.transform.localScale = scalePlateau;
        }

        if (turn == 1 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera4, positionCamera1, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera4, rotationCamera1, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera1;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }

        if (turn == 2 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera1, positionCamera2, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera1, rotationCamera2, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera2;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }

        if (turn == 3 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera2, positionCamera3, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera2, rotationCamera3, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera2;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }

        if (turn == 4 && canLerp)
        {
            actualTime += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(positionCamera3, positionCamera4, actualTime);
            //mainCamera.transform.position = positionCamera2;
            mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera3, rotationCamera4, actualTime);
            //mainCamera.transform.eulerAngles = rotationCamera2;

            if (actualTime > 1.1f)
            {
                canLerp = false;
                actualTime = 0.0f;
            }
        }
    }

    public void nextTurn()
    {
        nextPlayer = true;
        canLerp = true;
        if(nextPlayer)
        {
            turn++;
            if(turn > 4)
            {
                turn = 1;
            }

            /*if(turn == 1)
            {
                //mainCamera.transform.position = Vector3.Lerp(positionCamera1, positionCamera2, newTime);
                mainCamera.transform.position = positionCamera1;
                mainCamera.transform.eulerAngles = rotationCamera1;
            }

            if (turn == 2)
            {
                //mainCamera.transform.position = Vector3.Slerp(positionCamera1, positionCamera2, 1.0f);
                mainCamera.transform.position = positionCamera2;
                //mainCamera.transform.eulerAngles = Vector3.Lerp(rotationCamera1, rotationCamera2, 0.5f);
                mainCamera.transform.eulerAngles = rotationCamera2;
            }

            if (turn == 3)
            {
                mainCamera.transform.position = positionCamera3;
                mainCamera.transform.eulerAngles = rotationCamera3;
            }

            if (turn == 4)
            {
                mainCamera.transform.position = positionCamera4;
                mainCamera.transform.eulerAngles = rotationCamera4;
            }*/
        }
        nextPlayer = false;
    }


    public void MustChooseToken(Button buttonClick)
    {
        choseenToken = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        choose = true;
    }

    public void MustChooseAward(Button buttonClick)
    {
        choseenAward = buttonClick.transform.GetChild(0).GetComponent<Text>().text;
        chooseAward = true;
    }


}
