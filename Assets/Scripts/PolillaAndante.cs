using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolillaAndante : MonoBehaviour
{
    public Transform pos1, pos2;
    public float velInicial;
    public Transform inicio;
    private PlayerPos player;
    public bool iluminado;
    public bool sound;
    private float vel;
    public Animator transition;
    private int mov;
    private bool previlu;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        iluminado = false;
        previlu = !iluminado;
        sound = true;
        vel = velInicial;
        mov = 1;
    }
    void Update()
    {
        if(!iluminado)
        {
            if (transform.position.x <= pos1.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
                mov = -1;
            }
            if (transform.position.x >= pos2.position.x)
            {
                transform.localScale = new Vector2(1, 1);
                mov = 1;
            }
        }
        transform.Translate(Vector3.right * -vel * mov * Time.deltaTime);

        if (iluminado && !previlu){
            vel *= 2;
            previlu = true;
            transform.localScale = new Vector2(1, 1);
            mov = 1;
        } else if(!iluminado){
            vel = velInicial;
            previlu = false;
        }

        iluminado = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (sound) { FindObjectOfType<AudioManager>().Play("Antipolilla"); sound = false; }
            player.muerte = true;
        }
    }
}

