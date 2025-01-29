using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject heart;

    [SerializeField]
    private float moveSpeed = 5f;

    private float minY = -7f;

    private float hp = 1f;

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                GameManager.instance.EnemyKilled();
                Destroy(gameObject);
                Instantiate(heart, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);

        }

    }
}
