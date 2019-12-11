using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardPosition : MonoBehaviour {

    //All buttons
    public Button redFirstPlace;
    public Button redSecondPlace;
    public Button redThirdPlace;

    public Button blueFirstPlace;
    public Button blueSecondPlace;
    public Button blueThirdPlace;

    public Button greenFirstPlace;
    public Button greenSecondPlace;
    public Button greenThirdPlace;

    public Button yellowFirstPlace;
    public Button yellowSecondPlace;
    public Button yellowThirdPlace;

    //All position
    public GameObject redPositionOne;
    public GameObject redPositionTwo;
    public GameObject redPositionThree;

    public GameObject bluePositionOne;
    public GameObject bluePositionTwo;
    public GameObject bluePositionThree;

    public GameObject greenPositionOne;
    public GameObject greenPositionTwo;
    public GameObject greenPositionThree;

    public GameObject yellowPositionOne;
    public GameObject yellowPositionTwo;
    public GameObject yellowPositionThree;

    public bool usingTile;
	// Use this for initialization
	void Start ()
    {
        usingTile = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Gestion de la possibilité de cliquer ou non sur les boutons.
        checkPosition(redPositionOne, redFirstPlace);
        checkPosition(redPositionTwo, redSecondPlace);
        checkPosition(redPositionThree, redThirdPlace);

        checkPosition(bluePositionOne, blueFirstPlace);
        checkPosition(bluePositionTwo, blueSecondPlace);
        checkPosition(bluePositionThree, blueThirdPlace);

        checkPosition(greenPositionOne, greenFirstPlace);
        checkPosition(greenPositionTwo, greenSecondPlace);
        checkPosition(greenPositionThree, greenThirdPlace);

        checkPosition(yellowPositionOne, yellowFirstPlace);
        checkPosition(yellowPositionTwo, yellowSecondPlace);
        checkPosition(yellowPositionThree, yellowThirdPlace);
	}

    public void checkPosition(GameObject pos, Button button)
    {
        if(pos.transform.childCount <= 4 || usingTile)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
