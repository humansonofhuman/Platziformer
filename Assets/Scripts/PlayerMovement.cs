using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody2D playerRb;
    public float speed = 0.5f;
    public float jumpSpeed = 400f;
    public bool isGrounded = true;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(horizontalAxis * speed
                                       , playerRb.velocity.y);

        playerAnim.SetBool("isWalking", horizontalAxis != 0);
        if (horizontalAxis != 0)
        {
            spriteRenderer.flipX = horizontalAxis < 0;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerRb.AddForce(Vector2.up * jumpSpeed);
            isGrounded = false;
            playerAnim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
