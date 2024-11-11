using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroll : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Rigidbody enemyRigid;
    public Transform targetPlayer;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider bodyCollider;
    [SerializeField] private SphereCollider headCollider;
    
    
    
    [Header("Parameter")]
   
    [SerializeField] private float currentHealth;
    [SerializeField] private float detectingRange;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceToStop;
    [SerializeField] private int point = 1;

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            headCollider.enabled = false;
            bodyCollider.enabled = false;
            return;
        }


        DetectingTarget();
        transform.LookAt(targetPlayer);
    }

    public void DetectingTarget()
    {
        
        float distanceObject = Vector3.Distance(transform.position, targetPlayer.position);
        if (distanceObject > detectingRange && distanceObject > distanceToStop)
        {
            return;
        }
        if (distanceObject <= detectingRange)
        {
            var velocity = transform.forward * moveSpeed;
            velocity.y = enemyRigid.velocity.y;
            enemyRigid.velocity = velocity;
            animator.SetBool("isWalking", true);
            
            
        }
        if (distanceObject <= distanceToStop)
        {
            var velocity = transform.forward * 0;
            velocity.y = enemyRigid.velocity.y;

            enemyRigid.velocity = velocity;
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyFalling"))
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
           
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);
            CountPoint.AddScore(point);
            Destroy(gameObject, 1.2f);
            
        }
    }
}
