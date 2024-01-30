using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController1 : MonoBehaviour
{
    public float interactionDistance;
    public GameObject intText;
    public string doorOpenAnimName, doorCloseAnimName;

    private void Update()
    {
        Ray ray = new Ray (transform .position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, interactionDistance)) 
        {
           if (hit.collider.gameObject.tag == "Door")
            {
                GameObject DoorParent = hit.collider.transform.root.gameObject;
                Animator doorAnim= DoorParent.GetComponent<Animator>();
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        doorAnim.ResetTrigger("Open");
                        doorAnim.SetTrigger("Close");
                    }
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        doorAnim.ResetTrigger("Close");
                        doorAnim.SetTrigger("Open");
                    }

                }
            }
            else
            {
                intText.SetActive(false);
            }

        }
    }
}
