using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallOfHerbalist : MonoBehaviour
{

    public bool hauntedTile = false;

    public GameObject dice;
    public string resultDiceOne;
    public string resultDiceTwo;
    public string resultDiceThree;

    public CubeScript cube;
    // Use this for initialization
    void Start ()
    {
        //cube = GameObject.Find("Dice(Clone)").GetComponent<CubeScript>();
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
        }

        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            cube.rb.AddForce(hit.point * cube.force);
        }*/
    }
}
