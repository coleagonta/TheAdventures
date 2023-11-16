using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;
    public int attackDamage = 20;
    public float attackRadius = 1.5f;
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
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

    // Вызывается из анимации в момент удара (см. настройки аниматора)
    public void DealDamage()
    {
        // Получаем все объекты в радиусе атаки
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRadius);

        foreach (Collider enemy in hitEnemies)
        {
            // Проверяем, является ли объект врагом
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Наносим урон врагу
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    // Метод для получения урона персонажем
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Дополнительные действия при смерти персонажа, например, воспроизведение анимации, удаление объекта и т.д.
        Destroy(gameObject);
    }
}