using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public GvrReticlePointer cam;
    public NavMeshAgent agent;
    private PickUp pickup;
    private void Start()
    {
        cam = GetComponentInChildren<GvrReticlePointer>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            agent.SetDestination(cam.CurrentRaycastResult.worldPosition);
        }
    }
}
