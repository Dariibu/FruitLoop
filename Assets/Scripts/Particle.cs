using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{

    public float vi; // initial velocity
    public float gravity;
    public float life; // Duration in seconds
    public float time; // track time
    public float angle;
    public bool desaparece = false;

    public AudioSource fail;

    private void Start()
    {
        GameObject sonido = GameObject.FindWithTag("fail");
        fail = sonido.GetComponent<AudioSource>();
        //gameObject.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "suelo")
        {
            fail.Play();
            desaparece = true;
        }
        if (other.gameObject.tag == "agua")
        {
            fail.Play();
            desaparece = true;
        }
        if (other.gameObject.tag == "puntos")
        {
            desaparece = true;
        }
        if (other.gameObject.tag == "por_dos")
        {
            desaparece = true;

        }
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "suelo")
        {
            desaparece = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "suelo")
        {
            desaparece = true;
        }
    }
    */
    //Add this script to a prefab
}
