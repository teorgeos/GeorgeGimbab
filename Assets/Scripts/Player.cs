using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform ShootTransform;

    [SerializeField]
    private float shootInterval = 0.1f;

    private float lastShootTime = 0f;
   
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float VerticalInput = Input.GetAxisRaw("Vertical");

        //Vector3 moveTo = new Vector3(horizontalInput, VerticalInput, 0f);
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            Instantiate(weapon, ShootTransform.position, Quaternion.identity);
            lastShootTime = Time.time;
        }
        

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Heart")
        {
            Destroy(other.gameObject);
        }
    }
}
