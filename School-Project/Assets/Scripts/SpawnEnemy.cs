using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    private Collider2D wall;
    private bool SpawnEnemyOnce = true;

    public Animator Door;
    private GameObject temp;
    public static bool wallsDown;

    void Start()
    {
        wall = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (wallsDown == true)
        {
            Door.SetBool("DoorOpen", true);
            wall.isTrigger = true;
        }

        GameObject[] bottomObjects = GameObject.FindGameObjectsWithTag("Bottom");

        for (int i = 1; i < bottomObjects.Length; i++)
        {
            GameObject temp = bottomObjects[i];
            Destroy(temp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && SpawnEnemyOnce == true)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnEnemyOnce = false;
            wall.isTrigger = false;
            Door.SetBool("DoorOpen", false);
            Debug.Log("works");
        }
    }
}
