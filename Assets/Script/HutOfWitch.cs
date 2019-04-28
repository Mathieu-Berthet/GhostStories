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
            player.GetComponent<BluePlayer>().qi -= 1;
        }
        else if (player.name == "GreenPlayer")
        {
            player.GetComponent<GreenPlayer>().qi -= 1;
        }
        else if (player.name == "YellowPlayer")
        {
            player.GetComponent<YellowPlayer>().qi -= 1;
        }
        else if (player.name == "RedPlayer")
        {
            player.GetComponent<RedPlayer>().qi -= 1;
        }

        //Kill a ghost
    }
}
