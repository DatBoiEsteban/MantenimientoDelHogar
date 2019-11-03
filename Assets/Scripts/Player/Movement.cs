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
        int taps = Taps();
        if (Input.GetMouseButton(0) || taps == 1)
        {
            doAction();
        } else if (Input.GetMouseButtonDown(1) || taps == 2)
        {
            pickup.doAction();
        }
    }

    void doAction()
    {
        agent.SetDestination(cam.PointerCamera.ViewportPointToRay(new Vector3(.5f, .5f)).direction + agent.transform.position);
    }

    public int Taps()
    {
        int result = 0;
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    Debug.Log("Double Tap");
                    result = 2;
                } else if (Input.GetTouch(i).tapCount == 1)
                {
                    Debug.Log("Single Tap");
                    result = 1;
                }
            }
        }
        return result;
    }
}
