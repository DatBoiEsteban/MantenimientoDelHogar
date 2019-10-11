using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    public bool isDoor;

    public void doAction(Collider other)
    {
        if (isDoor)
        {
            other.gameObject.GetComponent<ActivableDoor>().activateDoor();
        }
    }
}
