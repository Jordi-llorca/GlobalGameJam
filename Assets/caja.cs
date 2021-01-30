using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caja : MonoBehaviour
{
    private Moviment player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Moviment>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * Time.deltaTime * player.vel);
    }
}
