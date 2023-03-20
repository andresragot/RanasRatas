using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public int corazonesActuales = 0;
    public int corazones = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesbloquearCorazon()
    {
        corazones = corazonesActuales;

    }
}
