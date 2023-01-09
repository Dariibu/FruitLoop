using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camarafrutas : MonoBehaviour
{

    public Transform fruta;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(fruta);
    }
}
