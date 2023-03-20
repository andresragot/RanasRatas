using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Corazones : MonoBehaviour
{
    [SerializeField]
    Image[] corazon;

    [SerializeField]
    GameObject gameOver;

     static int _vida = 3;
     static int _vida2 = 3;

    CargaryGuardar cargaryGuardar;

    private void Awake()
    {
        cargaryGuardar = GetComponent<CargaryGuardar>();
    }


    public int Vida
    {
        get { return _vida; }
        set
        {
            _vida = value;
            CambiarCorazon(_vida);
        }
    }

    public int Vida2
    {
        get { return _vida2; }
        set
        {
            _vida = value;
            CambiarCorazon(_vida);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vida <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            cargaryGuardar.Guardar();
        }

        if (Vida2 <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            cargaryGuardar.Guardar();
        }
    }

    public void CambiarCorazon(int vida)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        corazon[vida].color = Color.black;    
    }
    public void CambiarCorazon2(int vida2)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        corazon[vida2].color = Color.black;
    }

    /*public void SceneC()
    {
        if(Vida >= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }*/
}
