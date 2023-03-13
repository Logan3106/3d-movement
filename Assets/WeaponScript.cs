using JetBrains.Annotations;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    Inventory inventory;
    public bool canShoot;

    public Camera fpsCam;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        {
            Debug.Log(hit.transform);

            Healthenemy healthenemy = hit.transform.GetComponent<Healthenemy>();
            if (healthenemy != null)
            {
                healthenemy.TakeDamage(damage);
            }

        }
    }
}
