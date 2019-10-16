using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public int movementAmount;
    public float moveAmount = 0.001f;
    public Vector3 moveDirection;
    public bool isOpen;

    public void activateDoor()
    {
        StopAllCoroutines();
        StartCoroutine("OpenDoors");
    }

    IEnumerator OpenDoors()
    {
        if (moveAmount > 0)
        {
            if (isOpen)
            {
                for (int i = 0; i <= movementAmount; i++)
                {
                    this.transform.position += new Vector3(moveDirection.x * moveAmount, moveDirection.y * moveAmount, moveDirection.z * moveAmount);
                    yield return new WaitForSeconds(1f);
                }
                isOpen = false;
            } else
            {
                for (int i = movementAmount; i >= 0; i--)
                {
                    this.transform.position -= new Vector3(moveDirection.x * moveAmount, moveDirection.y * moveAmount, moveDirection.z * moveAmount);
                    yield return new WaitForSeconds(1f);
                }
                isOpen = true;
            }
            
        } else
        {
            if (isOpen)
            {
                for (int i = movementAmount; i >= 0; i--)//int i = movementAmount; i >= 0; i--
                {
                    this.transform.position += new Vector3(moveDirection.x * moveAmount, moveDirection.y * moveAmount, moveDirection.z * moveAmount);
                    yield return new WaitForSeconds(1f);
                }
                isOpen = false;
            }
            else
            {
                for (int i = 0; i <= movementAmount; i++)
                {
                    this.transform.position -= new Vector3(moveDirection.x * moveAmount, moveDirection.y * moveAmount, moveDirection.z * moveAmount);
                    yield return new WaitForSeconds(1f);
                }
                isOpen = true;
            }
        }
    }
}
