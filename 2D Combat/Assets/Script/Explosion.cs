using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosionEffect, collision.transform.position, Quaternion.identity); // Instantiate explosion at enemy position


        /*if (collision.gameObject.TryGetComponent<NewHealth>(out NewHealth enemyComponent))
        {
            enemyComponent.takeDamage(1);
        }*/
        

        Destroy(gameObject);
    }
}
