using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelStartMenu : MonoBehaviour
{
    public GameObject panel;

    [SerializeField] GameObject Mc;
    [SerializeField] GameObject SideCharacter;
    [SerializeField] GameObject EnemyAi;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideMenu()
    {
        panel.SetActive(false);

    }
    public void showMenu()
    {
        panel.SetActive(true);

    }

    public void onePlayer()
    {
        Vector2 startPos = new Vector2(-7, 0);
        Instantiate(Mc, startPos,transform.rotation);
        Vector2 startPOs = new Vector2(7, 0);
        Instantiate(EnemyAi, startPOs, transform.rotation);
    }

    public void TwoPlayer()
    {
        Vector2 startPos = new Vector2(-7, 0);
        Instantiate(Mc, startPos, transform.rotation);
        Vector2 startPoS = new Vector2(7, 0);
        Instantiate(SideCharacter, startPoS, transform.rotation);
    }


}
