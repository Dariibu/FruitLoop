using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuación : MonoBehaviour
{

    public float puntosManz = 0;
    public float puntosPera = 0;
    public float puntosPlat = 0;
    public float puntosCere = 0;
    public float puntosNara = 0;

    public bool volador = false;

    public Text PuntosManzT;
    public Text PuntosPeraT;
    public Text PuntosPlatT;
    public Text PuntosCereT;
    public Text PuntosNaraT;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    public void Updatear()
    {
            PuntosManzT.text = "" + puntosManz;

            PuntosPeraT.text = "" + puntosPera;

            PuntosPlatT.text = "" + puntosPlat;

            PuntosCereT.text = "" + puntosCere;

            PuntosNaraT.text = "" + puntosNara;
    }
}