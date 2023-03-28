using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarRana : MonoBehaviour
{
    [SerializeField]
    Transform ranaCheck;
    [SerializeField]
    LayerMask ranaLayer;
    [SerializeField]
    LayerMask ground;

    Animator anim;
    BoxCollider2D box;
    Rigidbody2D rb;

    MoviminetoRanaXInput r1;

    RaycastHit2D raycast, raycastGround;

    [SerializeField] float timer = 15f;
    float timerInicial;

    RigidbodyConstraints2D originalConstraints;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        timerInicial = timer;
        originalConstraints = rb.constraints;
    }

    // Update is called once per frame
    void Update()
    {

        if (DetectarRana())
        {
            if(raycast.collider!=null && raycast.collider.tag == "Rana")
            {
                if(rb.constraints == RigidbodyConstraints2D.FreezeAll)
                {
                    return;
                }
                Corazones cora = raycast.collider.GetComponent<Corazones>();
                cora.Vida--;
                Destroy(gameObject);

            }
        }

        

        else if (DetectarSuelo())
        {
            if (raycastGround.collider.gameObject != this && raycastGround.collider != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                timer-=Time.deltaTime;
            }
            //rb.constraints = originalConstraints;
        }
        borrarPlataforma();
    }

    private bool DetectarRana()
    {
        raycast = Physics2D.BoxCast(ranaCheck.position, box.bounds.size, 0, Vector2.down, 1, ranaLayer);
        return raycast;
    }

    private bool DetectarRana2()
    {
        raycast = Physics2D.BoxCast(ranaCheck.position, box.bounds.size, 0, Vector2.down, 1, ranaLayer);
        return raycast;
    }

    private bool DetectarSuelo()
    {
        raycastGround = Physics2D.Raycast(ranaCheck.position, Vector2.down, 0.1f, ground);
        return raycastGround;
    }

    private void borrarPlataforma()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = timerInicial;
        }
    }
}
