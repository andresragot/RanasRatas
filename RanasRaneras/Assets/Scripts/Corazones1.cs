using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Corazones1 : MonoBehaviour
{
    [SerializeField]
    Image[] corazon2;

    [SerializeField]
    GameObject gameOver;

     static int _vida2 = 3;

    CargaryGuardar cargaryGuardar;

    private void Awake()
    {
        cargaryGuardar = GetComponent<CargaryGuardar>();
    }

    public int Vida2
    {
        get { return _vida2; }
        set
        {
            _vida2 = value;
            CambiarCorazon2(_vida2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vida2 <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void CambiarCorazon2(int vida2)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        corazon2[vida2].color = Color.white;
    }

    /*public void SceneC()
    {
        if(Vida >= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }*/
}
