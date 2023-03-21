using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    CargaryGuardar cargaryGuardar;

    [System.Serializable] 
    public class MyEvent : UnityEngine.Events.UnityEvent
    {

    }

    [System.Serializable]
    public class MyIntEvent : UnityEngine.Events.UnityEvent<int>
    {

    }

    [SerializeField]
    MyIntEvent whenCambioVida1, whenCambioVida2;


    [SerializeField]
    GameObject victoria1, victoria2;

    static int vida1 = 3, vida2 = 3;

    Image vic1, vic2;

    public int Vida1
    {

        get { return vida1; }
        set
        {
            vida1 = value;
            whenCambioVida1.Invoke(vida1);
        }
    }


    public int Vida2
    {

        get { return vida2; }
        set
        {
            vida2 = value;
            whenCambioVida2.Invoke(vida2);
        }

    }

    



    // Start is called before the first frame update
    void Start()
    {
        vic1 = victoria1.GetComponent<Image>();
        vic2 = victoria2.GetComponent<Image>();
        //cargaryGuardar.Guardar();
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

    public void QuitarVida1()
    {
        Vida1--;
    }

    public void QuitarVida2()
    {
        Vida2--;
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
}
