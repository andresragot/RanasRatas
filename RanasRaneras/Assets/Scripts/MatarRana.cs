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

    BoxCollider2D box;
    Rigidbody2D rb;

    RaycastHit2D raycast, raycastGround;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
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
            }
        }
        else if (DetectarSuelo())
        {
            if (raycastGround.collider.gameObject != this && raycastGround.collider != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    private bool DetectarRana()
    {
        raycast = Physics2D.BoxCast(ranaCheck.position, box.bounds.size, 0, Vector2.down, 1, ranaLayer);
        return raycast;
    }

    private bool DetectarSuelo()
    {
        raycastGround = Physics2D.Raycast(ranaCheck.position, Vector2.down, 0.1f, ground);
        return raycastGround;
    }
}
