using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 0f;
    public float jumpForce = 650f;

    public bool isGrounded = true;
    private Rigidbody2D rb;
    private Animator anim;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public string isGroundedBool = "eChao";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }
    private void MovePlayer()
    {
        transform.Translate(new Vector3(speed, 0, 0));
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed, 0, 0));

        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.2f, groundLayer))
        {
            anim.SetBool(isGroundedBool, true);
            isGrounded = true;
        }
        else
        {
            anim.SetBool(isGroundedBool, false);
            isGrounded = false;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
