using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject jugador;
    public float offset = 0;
    private static MovimientoCamara instance;

    // 0 limite iquierda  // 1 limite derecha
    public GameObject [] limites = new GameObject [2];
    private void FixedUpdate()
    {
        transform.position = new Vector3(jugador.transform.position.x + offset, 0, transform.position.z);

        if (jugador.transform.position.x + offset > limites[0].transform.position.x && jugador.transform.position.x + offset < limites[1].transform.position.x)
            transform.position = new Vector3(jugador.transform.position.x + offset, 0, transform.position.z);
        else if (jugador.transform.position.x + offset < limites[0].transform.position.x)
            transform.position = new Vector3(limites[0].transform.position.x, 0, transform.position.z);
        else
            transform.position = new Vector3(limites[1].transform.position.x, 0, transform.position.z);

    }
}
