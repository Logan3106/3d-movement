using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float reach;
    [SerializeField] private GameObject itemHolder;
    [SerializeField] private GameObject itemHeld;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && itemHeld == null)
        {
            RaycastHit hit;

            Physics.Raycast(transform.position, transform.forward * reach, out hit);

            if(hit.collider != null)
            {
                if(hit.collider.tag == "Item")
                {
                    itemHeld = hit.collider.gameObject;
                    itemHeld.GetComponent<WeaponScript>().canShoot = true;
                    itemHeld.transform.SetParent(itemHolder.transform);
                    itemHeld.transform.GetComponent<Rigidbody>().isKinematic = true;
                    itemHeld.transform.GetComponent<BoxCollider>().isTrigger = true;
                    itemHeld.transform.position = itemHolder.transform.position;
                    itemHeld.transform.rotation = itemHolder.transform.rotation;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G) && itemHeld != null)
        {
            itemHeld.transform.parent = null;
            itemHeld.transform.GetComponent<Rigidbody>().isKinematic = false;
            itemHeld.transform.GetComponent<BoxCollider>().isTrigger = false;
            itemHeld.transform.position += new Vector3(0, 0, reach);
            itemHeld = null;
        }
    }
}
