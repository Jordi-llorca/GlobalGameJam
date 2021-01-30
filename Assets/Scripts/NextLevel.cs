using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private LevelLoader ll;
    private GameMaster gm;
    public Transform start;

    private void Start()
    {
        ll = GameObject.FindGameObjectWithTag("LL").GetComponent<LevelLoader>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ll.LoadNextLevel();
            gm.lastCheckPointPos = new Vector2(-17, (float) -1.25);
        }
    }
}
