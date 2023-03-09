using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corazones : MonoBehaviour
{
    [SerializeField]
    Image[] corazon;

    [SerializeField]
    Sprite[] corazones;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarCorazon(int vida)
    {
        /*for(int i = 3-vida; i < vida; i++)
        {
            corazon[i].sprite = corazones[1];
        }*/

        corazon[vida].sprite = corazones[1];
    }
}
