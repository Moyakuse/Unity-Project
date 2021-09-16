using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float xPoint;
    private float yPoint;
    public int speed;
    Vector2 target;
    bool oneTime = true;
    bool isChasingPlayer;
    public float WaitTime = 1f;
    private Transform player;
    public float DetectPlayerRange;
    public float stoppingDistance;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (oneTime == true)
        {
            StartCoroutine(Wait());
        }

        if (Vector2.Distance(transform.position, target) > 1 && isChasingPlayer == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            oneTime = false;
        }
        else if (Vector2.Distance(transform.position, target) < 1)
        {
            oneTime = true;
        }

        if (Vector2.Distance(transform.position, player.position) < DetectPlayerRange)
        {
            isChasingPlayer = true;
            speed = 4;
            if (isChasingPlayer == true && Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            
        }
        else
        {
            isChasingPlayer = false;
            speed = 3;
        }
    }

    void EnemyMoveTo()
    {
        
        xPoint = Random.Range(-13, 25);
        yPoint = Random.Range(-9, 1);
        target = new Vector2(xPoint, yPoint);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(WaitTime);
        if (oneTime == true)
        {
            EnemyMoveTo();
        }
        yield break;
    }
}
