using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class HollowPurple : MonoBehaviour
{
    float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        if (Movement.flip)
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

    public void FlightDirection()
    {

    }

}
