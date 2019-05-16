using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutOfWitch : MonoBehaviour {

    public bool hauntedTile = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillGhost(GameObject player)
    {
        if (player.name == "BluePlayer")
        {
            player.GetComponent<BluePlayer>().Qi -= 1;
        }
        else if (player.name == "GreenPlayer")
        {
            player.GetComponent<GreenPlayer>().Qi -= 1;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().Qi -= 1;
        }
        else if (player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().Qi -= 1;
        }

        //Kill a ghost
    }
}
