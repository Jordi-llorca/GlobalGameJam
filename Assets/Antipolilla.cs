using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antipolilla : MonoBehaviour
{
    public bool sound;
    public Animator transition;
    private PlayerPos player;

    int layerMask = 1 << 8;
    public float range = 4f;
    public float offsetX;
    public float offsetY;

    public bool iluminado;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        iluminado = false;
        sound = true;
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(offsetX, offsetY, 0) , Vector2.left, range, layerMask);

        if (hit.collider && !iluminado)
        {
            Debug.DrawRay(transform.position + new Vector3(offsetX, offsetY, 0), transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            if (sound) { FindObjectOfType<AudioManager>().Play("Antipolilla"); sound = false; }
            transition.SetTrigger("Ataque");
            player.muerte = true;
        } else {
            Debug.DrawRay(transform.position + new Vector3(offsetX, offsetY, 0), transform.TransformDirection(Vector3.left) * range, Color.white);
            iluminado = false;
        }
    }
}