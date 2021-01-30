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
        transform.position = new Vector3(camara.transform.position.x, 0, transform.position.z);
        float res = transform.position.x - prevPos.x;
        if (res != 0)
        {
            _renderer.material.mainTextureOffset = _renderer.material.mainTextureOffset + new Vector2(velocityOffset * Time.deltaTime * res, 0);
        }

        prevPos = transform.position;
    }
}
