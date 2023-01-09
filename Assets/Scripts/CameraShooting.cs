using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShooting : MonoBehaviour
{
    public GameObject disparador;
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, disparador.GetComponent<ParticleManger>().Gamma, 0);
    }
}
