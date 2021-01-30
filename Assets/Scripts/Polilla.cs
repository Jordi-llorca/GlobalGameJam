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

    public bool iluminado;

    //perseguir al jugador
    public Transform jugador;
    public float moveSpeed;
    float localSpeed;
    Rigidbody2D rb;
    bool right = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPos>();
        iluminado = false;
        sound = true;
        rb = GetComponent<Rigidbody2D>();
        localSpeed = moveSpeed;
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(offsetX, offsetY, 0) , Vector2.left, range, layerMask);
        float distToPlayer = Vector2.Distance(transform.position, jugador.position);
        if (hit.collider)
        {
            Debug.DrawRay(transform.position + new Vector3(offsetX, offsetY, 0), transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            transition.SetTrigger("Pause");
        } else {
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
