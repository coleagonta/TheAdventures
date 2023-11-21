using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    private int currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking && !IsMoving())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(AttackAnimation());
            }
        }
        
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("attack", false);
        }
    }

    IEnumerator AttackAnimation()
    {
        isAttacking = true;
        animator.SetBool("attack", true);

        // Ждем завершения анимации атаки
        yield return new WaitForSeconds(0.5f);

        animator.SetBool("attack", false);
        isAttacking = false;
    }

    private bool IsMoving()
    {
        return false;
    }
}