using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject BulletPrefab;

    public float bulletForse = 20f;
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }*/
    }

    public void Shoot()
    {
        GameObject bullet=Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb=bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up*bulletForse,ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
            Destroy(BulletPrefab);
        }
    }
}
