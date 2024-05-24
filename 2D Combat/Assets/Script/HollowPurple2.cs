using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class HollowPurple2 : MonoBehaviour
{
    public GameObject explosionEffecT;

    HealthManager PlayerhealthScript;

    float speeD = 4;

    // Start is called before the first frame update
    void Start()
    {
        PlayerhealthScript = GameObject.FindGameObjectWithTag("Health1").GetComponent<HealthManager>();

        transform.position = new Vector2(transform.position.x, transform.position.y);
        if (Movement.flip)
        {
            speeD = -speeD;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speeD * Time.deltaTime, transform.position.y);
    }


    //public void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Instantiate(explosionEffecT, transform.position, transform.rotation);
    //        PlayerhealthScript.TakeDamage(20);
    //        Destroy(gameObject);

    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerhealthScript.TakeDamage(20);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }





}
