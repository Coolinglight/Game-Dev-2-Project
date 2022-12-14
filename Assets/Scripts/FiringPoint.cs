using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : Singleton<FiringPoint>
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000;
    public Transform firingPoint;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);
            Destroy(projectileInstance, 5);
        }
    }

}
