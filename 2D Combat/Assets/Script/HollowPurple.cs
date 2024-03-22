using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowPurple : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + 4 * Time.deltaTime, transform.position.y);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
