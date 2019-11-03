using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public GvrReticlePointer cam;
    public NavMeshAgent agent;
    private PickUp pickup;

    private void Start()
    {
        cam = GetComponentInChildren<GvrReticlePointer>();
        agent = GetComponent<NavMeshAgent>();
        pickup = GetComponentInChildren<PickUp>();
    }

    private void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    Debug.Log("Double tap..");
                    pickup.doAction();
                }
                if (Input.GetTouch(i).tapCount == 1)
                {
                    Debug.Log("Single tap..");
                    doAction();
                }
            }
        }
    }

    void doAction()
    {
        agent.SetDestination(cam.PointerCamera.ViewportPointToRay(new Vector3(.5f, .5f)).direction + agent.transform.position);
    }

}
