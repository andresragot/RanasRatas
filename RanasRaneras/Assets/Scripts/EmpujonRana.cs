using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EmpujonRana : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activar()
    {
        anim.SetTrigger("Pegar");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject!= transform.parent)
        {
            anim.SetTrigger("Regresar");
        }
    }

}
