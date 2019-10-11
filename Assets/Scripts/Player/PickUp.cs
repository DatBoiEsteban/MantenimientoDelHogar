using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float range;
    public bool hasObject;
    private Transform prevParent;
    private Collider pickable;
    private Collider picked;
    private Collider Objective;
    private Collider Activable;

    private void Start()
    {
        Transform picker = GetComponentInChildren<CapsuleCollider>().transform;
        picker.localScale = new Vector3(picker.localScale.x, range, picker.localScale.z);
        picker.localPosition = new Vector3(picker.localPosition.x, picker.localPosition.y, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.tag == "Pickable")
            {
                if (other.gameObject.layer == 10){
                    Objective = other;
                } else {
                    pickable = other;
                }
                
            } else if (other.tag == "Activable")
            {
                Activable = other;
            }
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        pickable = null;
        Objective = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Activable != null)
            {
                Activable.gameObject.GetComponent<Activable>().doAction(Activable);
            }
            if (pickable != null || picked != null)
            {
                if (!hasObject && pickable.GetComponent<pickable>().canPickUp)
                {
                    hasObject = true;
                    prevParent = pickable.transform.parent;
                    pickable.transform.SetParent(transform);
                    picked = pickable;
                    pickable.attachedRigidbody.useGravity = false;
                    pickable.gameObject.GetComponent<BoxCollider>().enabled = false;
                
                }
                else
                {
                    if (Objective == null) {
                        hasObject = false;
                        picked.gameObject.GetComponent<BoxCollider>().enabled = true;
                        picked.attachedRigidbody.useGravity = true;
                        picked.transform.SetParent(prevParent);
                        picked = null;
                    } else if (Objective.GetComponent<placeable>().canPlace) {
                        Objective.gameObject.layer = 0;
                        Destroy(picked.gameObject);
                        hasObject = false;
                        picked = null;
                    }
                }
            }

        }
        
    }
}
