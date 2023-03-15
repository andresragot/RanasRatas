using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaPlataformas : MonoBehaviour
{
    [SerializeField] GameObject prefabPlataforma;
    [SerializeField] float limiteInferior = -8.82f, limiteSuperior = 8.8f;
    [SerializeField] float posicionY=8;
    [SerializeField] float valorActualTimer;
    [SerializeField] float timer = 2f;
    float valorInicialTimer2;
    float timer2 = 3f;

    // Start is called before the first frame update
    void Start()
    {
        valorActualTimer = timer;
        valorInicialTimer2 = timer2;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            if(valorActualTimer > 0.5) 
            { 
                valorActualTimer -= 0.5f;
                timer2 = valorInicialTimer2;
            }
            else 
            { 
                valorActualTimer = 0.5f; 
                timer2 = valorInicialTimer2; 
            }
        }
        if (timer <= 0)
        {
            CrearPlataforma();
            timer = valorActualTimer;
        }
    }
    void CrearPlataforma()
    {
        GameObject clon = Instantiate(prefabPlataforma);
        float x = (int)Random.Range(limiteInferior, limiteSuperior);
        clon.transform.position = new Vector3(x, posicionY, 0);
    }
   
}
