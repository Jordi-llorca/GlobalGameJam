using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor.Experimental.SceneManagement;
public class Linterna : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject linterna;
    private bool Enabled;
    void Start()
    {
        Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Enabled)
            {
                linterna.SetActive(Enabled);
                Enabled = false;
            }else {
                linterna.SetActive(Enabled);
                Enabled = true;
            }
        }
    }
}
