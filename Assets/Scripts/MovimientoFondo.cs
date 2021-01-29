using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    public GameObject camara;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = this.GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(camara.transform.position.x, 0, transform.position.z);
        _renderer.material.mainTextureOffset = new Vector2(camara.transform.position.x, 0);
    }
}
