using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Vector2 startPosition;
    
    public float runSpeed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public bool isDeat = false; //死亡判定



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        //常に右に進む
        rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
    }

    void Update()
    {
        //ジャンプ（Space for 左クリック）
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        print(isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.collider.CompareTag("Obstacle"))
        {
            Dedrestart();
        }
        else if (collision.collider.CompareTag("DedArea"))
        {
            Dedrestart();
        }
        else if (collision.collider.CompareTag("Gool"))
        {
            SceneManager.LoadScene("Clear");
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void Dedrestart()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
    }
}
