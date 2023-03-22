using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoviminetoRanaXInput : MonoBehaviour
{
    [Header("Movimento De Rana")]
    public Transform groundcheck;
    public LayerMask groundlayer, ranaLayer;
    Rigidbody2D rb;
    public float speed = 3;
    public float horizontal;
    [SerializeField] private float jumpingpower = 8f;
    private bool facingright = true;
    private BoxCollider2D boxCollider;

    private Animator anim;
    AnimatorClipInfo[] animatorinfo;
    EmpujonRana empj;
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        empj = GetComponentInChildren<EmpujonRana>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        animatorinfo = anim.GetCurrentAnimatorClipInfo(0);
        string current_animation = animatorinfo[0].clip.name;
        if (current_animation == "Rana1Caminar" || current_animation=="Rana2Caminar")
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        if (current_animation != "Rana1Caminar" || current_animation != "Rana2Pegar")
        {
            //rb.isKinematic = true;
        }

        if(horizontal > 0f)
        {
            //rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);

        }
        else if (horizontal < 0f)
        {
            //rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1); ;
        }

        if (horizontal == 0)
        {
            anim.SetBool("Caminar", false);
        }

        RaycastHit2D raycastHit = Physics2D.BoxCast(groundcheck.position, boxCollider.bounds.size, 0, Vector2.down, 0.1f, ranaLayer);
        if (raycastHit.collider!=null /*&& raycastHit.collider.gameObject != this.gameObject*/ && raycastHit.collider.tag == "Rana")
        {
            if (raycastHit.collider.gameObject == gameObject)
            {
                return;
            }
            else
            {
                rb.AddForce(new Vector2(rb.velocity.x, 2), ForceMode2D.Impulse);
            }
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
        anim.SetBool("Caminar", true);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && Isgrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpingpower), ForceMode2D.Impulse);
            //rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        /*if(context.canceled && rb.velocity.y > 0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            anim.SetTrigger("Fire");

            //rb.isKinematic = false;
        }
    }

    public void ActivarLengua()
    {
        empj.Activar();
    }

}
