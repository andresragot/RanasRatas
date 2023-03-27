using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Corazones : MonoBehaviour
{
     int _vida = 3;

    [System.Serializable]
    public class MyIntEvent : UnityEngine.Events.UnityEvent<int>
    {

    }


    [SerializeField]
    public MyIntEvent whenCambioVida, WhenPegado;

    public int Vida
    {
        get { return _vida; }
        set
        {
            _vida = value;
            //WhenPegado.Invoke();
            whenCambioVida.Invoke(_vida);
        }
    }

    public void setVida(int a)
    {
        _vida = a;
    }


    public void InvocarEvento()
    {
        WhenPegado.Invoke(_vida);
    }
}
