using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoAviso : MonoBehaviour
{

    [SerializeField]
    float tiempoDescuento;

    // Update is called once per frame
    void Update()
    {
        if (tiempoDescuento <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            tiempoDescuento -= Time.deltaTime;
        }
        
    }
}
