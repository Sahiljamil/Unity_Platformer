using UnityEngine;

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
        ResetToStartingPostion();
    }

    private void Update()
    {
        FixPlayerRoatation();
        movement();
        //anim.SetBool("isGrounded", isGrounded);
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
        }

        if (Input.GetKey(KeyCode.Space) ^ Input.GetKey(KeyCode.UpArrow) ^ Input.GetKey(KeyCode.W) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
            isGrounded = false;
        }

        if (Input.GetKey("k"))
        {
            gameObject.GetComponent<Health>().TakeDamage(20);
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

    public void ResetToStartingPostion()
    {
        gameObject.transform.position = new Vector3(0, 1, 0);
    }

    public void FixPlayerRoatation()
    {
        float rotation = 0;

        transform.localRotation = Quaternion.Euler(rotation, rotation, rotation);
    }
}
