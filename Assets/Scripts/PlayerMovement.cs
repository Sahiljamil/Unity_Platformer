using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;
    public bool isGrounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) ^ Input.GetKey(KeyCode.W) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            isGrounded = false;
        }

        anim.SetBool("running", horizontalInput != 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }


}
