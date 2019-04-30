using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolChild : MonoBehaviour {

    public Pool pool;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReturnToPool()
    {
        gameObject.SetActive(false); //Solution temporaire, a modifier plus tard
        transform.SetParent(pool.PoolParent.transform); // A Remplir ^^
    }
}
