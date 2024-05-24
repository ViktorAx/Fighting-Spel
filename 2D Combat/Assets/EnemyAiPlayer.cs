using System.Collections;
using UnityEngine;

public class EnemyAiPlayer : MonoBehaviour
{
    private GameObject target;
    public float speed = 2.0f;
    public float attackRange = 5.0f;
    public GameObject hollowpurplePrefab;
    public GameObject pilarPrefab;
    public Transform attackPoint;

    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetTarget();
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
            AttackTarget();
        }
    }

    void SetTarget()
    {
        if (tag == "PlayerBot")
        {
            target = GameObject.FindWithTag("EnemyBot");
        }
        else if (tag == "EnemyBot")
        {
            target = GameObject.FindWithTag("PlayerBot");
        }
    }

    void MoveTowardsTarget()
    {
        if (!isAttacking)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            Vector3 direction = (target.transform.position - transform.position).normalized;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    void AttackTarget()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(1.0f); // Delay before the attack is fired

        // Instantiate attack based on preference
        if (Random.Range(0, 2) == 0)
        {
            Instantiate(hollowpurplePrefab, attackPoint.position, attackPoint.rotation);
        }
        else
        {
            Instantiate(pilarPrefab, attackPoint.position, attackPoint.rotation);
        }

        yield return new WaitForSeconds(1.0f); // Cooldown period before next action

        isAttacking = false;
    }
}
