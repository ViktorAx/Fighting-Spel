using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class HollowPurple : MonoBehaviour
{
    public GameObject explosionEffect;

    HealthManager healthManagerScript;

    float speed = 4;

    // Start is called before the first frame update
    void Start()
    {

        healthManagerScript = GameObject.FindGameObjectWithTag("Health1").GetComponent<HealthManager>();

        transform.position = new Vector2(transform.position.x, transform.position.y);
        if (movement2.flip)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthManagerScript.TakeDamage1(20);
            Destroy(gameObject);
        }
    }






}
