using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesEscenario : MonoBehaviour
{
    Rigidbody2D rb;
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
        if (collision.gameObject.tag == "Rana")
        {
            Corazones cora = rb.GetComponent<Corazones>();
            cora.Vida--;
            Destroy(gameObject);
        }
    }
}
