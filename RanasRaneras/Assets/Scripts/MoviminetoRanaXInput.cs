using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoviminetoRanaXInput : MonoBehaviour
{
    Corazones r1;
    public int counter = 3;

    GameManager c1;
    GameManager c2;

    [Header("Movimento De Rana")]
    public Transform groundcheck;
    public LayerMask groundlayer, ranaLayer;
    Rigidbody2D rb;
    public float speed = 3;
    public float horizontal;
    [SerializeField] private float jumpingpower = 8f;
    private bool facingright = true;
    private BoxCollider2D boxCollider;

    public Animator anim;
    AnimatorClipInfo[] animatorinfo;
    EmpujonRana empj;

    float SpeedF;
    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        empj = GetComponentInChildren<EmpujonRana>();
        rb = GetComponent<Rigidbody2D>();
        SpeedF = speed;

        //life.CambiarVida1(d);
    }
    // Update is called once per frame
    void Update()
    {
        animatorinfo = anim.GetCurrentAnimatorClipInfo(0);
        string current_animation = animatorinfo[0].clip.name;
        if (current_animation == "Rana1Caminar" || current_animation=="Rana2Caminar"|| current_animation == "Rana1Jump2" || current_animation == "Rana2Jump2")
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); 
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

        //RaycastHit2D raycastHit = Physics2D.BoxCast(groundcheck.position, boxCollider.bounds.size, 0, Vector2.down, 0.1f, ranaLayer);
        RaycastHit2D raycastHit = Physics2D.Raycast(groundcheck.position, Vector2.down, 0.1f, ranaLayer);
        if (raycastHit.collider!=null /*&& raycastHit.collider.gameObject != this.gameObject*/ && raycastHit.collider.tag == "Rana" && raycastHit.collider.GetComponent<MoviminetoRanaXInput>().Isgrounded())
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

        if (Isgrounded())
        {
            if(current_animation=="Rana1Jump2" || current_animation == "Rana2Jump2")
            {
                anim.SetBool("Suelo", true);
            }
            else
            {
                anim.SetBool("Suelo", false);
            }
        }

     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rana")
        {
            rb.gravityScale = 10;
            /*Vector2 direction = transform.position - collision.transform.position;
            direction.Normalize();
            rb.AddForce(direction * 2);*/
            speed = 0;
        }
        else if (collision.gameObject.tag == "Pared")
        {
            rb.gravityScale = 10;
            speed = 0;
        }

        /*if(collision.gameObject.tag == "Plataforma")
        {
            anim.SetTrigger("Loss");
            anim.Play("LifeLo");

            anim.Play("LifeLo2");
        }*/

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rana")
        {
            rb.gravityScale = 4.5f;
            speed = SpeedF;
            /*Vector2 direction = transform.position - collision.transform.position;
            direction.Normalize();
            rb.AddForce(direction * 2);*/
        }
        else if (collision.gameObject.tag == "Pared")
        {
            rb.gravityScale = 4.5f;
            speed = SpeedF;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Isgrounded())
        {
            if (collision.gameObject.tag == "Rana")
            {
                rb.gravityScale = 4.5f;
                speed = SpeedF;
                /*Vector2 direction = transform.position - collision.transform.position;
                direction.Normalize();
                rb.AddForce(direction * 2);*/
            }
            else if (collision.gameObject.tag == "Pared")
            {
                rb.gravityScale = 4.5f;
                speed = SpeedF;
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

    public bool Isgrounded()
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

            //rb.AddForce(new Vector2(rb.velocity.x, jumpingpower), ForceMode2D.Impulse);
            anim.SetTrigger("Saltar");
            //rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        /*if(context.canceled && rb.velocity.y > 0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }*/
    }

    public void AnimacionSaltar()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpingpower), ForceMode2D.Impulse);
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

    public IEnumerator AnimacionMuerte()
    {

        //anim.SetBool("Pegado", true);

        anim.SetTrigger("PegadoT");

        yield return new WaitForSeconds(1);

        Corazones cora = GetComponent<Corazones>();
        cora.WhenPegado.Invoke(cora.Vida);
    }

    public void LlamarNumerator()
    {
        StartCoroutine(AnimacionMuerte());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("Se hace");
            GameManager.Singleton.ResetEscena();
            
        }
 
    }

}
