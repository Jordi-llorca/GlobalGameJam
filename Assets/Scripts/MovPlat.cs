using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlat: MonoBehaviour
{
    public Transform pos1,pos2;
    public float vel;
    public Transform inicio;
    GameObject Plataforma;

    Vector3 sigPos;
    // Start is called before the first frame update
    void Start()
    {
        sigPos = inicio.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position==pos1.position)
        {
            sigPos = pos2.position;
        }
         if (transform.position==pos2.position)
        {
            sigPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, sigPos, vel * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position,pos2.position);
    }
    
}
