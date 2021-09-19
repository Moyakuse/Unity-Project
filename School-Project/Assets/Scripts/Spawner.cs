using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    GameObject[] SpawnerObject;
    string[] spawnerTags = new string[] { "Enemy", "Enemy", "Boss", "Basement"};

    void Start()
    {
        Invoke("Test", 1.0f);
    }

    void Update()
    {
    }

    void Test()
    {
        GameObject[] Spawner = GameObject.FindGameObjectsWithTag("Spawner");

        if (Spawner.Length != 4)
        {
            SceneManager.LoadScene(0);
        }
        for (int i = 0; i < Spawner.Length; i++)
        {
            Spawner[i].tag = spawnerTags[i];
        }
        Debug.Log(spawnerTags.Length);
    }
}
