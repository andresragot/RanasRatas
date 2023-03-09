using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRana : MonoBehaviour
{
    private float horizontal;

    [SerializeField]
    float speed, jump;

    [SerializeField]
    LayerMask groundLayer;

    /*[SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform firePoint;*/

    BoxCollider2D boxCollider;

    float WallJumpCooldown = 0;

    float horizontalSpeed;

    Rigidbody2D rb2d;

    //private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");

        if (WallJumpCooldown > 0.2f)
        {
            Mover();

            /*if (onWall() && !isGrounded())
            {
                rb2d.gravityScale = 0;
                rb2d.velocity = Vector2.zero;
            }
            else
            {
                rb2d.gravityScale = 1;
            }*/
            if (Input.GetAxis("Jump") > 0.9)
                Saltar();
        }
        else
        {
            WallJumpCooldown += Time.deltaTime;
        }

        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Jump", false);
        }*/
    }

    private void FixedUpdate()
    {
        //rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }

    private void Mover()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.velocity = new Vector2(1 * speed, rb2d.velocity.y);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-1 * speed, rb2d.velocity.y);
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
        }
        //horizontalSpeed = Input.GetAxis("Horizontal");
        /*if (horizontalSpeed < 0)
        {
            //animator.SetBool("Run", true);
            
        }
        else if (horizontalSpeed > 0)
        {
            //animator.SetBool("Run", true);
            

        }*/

    }

    private void Saltar()
    {
        if (isGrounded())
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jump), ForceMode2D.Impulse);
            //animator.SetBool("Jump", true);

        }
        /*else if (/*onWall() && !isGrounded())
        {

            if (horizontalSpeed == 0)
            {
                rb2d.velocity = new Vector2(-Mathf.Sign(transform.right.x) * forceWall * 2, 0);

            }
            else
            {
                Debug.Log(-Mathf.Sign(transform.right.x));
                rb2d.velocity = new Vector2(-Mathf.Sign(transform.right.x) * forceWall, forceWallUp);
            }
            WallJumpCooldown = 0;
        }
        else
        {
            //animator.SetBool("Jump", false);
        }*/
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    /*private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    /*private void shoot()
    {
        GameObject BulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoxC")
        {
            animator.SetTrigger("Celeb");
        }
    }*/
}