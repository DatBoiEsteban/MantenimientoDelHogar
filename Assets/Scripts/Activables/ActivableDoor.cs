using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableDoor : MonoBehaviour
{
    public int rotationDegrees;
    private int currentRotation;

    public GameObject leftDoor;
    public GameObject RightDoor;

    public void activateDoor()
    {
        StopAllCoroutines();
        StartCoroutine("OpenDoors");
        currentRotation = GetComponentInParent<DoorManager>().currentRotation;
    }

    IEnumerator OpenDoors()
    {
        if (GetComponentInParent<DoorManager>().isOpen)
        {
            GetComponentInParent<DoorManager>().isOpen = false;
            for (int i = currentRotation; i >= 0; i--)
            {
                leftDoor.transform.Rotate(new Vector3(0, 1, 0));
                RightDoor.transform.Rotate(new Vector3(0, -1, 0));
                currentRotation -= 1;
                yield return new WaitForSeconds(.001f);
            }
            GetComponentInParent<DoorManager>().currentRotation = currentRotation;
        }
        else if (!GetComponentInParent<DoorManager>().isOpen)
        {
            GetComponentInParent<DoorManager>().isOpen = true;
            for (int i = currentRotation; i <= rotationDegrees; i++)
            {
                leftDoor.transform.Rotate(new Vector3(0, -1, 0));
                RightDoor.transform.Rotate(new Vector3(0, 1, 0));
                currentRotation += 1;
                yield return new WaitForSeconds(.001f);
            }
            GetComponentInParent<DoorManager>().currentRotation = currentRotation;
        }
        
    }
}
