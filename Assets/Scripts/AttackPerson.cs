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
        if(Input.GetButtonDown("Fire1")) animator.SetBool("attack",true);
        if(Input.GetButtonUp("Fire1")) animator.SetBool("attack",false);
    }

   
}