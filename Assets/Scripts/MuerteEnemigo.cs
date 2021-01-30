using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteEnemigo : MonoBehaviour
{
    public float time;
    void Start()
    {
        StartCoroutine(Muerte(time));
    }
    IEnumerator Muerte(float t)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
