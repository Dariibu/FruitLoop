using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCameraMov : MonoBehaviour
{
    public GameObject fruta;
    public GameObject disparador;
    Vector3 distancia = new Vector3();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fruta = disparador.GetComponent<ParticleManger>().FrutaEscogida;

        if ( fruta != null)
        {
            Move();
        }
        else
        {
            Stop();
        }
    }

    void Move()
    {
        distancia = fruta.transform.position - transform.position;

        transform.position = fruta.transform.position - distancia;

        transform.rotation = Quaternion.Euler(0, disparador.GetComponent<ParticleManger>().Alpha, 0);
    }
    void Stop()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
