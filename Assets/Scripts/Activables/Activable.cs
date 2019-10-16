using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    public bool isDoor;
    public bool isSlidingDoor;

    public void doAction(Collider other)
    {
        if (isDoor == true)
        {
            
            other.gameObject.GetComponent<ActivableDoor>().activateDoor();
        }
        if (isSlidingDoor == true)
        {
            
            other.gameObject.GetComponent<SlidingDoor>().activateDoor();
        }
    }
}
