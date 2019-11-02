using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float range;
    public bool hasObject;
    private GameObject prevParent;
    public GameObject pickable;
    private GameObject picked;
    public GameObject Objective;
    public GameObject Activable;
    private Vector3 prevSize;

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
                    Objective = other.gameObject;
                } else {
                    pickable = other.gameObject;
                }
                
            } else if (other.tag == "Activable")
            {
                Activable = other.gameObject;
            }
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        pickable = null;
        Objective = null;
        Activable = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Activable != null)
            {
                Activable.gameObject.GetComponent<Activable>().doAction(Activable.GetComponent<Collider>());
            }
            if (pickable != null || picked != null)
            {
                if (!hasObject && pickable.GetComponent<pickable>().canPickUp)
                {
                    hasObject = true;
                    prevParent = pickable.transform.parent.gameObject;
                    prevSize = pickable.transform.localScale;
                    pickable.transform.parent = transform;
                    pickable.GetComponent<Rigidbody>().useGravity = false;
                    pickable.gameObject.GetComponent<BoxCollider>().enabled = false;
                    picked = pickable;
                }
                else
                {
                    if (Objective == null) {
                        hasObject = false;
                        picked.GetComponent<BoxCollider>().enabled = true;
                        picked.GetComponent<Rigidbody>().useGravity = true;
                        picked.gameObject.transform.parent = prevParent.transform;
                        picked.transform.localScale = prevSize;
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