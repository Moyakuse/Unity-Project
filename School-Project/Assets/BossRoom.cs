using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public GameObject BossGround;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossTag")
        {
            BossGround.SetActive(true);
            Debug.Log("Hi");
        }
    }
}
