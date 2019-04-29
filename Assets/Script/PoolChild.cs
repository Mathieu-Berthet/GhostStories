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
        transform.SetParent(pool.PoolParent); // A Remplir ^^
    }
}
