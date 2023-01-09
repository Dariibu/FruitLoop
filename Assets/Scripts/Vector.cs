using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vector
{
    // Start is called before the first frame update
    #region Variables
    public float x;
    public float y;
    public float z;
    #endregion
    #region Constructores
    public Vector()
    {
        x = 0;
        y = 0;
        z = 0;
    }
    public Vector(float _x, float _y, float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }
    public Vector(float angulox, float anguloy, float anguloz, float modulo)
    {
        try
        {

            float comprobar = Mathf.Cos(angulox * angulox) + Mathf.Cos(anguloy * anguloy) + Mathf.Cos(anguloz * anguloz);

           if (( comprobar > 0.99) && (comprobar < 1.01))
            {
                x = modulo * Mathf.Cos(angulox);
                y = modulo * Mathf.Cos(anguloy);
                z = modulo * Mathf.Cos(anguloz);
            }

        }
        catch(Exception e)
        {
            Debug.Log("Ocurrió un error: " + e.Message);
        }     
    }

    #endregion
    #region Metodos
    public static float Magnitude(Vector v)
    {
        float magnitude = Mathf.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);

            return magnitude;
    }
    public static Vector Normalize(Vector v)
    {
        Vector normal = new Vector(v.x/ Magnitude(v), v.y/Magnitude(v), v.z/Magnitude(v));
        return normal;
    }
    public static Vector Reverse(Vector v)
    {
        Vector reverso = new Vector(-v.x, -v.y, -v.z);
        return reverso;
    }
    public static Vector operator +(Vector v, Vector u)
    {
        Vector suma = new Vector();

        suma.x = v.x + u.x;
        suma.y = v.y + u.y;
        suma.z = v.z + u.z;

        return suma;

    }
    public static Vector operator -(Vector v, Vector u)
    {
        Vector resta = new Vector();

        resta.x = v.x - u.x;
        resta.y = v.y - u.y;
        resta.z = v.z - u.z;

        return resta;

    }
    public static Vector operator *(Vector v, float num)
    {
        Vector multiplicar = new Vector();

        multiplicar.x = v.x * num;
        multiplicar.y = v.y * num;
        multiplicar.z = v.z * num;

        return multiplicar;

    }
    public static Vector operator /(Vector v, float num)
    {
        Vector dividir = new Vector();

        dividir.x = v.x / num;
        dividir.y = v.y / num;
        dividir.z = v.z / num;


        return dividir;

    }
    public static float operator *(Vector v, Vector u)
    {
        float producto = 0;

        producto = v.x* u.x + v.y * u.y + v.z * u.z;

        return producto;
    }
    public static Vector operator ^(Vector v, Vector u)
    {
        Vector vectorial = new Vector();
        vectorial.x = v.y * u.z - v.z * u.y;
        vectorial.y = v.z * u.x - v.x * u.z;
        vectorial.z = v.x * u.y - v.y * u.x;

        return vectorial;
    }

    public override string ToString()
    {

        string devuelta = "" + x + "," + y + "," + z;
        return devuelta;
    }

    public static float Triple(Vector z, Vector w, Vector v)
    {
        float triple = 0;
        Vector triplo = new Vector();

        triplo.x = w.y * v.z - w.z * v.y;
        triplo.y = w.z * v.x - w.x * v.z;
        triplo.z = w.x * v.y - w.y * v.x;

        triple = z.x * triplo.x + z.y * triplo.y + z.z * triplo.z;

        return triple;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
    #endregion



}
