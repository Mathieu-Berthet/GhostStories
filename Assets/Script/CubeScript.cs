using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public string face;
    public int force = 275;
    public Rigidbody rb;

	// Use this for initialization
	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        /*if(Input.GetKeyDown(KeyCode.D) && rb.velocity.magnitude == 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                rb.AddForce(hit.point * force);
            }
        }*/
    }
}
