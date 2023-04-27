using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        GameManager.Vida1 = 3;
        GameManager.Vida2 = 3;
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void CerrarApp()
    {
        Application.Quit();
    }
}
