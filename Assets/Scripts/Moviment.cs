﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Animator anim;
    private float x;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        x=transform.localScale.x;
    }
    public float vel=5;
    public bool grounded=false;
    public float fuerzasalto=10f;

    private bool andando = false;
    public bool prevandando = false;
    // Update is called once per frame
    void Update()
    {
        
        float h=Input.GetAxis("Horizontal");
        andando = h != 0;
        if (andando && !prevandando){
            FindObjectOfType<AudioManager>().Play("Walking");
            anim.SetBool("prevandando",true);
            anim.SetBool("grounded",true);
        } else if (!andando) {
            FindObjectOfType<AudioManager>().Stop("Walking");
            anim.SetBool("prevandando",false);
            anim.SetBool("grounded",true);
        }
        transform.Translate(Vector2.right*h*Time.deltaTime*vel);
        if(h>0)
        {
            transform.localScale = new Vector2(x,transform.localScale.y);
        }else if (h<0)
        {
            transform.localScale = new Vector2(-x,transform.localScale.y);
        }


        if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
        }
        if(grounded)
        {
            anim.SetBool("salto", false);
        }
        if(!grounded)
        {
            anim.SetBool("prevandando",false);
            anim.SetBool("salto", true);
        }
    }
    void jump(){
        if(grounded==true){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, fuerzasalto),ForceMode2D.Impulse);
            anim.SetTrigger("Salto");
            
        }   
    }
}