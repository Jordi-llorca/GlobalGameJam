using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    public GameObject camara;

    public float velocityOffset = 1f;
    private Renderer _renderer;
    private Vector3 prevPos;
    private void Start()
    {
        prevPos = transform.position;
        _renderer = this.GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        transform.position = new Vector3(camara.transform.position.x, 0, transform.position.z);

        if(prevPos != transform.position) 
            _renderer.material.mainTextureOffset = _renderer.material.mainTextureOffset + new Vector2(velocityOffset* Time.deltaTime * h, 0);

        prevPos = transform.position;
    }
}
