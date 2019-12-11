using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntingGhostDeplacement : MonoBehaviour {

    public Transform startPosition;
    public Transform middlePosition;
    public Transform endPosition;

	// Use this for initialization
	void Start ()
    {
        startPosition = transform.parent.parent.GetChild(1);
        middlePosition = transform.parent.parent.GetChild(2);
        endPosition = transform.parent.parent.GetChild(3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
