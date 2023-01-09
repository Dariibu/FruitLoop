using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class referencia : MonoBehaviour
{

    #region Para que dispare

    #region parametros de entrada (jugador)
    [Header("Parametros de entrada del jugador")]

    public float L;      //Longitud cañon
    public float Alpha;  //Angulo que va en vertical
    public float Gamma;  //Angulo que va en horizontal
    public float Yb;     // Y inicial
    #endregion

    #region otras variables (formulas)
    [Header("Variables para las formulas")]
    public float b;  //proyeccion del cañon

    public float x0; // x inicial
    public float z0; // z inicial

    public float Lx; //Componente X de L
    public float Ly; //Componente Y de L
    public float Lz; //Componente Z de L

    public float cosLx; //Coseno director de x
    public float cosLy; //Coseno director de y
    public float cosLz; //Coseno director de z
    #endregion

    #region variables particula
    [Header("Variables para la particula")]
    public float vi_user;        //velocidad incial
    public float gravity_user;   //gravedad incial
    static float life_user = 1f;      //vida de la particula (en tiempo)
                                 //  public float angle_user;     (no hace nada)
    #endregion

    #region variables finales
    [Header("Variables para el resultado final")]
    public float ax = 0;    //aceleracion en x
    public float vx;      //velocidad en x

    public float ay;      //aceleracion en y
    public float vy;      //velocidad en y

    public float az = 0;    //aceleracion en z
    public float vz;      //velocidad en z
    #endregion

    #region otras variables
    [Header("Otras variables")]

    List<GameObject> particleArray = new List<GameObject>();     //Lista almacenar las partículas
    public int max_particles;  //maximo variables (1)
    public GameObject prefab_particle;  //prefab de la bala
    public bool Disparar = true;

    #endregion

    #endregion

    #region Para que el jugador pueda modificar los valores
    [Header("Textos del jugador")]
    public Text Alpha_T;  //Alpha (el texto)
    public Text Gamma_T;  //Gamma (el texto)
    public Text Vi_T;  //Velocidad inicial (el texto)

    #endregion

    #region Cambios de camara
    [Header("Objeto con script de cambios de camara")]
    public GameObject caldero;

    #endregion

    #region frutas
    [Header("Lista de frutas")]

    public GameObject FrutaEscogida;  //Fruta que sale del array

    #endregion

    #region Principio del juego

    public GameObject disparador;

    #endregion
    void Update()
    {


        if (disparador.GetComponent<ParticleManger>().Started == true)
        {
            Alpha = disparador.GetComponent<ParticleManger>().Alpha;
            Gamma = disparador.GetComponent<ParticleManger>().Gamma;
            vi_user = disparador.GetComponent<ParticleManger>().vi_user;
            /*
             //Comprobar si el jugador ha puesto algún valor en el cuadro de texto

               if (Alpha_T.text != null)
               {
                   Alpha = float.Parse(Alpha_T.text);
               }
               if (Gamma_T.text != null)
               {
                   Gamma = float.Parse(Gamma_T.text);
               }
               if (Vi_T.text != null)
               {
                   vi_user = float.Parse(Vi_T.text);
               }
              */

                //Disparar al pulsar F
            if (Disparar == true)
            {
                    //Crear particulas
                    CreateParticle();
                    Disparar = false;
            }

            for (int i = 0; i < particleArray.Count; i++)
            {

                GameObject particle = particleArray[i];
                Vector newPosition = Simulation(particle.GetComponent<Particle>(), Time.deltaTime);
                if (particle.GetComponent<Particle>().time >= particle.GetComponent<Particle>().life)
                {
                    particleArray.Remove(particle);
                    Destroy(particle);
                    Disparar = true;

                }
                else if (Input.GetKeyDown(KeyCode.F))
                {
                    particleArray.Remove(particle);
                    Destroy(particle);
                    Disparar = false;
                }
                else
                {
                    particle.transform.position = newPosition.ToVector3();
                }
            }

        }
    }

    void CreateParticle()
    {

        for (int i = 0; i == max_particles; i++)
        {
            GameObject newParticle = Instantiate(FrutaEscogida);

            //Asignar valores
            Yb = gameObject.transform.position.y;
            x0 = gameObject.transform.position.x;
            z0 = gameObject.transform.position.z;

            newParticle.transform.position = new Vector3(x0, Yb, z0);
            newParticle.GetComponent<Particle>().vi = vi_user;
            //  newParticle.GetComponent<Particle>().angle = angle_user;   (no hace nada)
            newParticle.GetComponent<Particle>().life = life_user;
            newParticle.GetComponent<Particle>().gravity = gravity_user;
            newParticle.GetComponent<Particle>().time = 0;



            //Añadir a la lista
            particleArray.Add(newParticle);
        }


    }

    private Vector Simulation(Particle particle, float dTime)
    {
        Vector s = new Vector(0, 0, 0);

        particle.time += dTime / 1.5f;

        //Proyeccion del cañon
        b = L * Mathf.Cos((90 - Alpha) * Mathf.PI / 180);

        // Componentes de L
        Lz = b * Mathf.Cos(Gamma * Mathf.PI / 180);
        Ly = L * Mathf.Cos(Alpha * Mathf.PI / 180);
        Lx = b * Mathf.Sin(Gamma * Mathf.PI / 180);

        //Cosenos
        cosLx = Lx / L;
        cosLy = Ly / L;
        cosLz = Lz / L;

        //Componente Z

        vz = vi_user * cosLx;
        s.z = z0 + Lz + particle.vi * (cosLz) * particle.time;

        //Componente Y 

        ay = -particle.gravity;
        vy = vi_user * cosLy - particle.gravity * particle.time;
        s.y = Yb + Ly + (vi_user * cosLy) * particle.time - (particle.gravity * Mathf.Pow(particle.time, 2) / 2);

        //Componente X

        vx = vi_user * cosLx;
        s.x = Lx + particle.vi * cosLx * particle.time;

        return s;
    }
}


