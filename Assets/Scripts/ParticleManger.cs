using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleManger : MonoBehaviour
{

    #region Para que dispare

    #region parametros de entrada (jugador)
    [Header ("Parametros de entrada del jugador")]

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
    public float life_user;      //vida de la particula (en tiempo)
                                 //  public float angle_user;     (no hace nada)
    #endregion

    #region variables finales
    [Header("Variables para el resultado final")]
    public float ax=0;    //aceleracion en x
    public float vx;      //velocidad en x

    public float ay;      //aceleracion en y
    public float vy;      //velocidad en y

    public float az=0;    //aceleracion en z
    public float vz;      //velocidad en z
    #endregion

    #region otras variables
    [Header("Otras variables")]

    List<GameObject> particleArray = new List<GameObject>();     //Lista almacenar las partículas
    public int max_particles;  //maximo variables (1)
    public GameObject prefab_particle;  //prefab de la bala
    bool Disparar = true;

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

    public List<GameObject> FruitArray = new List<GameObject>();  //Lista de los distintos tipos de fruta
    public GameObject FrutaEscogida;  //Fruta que sale del array

    #endregion

    #region Principio del juego

    public bool Started = false;
    public Canvas StartCan;
    public Canvas Score;
    public Canvas Variables;
    public Canvas Stop;

    public GameObject disparador;

    public Slider Ang1;
    public Slider Ang2;
    public Slider V1;

    public AudioSource button;



    #endregion
    void Start()
    {
        caldero.GetComponent<CameraChange>().StartMenu();  // camara rotatoria alrededor del caldero
        Started = false;
        Score.enabled = false;
        Variables.enabled = false;
        Stop.enabled = false;
    }
    public void StartGame()
    {
        caldero.GetComponent<CameraChange>().ShootingDirection(); //camara cambia a camara del caldero
        Started = true;
        StartCan.enabled = false;
        Score.enabled = true;
        Variables.enabled = true;
    }

    void Update()
    {
        if (Started == true)
        {

            //Disparar al pulsar F
            if (Disparar == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //Camara a la fruta
                    caldero.GetComponent<CameraChange>().FruitCam();
                    //Crear particulas
                    CreateParticle();
                    Disparar = false;
                    Ang1.interactable = false;
                    Ang2.interactable = false;
                    V1.interactable = false;
                    Variables.enabled = false;
                    Score.enabled = false;
                    caldero.SetActive(false);
                }
            }

            for (int i = 0; i < particleArray.Count; i++)
            {

                GameObject particle = particleArray[i];
                Vector newPosition = Simulation(particle.GetComponent<Particle>(), Time.deltaTime);
                if (particle.GetComponent<Particle>().desaparece == true)
                {
                    particleArray.Remove(particle);
                    Destroy(particle);
                    Disparar = true;
                    caldero.GetComponent<CameraChange>().ShootingDirection();      //cambiar camara a caldero
                    FrutaEscogida = null;
                    disparador.GetComponent<referencia>().Disparar = true;
                    Ang1.interactable = true;
                    Ang2.interactable = true;
                    V1.interactable = true;
                    Score.enabled = true;
                    Variables.enabled = true;
                    caldero.SetActive(true);

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

        for (int i = 0; i < max_particles; i++)
        {
            //Escogemos una fruta al azar de la lista
            FrutaEscogida = FruitArray[Random.Range(0, 5)];
            //1 copia de la fruta
            GameObject newParticle = Instantiate(FrutaEscogida);

            //Asignar valores
            Yb = gameObject.transform.position.y;
            x0 = gameObject.transform.position.x;
            z0 = gameObject.transform.position.z;

            newParticle.transform.position = new Vector3 (x0, Yb, z0);
            newParticle.GetComponent<Particle>().vi = vi_user;
            newParticle.GetComponent<Particle>().angle = Gamma;
            newParticle.GetComponent<Particle>().life = life_user;
            newParticle.GetComponent<Particle>().gravity = gravity_user;
            newParticle.GetComponent<Particle>().time = 0;



            //Añadir a la lista
            particleArray.Add(newParticle);
        }


    }

    private Vector Simulation(Particle particle, float dTime)
    {
        Vector s = new Vector(0,0,0);

        particle.time += dTime / 3;

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
    public void AjustarAlpha(float nuevoAlpha)
    {
        Alpha = nuevoAlpha;
    }
    public void AjustarGamma(float nuevoGamma)
    {
        Gamma = nuevoGamma;
    }
    public void AjustarVi(float nuevoVi)
    {
        vi_user = nuevoVi;
    }
    public void PressPlay()
    {
        button.Play();
    }
    public void Restart()
    {

        caldero.GetComponent<Puntuación>().puntosManz = 0;
        caldero.GetComponent<Puntuación>().puntosPera = 0;
        caldero.GetComponent<Puntuación>().puntosCere = 0;
        caldero.GetComponent<Puntuación>().puntosPlat = 0;
        caldero.GetComponent<Puntuación>().puntosNara = 0;

        Alpha = 50;
        Gamma = 180;
        vi_user = 15f;

        caldero.GetComponent<CameraChange>().StartMenu();  // camara rotatoria alrededor del caldero
        caldero.GetComponent<Puntuación>().Updatear();

        Started = false;
        Score.enabled = false;
        Variables.enabled = false;
        Stop.enabled = false;
        StartCan.enabled = true;
    }
}
