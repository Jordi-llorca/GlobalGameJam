using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondoMenu : MonoBehaviour
{

    public float velocityOffset = 1f;
    public float offset;
    private Renderer _renderer;
    private void Start()
    {
        _renderer = this.GetComponent<Renderer>();
    }
    private void FixedUpdate()
    {
       _renderer.material.mainTextureOffset = _renderer.material.mainTextureOffset + new Vector2(velocityOffset * Time.deltaTime, 0);
    }
}
