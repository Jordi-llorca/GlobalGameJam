using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolillaTrampa : MonoBehaviour
{
    private PlayerPos player;
    private GameObject p;
    public float vel;
    public bool iluminado;
    public bool sound;

    public Animator transition;
    public int direccion;
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        player = p.GetComponent<PlayerPos>();
        iluminado = false;
        sound = true;
    }

    void Update()
    {
        direccion = transform.position.x < p.transform.position.x ? 1 : -1;
        if (iluminado)
        {
            transition.SetBool("Iluminado", true);
            transform.Translate(Vector3.right * vel * direccion * Time.deltaTime);
        } else {
            transition.SetBool("Iluminado", false);
        }
        iluminado = false;
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
