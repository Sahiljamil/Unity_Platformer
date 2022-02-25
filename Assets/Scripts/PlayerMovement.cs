using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ResetToStartingPostion();

    }

    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
        }

        if (Input.GetKey(KeyCode.Space) ^ Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }

        if (Input.GetKey("k"))
        {
            gameObject.GetComponent<Health>().TakeDamage(20);
        }

        anim.SetBool("running", horizontalInput != 0);
    }

    public void ResetToStartingPostion()
    {
        gameObject.transform.position = new Vector3(0, 1, 0);
    }
    

   
}
