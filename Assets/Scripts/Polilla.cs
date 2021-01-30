using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polilla : MonoBehaviour
{
    public bool sound;
    public Animator transition;
    private PlayerPos player;

    int layerMask = 1 << 8;
    public float range = 4f;
    public float offsetX;
    public float offsetY;

    

    //perseguir al jugador
    public Transform jugador;
    public float moveSpeed;
    float localSpeed;
    Rigidbody2D rb;
    bool right = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        sound = true;
        rb = GetComponent<Rigidbody2D>();
        localSpeed = moveSpeed;
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(offsetX, offsetY, 0) , Vector2.left, range, layerMask);
        
        if (hit.collider==null)
        {
            Debug.DrawRay(transform.position + new Vector3(offsetX, offsetY, 0), transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            transition.SetTrigger("Pause");
        } 
        if (hit.collider){
            Debug.DrawRay(transform.position + new Vector3(offsetX, offsetY, 0), transform.TransformDirection(Vector3.left) * range, Color.white);
            if (sound) { FindObjectOfType<AudioManager>().Play("Antipolilla"); sound = false; }
            transition.SetTrigger("Ataque");
            ChasePlayer();

        }
    }
    public void ChasePlayer()
    {
        localSpeed = moveSpeed;
        if (transform.position.x < jugador.position.x)
        {
            transform.Translate(Vector3.right * localSpeed * Time.deltaTime);
            if (!right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                right = true;
            }
        }
        else if (transform.position.x > jugador.position.x)
        {

            transform.Translate(Vector3.right * -localSpeed * Time.deltaTime);
            if (right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                right = false;
            }
        } 
    }
}
