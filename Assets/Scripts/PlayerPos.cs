﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private LevelLoader ll;

    public float to_die_time;

    public bool muerte;
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        ll = GameObject.FindGameObjectWithTag("GM").GetComponent<LevelLoader>();
        transform.position = gm.lastCheckPointPos;

        muerte = false;
    }
    void Update()
    {
        if (muerte){ //Condicion muerte
            StartCoroutine(Muerte());
        }
    }

    IEnumerator Muerte()
    {
        yield return new WaitForSeconds(to_die_time);
        ll.ReloadLevel();
    }
}