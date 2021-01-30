using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
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
        _renderer.material.mainTextureOffset = _renderer.material.mainTextureOffset + new Vector2(0, velocityOffset * Time.deltaTime);
    }
}
