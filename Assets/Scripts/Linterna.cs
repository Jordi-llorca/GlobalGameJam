﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject linterna;
    public bool Enabled;

    public bool permitida;
    void Start()
    {
       
        linterna.SetActive(Enabled);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (permitida)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().Play("Linterna");
                if (Enabled)
                {
                    Enabled = false;
                    linterna.SetActive(Enabled);
                }
                else
                {
                    Enabled = true;
                    linterna.SetActive(Enabled);
                }
            }
        }
    }
}
