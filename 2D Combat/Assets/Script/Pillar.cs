using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private float X;
    private float Y = -7f;
    public float LifeTime = 5;
    public float RiseTime = 1f;

    [SerializeField] string Tag = "Projectiles";
 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, Y);
    }

    // Update is called once per frame
    void Update()
    {
        RiseTime -= Time.deltaTime;

        transform.position = new Vector2(transform.position.x, Y);

        if (RiseTime >= 0.0f)
        {
            Y += 0.01f;
        }
        else
        {
            Life();
        }
    }

    public void Life()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0.0f)
        {
            timerEnded();
        }

        if (Input.GetKeyDown(KeyCode.G) && LifeTime >= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            timerEnded();
        }
    }
}

