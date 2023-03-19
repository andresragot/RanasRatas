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

    int _vida = 3;

    public int Vida
    {
        get { return _vida; }
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
        }
    }

    public void CambiarCorazon(int vida)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        corazon[vida].color = Color.black;
        
    }

    /*public void SceneC()
    {
        if(Vida >= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }*/
}
