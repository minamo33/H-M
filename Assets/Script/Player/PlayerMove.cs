using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //初期設定
    private Vector2 startPosition;
    
    //移動パラメータ
    public float runSpeed;

    public float jumpPower;
    private bool jumpReqest;
    
    public float gravity;
    private float verticalVelocity;

    //物理演算
    private Rigidbody2D rb;

    //トリガー
    private bool isGrounded;
    public bool isDeat = false; //死亡判定



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (jumpReqest)
        {
            verticalVelocity = jumpPower;
            jumpReqest = false;
        }

        //重力処理
        verticalVelocity += gravity * Time.deltaTime;

        //y方向の移動
        transform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);

        print(verticalVelocity);
    }

    void Update()
    {
        //常に右に進む
        transform.Translate(Vector2.right * runSpeed * Time.deltaTime);

        //ジャンプ（Spaceキー）
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            jumpReqest = true;
        }
        print(isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.name);
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            verticalVelocity = 0f;//着地時に落下速度をリセット
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
        verticalVelocity = 0f;//着地時に落下速度をリセット
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
    }
}
