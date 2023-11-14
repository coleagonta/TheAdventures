using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
           
            Attack();
        }
    }

    private void Attack()
    {
       
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
           
            animator.SetTrigger("Attack");
        }
    }
}