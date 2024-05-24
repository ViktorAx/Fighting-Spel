using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] public Image healthBar1;
    [SerializeField] public TextMeshProUGUI winnerText;
    [SerializeField] public GameObject gameOverMenu;

    public float healthAmount = 100f;
    public float healthAmount1 = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (healthAmount <= 0)
        {
            ShowPanel();
            winnerText.text = "Player2 Won!";
            Heal();
        }
        if (healthAmount1 <= 0)
        {
            ShowPanel();
            winnerText.text = "Player1 Won!";
            Heal();
        }
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
    public void ShowPanel()
    {
        gameOverMenu.SetActive(true);
    }

    public void Heal()
    {
        healthAmount = 100;
        healthAmount1 = 100;
        healthBar.fillAmount = healthAmount / 100f;
        healthBar1.fillAmount = healthAmount1 / 100f;
    }
}
