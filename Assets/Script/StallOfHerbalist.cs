using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallOfHerbalist : MonoBehaviour
{

    public bool hauntedTile = false;

    [SerializeField]
    private GameObject dice;

    private GameObject diceOne;
    private GameObject diceTwo;
    private GameObject diceThree;

    //TODO : Faire remplir ces variables
    public string resultDiceOne;
    public string resultDiceTwo;
    public string resultDiceThree;

    [SerializeField]
    private CubeScript cube;
    // Use this for initialization
    void Start ()
    {
        //resultDiceOne = " ";
        /*resultDiceTwo = " ";
        resultDiceThree = " ";*/
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.D))
        {
            getToken();
        }
        /*if (diceOne != null && diceOne.GetComponent<CubeScript>().rb.velocity.magnitude == 0)
        {
            resultDiceOne = diceOne.GetComponent<CubeScript>().face;
        }
        if (diceTwo != null && diceTwo.GetComponent<CubeScript>().rb.velocity.magnitude == 0)
        {
            resultDiceTwo = diceTwo.GetComponent<CubeScript>().face;
        }
        if (diceThree != null && diceThree.GetComponent<CubeScript>().rb.velocity.magnitude == 0)
        {
            resultDiceThree = diceThree.GetComponent<CubeScript>().face;
        }*/
    }

    public void getToken()
    {
        //Remplacer 3 ici par le nombre de dés. (Qui sera dans un autre script)
        for(int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(dice, new Vector3(i, 2, 0), Quaternion.identity);
            go.AddComponent<CubeScript>();
            cube = go.GetComponent<CubeScript>();
            if(i == 0)
            {
                diceOne = go;
            }
            else if(i == 1)
            {
                diceTwo = go;
            }
            else if(i == 2)
            {
                diceThree = go;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                cube.rb.AddForce(hit.point * cube.force);
            }
            
            //To be continue
            /*if(resultDiceOne == string.Empty)
            {
                resultDiceOne = cube.face;
                //Debug.Log(resultDiceOne);
            }*/
        }
    }
}
