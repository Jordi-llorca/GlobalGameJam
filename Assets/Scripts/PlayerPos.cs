using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private LevelLoader ll;
    private Rigidbody2D rb;
    public float to_die_time;

    public bool muerte;
    void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        ll = GameObject.FindGameObjectWithTag("LL").GetComponent<LevelLoader>();
        transform.position = gm.lastCheckPointPos;
        rb = GetComponent<Rigidbody2D>();
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
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(to_die_time);
        ll.ReloadLevel();
    }
}
