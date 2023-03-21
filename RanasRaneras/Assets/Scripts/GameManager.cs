using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{

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

    static int vida1 = 3, vida2 = 3;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
