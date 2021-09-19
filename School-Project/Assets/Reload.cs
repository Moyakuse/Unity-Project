using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RoomDespawner")
        {
            Debug.Log("LOLOLOL");
            SceneManager.LoadScene(0);
        }
    }
}
