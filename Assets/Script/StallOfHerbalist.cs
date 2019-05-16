using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallOfHerbalist : MonoBehaviour
{

    public bool hauntedTile = false;

    [SerializeField]
    private GameObject dice;

    //TODO : Faire remplir ces variables
    public string resultDiceOne;
    public string resultDiceTwo;
    public string resultDiceThree;

    [SerializeField]
    private CubeScript cube;
    // Use this for initialization
    void Start ()
    {
        resultDiceOne = " ";
        resultDiceTwo = " ";
        resultDiceThree = " ";
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
        {
            getToken();
        }
	}

    public void getToken()
    {
        //Remplacer 3 ici par le nombre de dés. (Qui sera dans un autre script)
        for(int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(dice, new Vector3(i, 2, 0), Quaternion.identity);
            go.AddComponent<CubeScript>();
            cube = go.GetComponent<CubeScript>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                cube.rb.AddForce(hit.point * cube.force);
            }
            
            //To be continue
            if(resultDiceOne == " ")
            {
                resultDiceOne = cube.face;
            }
            /*if (resultDiceTwo == string.Empty)
            {
                resultDiceTwo = cube.face;
            }
            if (resultDiceThree == string.Empty)
            {
                resultDiceThree = cube.face;
            }*/
        }
    }
}
