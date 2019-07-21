using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour {

    public bool hauntedTile = false;
    [SerializeField]
    private GameObject[] playerToResurrect;

    [SerializeField]
    private GameObject blackDice;

    [SerializeField]
    private CubeScript cube;
    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.B))
        {
            LaunchBlackDice();
        }
	}

    public void Resurrect()
    {

    }

    public void LaunchBlackDice()
    {
        blackDice = Instantiate(blackDice, new Vector3(0, 2, 0), Quaternion.identity);
        cube = blackDice.GetComponent<CubeScript>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            cube.rb.AddForce(hit.point * cube.force);
        }
    }
}
