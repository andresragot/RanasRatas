using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaccionEmpujonRana : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lengua")
        {
            float force = 100f;
            Vector3 direction = transform.position - collision.transform.position;
            rb.AddForce(direction * force);
        }
    }
}
