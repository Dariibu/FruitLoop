using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaCamaraFruta2 : MonoBehaviour
{
   // public Transform fruta;
    public GameObject algo1;
    public GameObject algo2;
    public GameObject algo3;
    public GameObject algo4;
    public GameObject algo5;

    public GameObject disparador;

    bool activo;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position += new Vector3 (0, 0, 0);
    }

    IEnumerator Mover()
    {
        yield return new WaitForSeconds(0.00001f);

        if (algo1 != null)
        {
            gameObject.transform.LookAt(algo1.transform);
            gameObject.transform.position = algo1.transform.position / 1.2f;
        }
        if (algo2 != null)
        {
            gameObject.transform.LookAt(algo2.transform);
            gameObject.transform.position = algo2.transform.position / 1.2f;
        }
        if (algo3 != null)
        {
            gameObject.transform.LookAt(algo3.transform);
            gameObject.transform.position = algo3.transform.position / 1.2f;
        }
        if (algo4 != null)
        {
            gameObject.transform.LookAt(algo4.transform);
            gameObject.transform.position = algo4.transform.position / 1.2f;
        }
        if (algo5 != null)
        {
            gameObject.transform.LookAt(algo5.transform);
            gameObject.transform.position = algo5.transform.position / 1.2f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (disparador.GetComponent<ParticleManger>().Started == true)
        {

            algo1 = GameObject.FindWithTag("manzana");
            algo2 = GameObject.FindWithTag("pera");
            algo3 = GameObject.FindWithTag("cereza");
            algo4 = GameObject.FindWithTag("naranja");
            algo5 = GameObject.FindWithTag("platano");

            if (Input.GetKeyDown(KeyCode.F))
            {
                activo = true;
                
            }
            if (activo == true)
            {
                StartCoroutine("Mover");
            }
        }
    }
}
