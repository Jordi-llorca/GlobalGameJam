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

    private bool andando = false;
    private bool prevandando = false;
    // Update is called once per frame
    void Update()
    {
        float h=Input.GetAxis("Horizontal");
        andando = h != 0;
        if (andando && !prevandando){
            FindObjectOfType<AudioManager>().Play("Walking");
            prevandando = true;
        } else if (!andando) {
            FindObjectOfType<AudioManager>().Stop("Walking");
            prevandando = false;
        }
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