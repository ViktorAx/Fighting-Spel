using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]public Image healthBar;
    [SerializeField] public Image healthBar1;
    public float healthAmount = 100f;
    public float healthAmount1 = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void TakeDamage1(float damage)
    {
        healthAmount1 -= damage;
        healthBar1.fillAmount = healthAmount1 / 100f;
    }
}
