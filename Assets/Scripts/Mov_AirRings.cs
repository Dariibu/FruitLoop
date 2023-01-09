using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_AirRings : MonoBehaviour
{
    float Timer;
    float TimerI;
    float MaxHigh;
    float MaxDown;
    float Started;
    float Moving;
    bool Up;
   
    // Start is called before the first frame update
    void Start()
    {
        Up = false;
        Moving = 1.2f;

        MaxHigh = gameObject.transform.position.y + 3;
        MaxDown = gameObject.transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = TimerI + Time.deltaTime;

        if (gameObject.transform.position.y > MaxHigh)
        {
            Up = true;
        }
        else if (gameObject.transform.position.y < MaxDown)
        {
            Up = false;
        }

        if (Up == true)
        {
            Baja();
        }
        else if (Up == false)
        {
            Sube();
        }
    }
    void Sube()
    {
        TimerI = 0;
        Vector3 subiendo = new Vector3 (0, Moving * Timer, 0);
        gameObject.transform.position += subiendo;
    }
    void Baja()
    {
        TimerI = 0;
        Vector3 bajando = new Vector3(0, Moving * Timer, 0);
        gameObject.transform.position -= bajando;
    }
}
