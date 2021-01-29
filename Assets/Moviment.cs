using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    public float vel=5;
    public bool grounded=false;
    public float fuerzasalto=10f;
    // Update is called once per frame
    void Update()
    {
        float h=Input.GetAxis("Horizontal");
        
        transform.Translate(Vector2.right*h*Time.deltaTime*vel);
        
        if(Input.GetKeyDown(KeyCode.W))
        {
            jump();
        }
        
    }
    void jump(){
        if(grounded==true){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, fuerzasalto),ForceMode2D.Impulse);
        }   
    }
}