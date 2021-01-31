using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntipolillaAndante : MonoBehaviour
{
    public Transform pos1, pos2;
    public float vel;
    public Transform inicio;
    private PlayerPos player;
    public bool iluminado;
    public bool sound;

    public Animator transition;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        iluminado = false;
        sound = true;
    }
    void Update()
    {
        if (transform.position.x <= pos1.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
            vel *= -1; 
        }
        if (transform.position.x >= pos2.position.x)
        {
            transform.localScale = new Vector2(1, 1);
            vel *= -1;
        }
        transform.Translate(Vector3.right * -vel * Time.deltaTime);

        if (iluminado)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (sound) { FindObjectOfType<AudioManager>().Play("Antipolilla"); sound = false; }
            transition.SetTrigger("Ataque");
            player.muerte = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sound = true;
    }
}
