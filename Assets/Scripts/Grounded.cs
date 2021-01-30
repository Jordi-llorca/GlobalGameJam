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
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag=="Suelo"){
               
                Player.GetComponent<Moviment>().grounded=true;
                anim.SetBool("grounded",true);
            }
        }
         private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.tag=="Suelo")
            {
                anim.SetBool("grounded",true);
                Player.GetComponent<Moviment>().grounded=false;
            }
        }
}
