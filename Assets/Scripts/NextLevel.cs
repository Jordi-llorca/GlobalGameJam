using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private LevelLoader gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<LevelLoader>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.LoadNextLevel();
        }
    }
}
