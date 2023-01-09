using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aros : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject caldero;
    public bool volador;
    public AudioSource SumaPunto;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "manzana")
        {
            SumaPunto.Play();
            caldero.GetComponent<Puntuación>().puntosManz += 1;
            caldero.GetComponent<Puntuación>().Updatear();
            volador = caldero.GetComponent<Puntuación>().volador;
            if (volador == true)
            {
                caldero.GetComponent<Puntuación>().puntosManz += 1;
                caldero.GetComponent<Puntuación>().Updatear();
            }
        }
        if (other.gameObject.tag == "pera")
        {
            SumaPunto.Play();
            caldero.GetComponent<Puntuación>().puntosPera += 1;
            caldero.GetComponent<Puntuación>().Updatear();
            volador = caldero.GetComponent<Puntuación>().volador;

            if (volador == true)
            {
                caldero.GetComponent<Puntuación>().puntosPera += 1;
                caldero.GetComponent<Puntuación>().Updatear();
                caldero.GetComponent<Puntuación>().volador = false;
            }
        }
        if (other.gameObject.tag == "naranja")
        {
            SumaPunto.Play();
            caldero.GetComponent<Puntuación>().puntosNara += 1;
            caldero.GetComponent<Puntuación>().Updatear();
            volador = caldero.GetComponent<Puntuación>().volador;

            if (volador == true)
            {
                caldero.GetComponent<Puntuación>().puntosNara += 1;
                caldero.GetComponent<Puntuación>().Updatear();
                caldero.GetComponent<Puntuación>().volador = false;
            }
        }
        if (other.gameObject.tag == "cereza")
        {
            SumaPunto.Play();
            caldero.GetComponent<Puntuación>().puntosCere += 1;
            caldero.GetComponent<Puntuación>().Updatear();
            volador = caldero.GetComponent<Puntuación>().volador;

            if (volador == true)
            {
                caldero.GetComponent<Puntuación>().puntosCere += 1;
                caldero.GetComponent<Puntuación>().Updatear();
                caldero.GetComponent<Puntuación>().volador = false;
            }
        }
        if (other.gameObject.tag == "platano")
        {
            SumaPunto.Play();
            caldero.GetComponent<Puntuación>().puntosPlat += 1;
            caldero.GetComponent<Puntuación>().Updatear();
            volador = caldero.GetComponent<Puntuación>().volador;

            if (volador == true)
            {
                caldero.GetComponent<Puntuación>().puntosPlat += 1;
                caldero.GetComponent<Puntuación>().Updatear();
                caldero.GetComponent<Puntuación>().volador = false;
            }
        }
    }
}
