using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AttackControls : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] GameObject pillarPre;
    private float pillarCooldown = 5f;
    private bool pillarAvalible = true;

    [SerializeField] GameObject hollowPurplePre;
    private float hollowCooldown = 5f;
    private bool hollowAvalible = true;

    public KeyCode StonePillar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pillarCooldown -= Time.deltaTime;
        hollowCooldown -= Time.deltaTime;

        if (pillarCooldown <= 0.0f)
        {
            pillarAvalible = true;
        }

        if (hollowCooldown <= 0.0f)
        {
            hollowAvalible = true;
        }

        if (Input.GetKeyDown(StonePillar) && pillarAvalible)// && Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(pillarPre, playerPos.position, transform.rotation);
            pillarCooldown = 5;
            pillarAvalible = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && hollowAvalible)
        {
            Instantiate(hollowPurplePre, playerPos.position, transform.rotation);
            hollowCooldown = 5;
            hollowAvalible = false;
        }

    }
}
