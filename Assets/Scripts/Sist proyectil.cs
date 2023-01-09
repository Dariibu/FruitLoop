using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistproyectil : MonoBehaviour
{
    public float Tiempo = 0;
    public float TiempoIncrmento;

    public float gravedad = 9.8f; 



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TiempoIncrmento = Tiempo++; 
    }
}
