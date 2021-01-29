using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private LevelLoader ll;
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        ll = GameObject.FindGameObjectWithTag("LL").GetComponent<LevelLoader>();
        transform.position = gm.lastCheckPointPos;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){ //Condicion muerte
            ll.ReloadLevel();
        }
    }
}
