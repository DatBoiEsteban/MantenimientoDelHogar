using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableDoor : MonoBehaviour
{
    public int rotationDegrees;
    private bool rotate;
    private int rotateTo;

    public GameObject leftDoor;
    public GameObject RightDoor;

    public void activateDoor()
    {
        StopAllCoroutines();
        rotate = true;
        rotateTo = rotationDegrees;
        StartCoroutine("OpenDoors");
    }

    IEnumerator OpenDoors()
    {
        if (GetComponentInParent<DoorManager>().isOpen)
        {
            Debug.Log("El que lo lea");
            Debug.Log(rotateTo);
            for (int i = rotateTo; i > 0; i--)
            {
                Debug.Log(i);
                leftDoor.transform.Rotate(new Vector3(0, 1, 0));
                RightDoor.transform.Rotate(new Vector3(0, -1, 0));
                yield return new WaitForSeconds(.001f);
            }
            rotate = false;
            GetComponentInParent<DoorManager>().isOpen = false;
        }
        else if (!GetComponentInParent<DoorManager>().isOpen)
        {
            Debug.Log("puto");
            for (int i = 0; i < rotateTo; i++)
            {
                Debug.Log(i);
                leftDoor.transform.Rotate(new Vector3(0, -1, 0));
                RightDoor.transform.Rotate(new Vector3(0, 1, 0));
                yield return new WaitForSeconds(.001f);
            }
            rotate = false;
            GetComponentInParent<DoorManager>().isOpen = true;
        }
        
    }
}
