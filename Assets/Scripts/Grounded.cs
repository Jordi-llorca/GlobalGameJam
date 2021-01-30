using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Player=gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag=="Suelo"){
               
            Player.GetComponent<Moviment>().grounded=true;
            //anim.SetBool("grounded",true);
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            Player.GetComponent<Moviment>().grounded = true;
            Player.transform.parent = other.gameObject.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag=="Suelo")
        {
            //anim.SetBool("grounded",true);
            Player.GetComponent<Moviment>().grounded=false;
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            Player.GetComponent<Moviment>().grounded = false;
            Player.transform.parent = null;
        }
    }
}
