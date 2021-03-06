﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private LevelLoader ll;
    public Moviment pl;
    public float to_die_time;

    public bool muerte;
    void Start(){
        //rb.constraints = RigidbodyConstraints2D.None;
        //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        ll = GameObject.FindGameObjectWithTag("LL").GetComponent<LevelLoader>();
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
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        pl.vel=0;
        yield return new WaitForSeconds(to_die_time);
        ll.ReloadLevel();
    }
}
