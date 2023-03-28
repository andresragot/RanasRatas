using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int c1 = 3;
    public int c2 = 3;

    Gradient gradient;
    GradientColorKey[] colorkey;

    public int counter = 3;
    public int counter2 = 3;

    private Animator anim;

    //CargaryGuardar cargaryGuardar;
    [System.Serializable] 
    public class MyEvent : UnityEngine.Events.UnityEvent
    {

    }

    [System.Serializable]
    public class MyIntEvent : UnityEngine.Events.UnityEvent<int>
    {

    }

    [SerializeField]
    GameObject victoria1, victoria2;

    [SerializeField]
    Image corazon11, corazon21, corazon31, corazon12, corazon22, corazon32;

    [SerializeField]
    GameObject Rana1, Rana2;

    static int vida1 = 3, vida2 = 3;

    Image vic1, vic2;
    public static int Vida1
    {

        get { return vida1; }
        set
        {
            vida1 = value;
        }
    }


    public static int Vida2
    {

        get { return vida2; }
        set
        {
            vida2 = value;
        }

    }


    private static GameManager _instance;
    public static GameManager Singleton { get { return _instance; } }

    private void Awake()
    {
        Time.timeScale = 1;
        if(_instance!=null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        CambiarVida1(Vida1);
        CambiarVida2(Vida2);
        Rana1.GetComponent<Corazones>().setVida(Vida1);
        Rana2.GetComponent<Corazones>().setVida(Vida2);

    }



    // Start is called before the first frame update
    void Start()
    {
        vic1 = victoria1.GetComponent<Image>();
        vic2 = victoria2.GetComponent<Image>();
        //cargaryGuardar.Guardar();

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (vida1 <= 0)
        {
            victoria2.SetActive(true);
            victoria2.GetComponent<Animator>().SetBool("Activado", true);
        }
        else if (vida2 <= 0)
        {
            victoria1.SetActive(true);
            victoria1.GetComponent<Animator>().SetBool("Activado", true);
        }

        if (vic1.color.a==1 || vic2.color.a==1)
        {
            Time.timeScale = 0;
        }


    }

    public void QuitarVida1(int a)
    {
        Vida1 = a;
        SceneManager.LoadScene(1);
    }

    public void QuitarVida2(int a)
    {
        Vida2 = a;
        SceneManager.LoadScene(1);

    }

    public void ResetEscena()
    {
        SceneManager.LoadScene(1);
    }

    public void Regresar()
    {
        Time.timeScale = 1;
    }

    public void Pausa(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Ambas funciones las llamamos en el editor a traves de los eventos de when cambia de vida
    /// </summary>
    /// <param name="a"></param>
    public void CambiarVida1(int a)
    {
        if (a == 0)
        {
            c1 = 2;

            corazon11.color = Color.clear;
            corazon21.color = Color.clear;
            corazon31.color = Color.clear;
            
}
        else if (a == 1)
        {
            c1 = 1;
            corazon21.color = Color.clear;
            corazon31.color = Color.clear;
            
        }
        else if (a == 2)
        {
            c1 = 0;
            corazon31.color = Color.clear;
            
        }
    }

    public void CambiarVida2(int a)
    {
        if (a == 0)
        {

            corazon12.color = Color.clear;
            corazon22.color = Color.clear;
            corazon32.color = Color.clear;

        }
        else if (a == 1)
        {
            corazon22.color = Color.clear;
            corazon32.color = Color.clear;
           
        }
        else if (a == 2)
        {
            corazon32.color = Color.clear;
           
        }
    }


}
