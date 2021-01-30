using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    int layerMask = ~(1 << 8);
    public float range;
    public GameObject matar;
    private float direccion = 1;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0) direccion = Mathf.Sign(h);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * direccion, range, layerMask);

        // If it hits something...
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Antipolilla")
            {
                hit.collider.GetComponent<Antipolilla>().iluminado = true;
                Instantiate(matar, transform.position + new Vector3(hit.distance * direccion, 0, 0), Quaternion.identity);
            }
            if (hit.collider.tag == "AntipolillaAndante")
            {
                hit.collider.GetComponent<AntipolillaAndante>().iluminado = true;
                Instantiate(matar, transform.position + new Vector3(hit.distance * direccion, 0, 0), Quaternion.identity);
            }
            if (hit.collider.tag == "Polilla")
            {
                hit.collider.GetComponent<PolillaAndante>().iluminado = true;
            }
            if (hit.collider.tag == "PolillaTrampa")
            {
                hit.collider.GetComponent<PolillaTrampa>().iluminado = true;
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * range, Color.white);
        }
    }
}
