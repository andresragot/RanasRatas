using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoviminetoRanaXInput : MonoBehaviour
{
    [Header("Movimento De Rana")]
    public Transform groundcheck;
    public LayerMask groundlayer;
    public Rigidbody2D rb;
    public float speed = 3;
    public float horizontal;
    private float jumpingpower = 16f;
    private bool facingright = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if(!facingright && horizontal > 0f)
        {
            flip();
        }
        else if (!facingright && horizontal < 0f)
        {
            flip();
        }
    }

    private void FixedUpdate()
    {

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private bool Isgrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
    }

    private void flip()
    {
        facingright = !facingright;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && Isgrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        if(context.canceled && rb.velocity.y > 0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


}
