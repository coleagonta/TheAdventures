using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack Triggered");
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        // Запуск анимации атаки
        animator.SetTrigger("Attack");

        // Дождаться завершения анимации атаки
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        isAttacking = false;
    }
}