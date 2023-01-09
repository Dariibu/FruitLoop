using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arosvoladores : MonoBehaviour
{
    public GameObject caldero;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "manzana" || other.gameObject.tag == "pera" || other.gameObject.tag == "naranja" || other.gameObject.tag =="cereza" || other.gameObject.tag == "platano")
        {
            caldero.GetComponent<Puntuación>().volador = true;
        }

    }
}
