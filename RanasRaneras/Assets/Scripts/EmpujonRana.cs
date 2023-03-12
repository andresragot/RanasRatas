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

    public void Empujar (InputAction.CallbackContext context)
    {
        anim.SetTrigger("Pegar");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Regresar");
    }

}
