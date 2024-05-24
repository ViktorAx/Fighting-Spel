using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField]public Image healthBar;
    //public float healthAmount = 100f;
    public float maxHealth;
    public float currentHelath;

    // Start is called before the first frame update
    void Start()
    {
        currentHelath = maxHealth;
    }

    // Update is called once per frame
    public void UpdateHealth(float amount)
    {
        currentHelath += amount;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = currentHelath / maxHealth;
        healthBar.fillAmount = targetFillAmount;
    }
}
