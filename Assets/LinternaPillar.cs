using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaPillar : MonoBehaviour
{
    public GameObject linterna;
    private Linterna player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Linterna>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.enabled = true;
            linterna.SetActive(enabled);
            player.permitida = true;
            Destroy(gameObject);
        } 
    }
}
