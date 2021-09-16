using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int EnemyHealth = 100;
    public ParticleSystem particle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HitEnemy();

            if (EnemyHealth <= 0)
            {

                Die();
                WallsDown();
            }
        }
    }
    private void HitEnemy()
    {
        EnemyHealth -= 50;
    }
    
    private void WallsDown()
    {
        
        SpawnEnemy.wallsDown = true;

    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
