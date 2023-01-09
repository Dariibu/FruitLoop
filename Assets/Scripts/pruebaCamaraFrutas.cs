using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaCamaraFrutas : MonoBehaviour
{
    public Transform fruta;
    public GameObject ff;
    float gamma;

    void Start()
    {
        ff = GameObject.FindWithTag("ff");
        gamma = ff.GetComponent<ParticleManger>().Gamma;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(fruta);

        if (gamma < 45 && gamma > 0 || gamma < 360 && gamma > 315)
        {
            transform.rotation = Quaternion.Euler(0, 360, 0);
        }
        else if (gamma > 90 && gamma < 180)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (gamma > 180 && gamma < 270)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (gamma > 270 && gamma < 360)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

}
