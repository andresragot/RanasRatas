using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaccionEmpujonRana : MonoBehaviour
{
    [SerializeField] float magnitude = 1000f;

    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lengua")
        {
            Vector2 direction = transform.position - collision.transform.position;
            direction.Normalize();
            rb.AddForce(direction * magnitude);
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Lengua")
    //    {
    //        Vector2 direction = transform.position - collision.transform.position;
    //        direction.Normalize();
    //        rb.AddForce(direction * magnitude);
    //    }
    //}

}
