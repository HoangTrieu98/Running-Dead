using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] Rigidbody bulletRigidBody;
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage;
    private void Update()
    {
        bulletRigidBody.velocity = transform.forward * velocity;

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInParent<Enemycontroll>().TakeDamage(damage);
            Debug.Log("Hit");
        }
        if (other.gameObject.CompareTag("Head"))
        {
            other.gameObject.GetComponentInParent<Enemycontroll>().TakeDamage(damage*2);
            Debug.Log("HeadShot");
        }
        Destroy(gameObject);
    }


}
