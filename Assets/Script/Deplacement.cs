using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deplacement : MonoBehaviour {

    public Rigidbody rb;
    public NavMeshAgent navMeshPlayer;
    public RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMeshPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                    navMeshPlayer.destination = hit.point;
            }
        }
    }
}