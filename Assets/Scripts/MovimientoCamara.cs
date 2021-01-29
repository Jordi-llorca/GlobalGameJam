using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject jugador;

    // 0 limite iquierda  // 1 limite derecha
    public GameObject [] limites = new GameObject [2];
    private void FixedUpdate()
    {
        transform.position = new Vector3(jugador.transform.position.x, 0, transform.position.z);
        transform.position = new Vector3(0, jugador.transform.position.y, transform.position.z);

        if (jugador.transform.position.x > limites[0].transform.position.x && jugador.transform.position.x < limites[1].transform.position.x)
            transform.position = new Vector3(jugador.transform.position.x, 0, transform.position.z);
        else if (jugador.transform.position.x < limites[0].transform.position.x)
            transform.position = new Vector3(limites[0].transform.position.x, 0, transform.position.z);
        else
            transform.position = new Vector3(limites[1].transform.position.x, 0, transform.position.z);

    }
}
