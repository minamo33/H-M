using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //初期設定
    private Vector2 startPosition;
    
    //移動パラメータ
    public float runSpeed;

    public float jumpPower;
    //private bool jumpRequest;
    
    //物理演算
    private Rigidbody2D rb;

    //トリガー
    private bool isGrounded;
    //private bool isDeat = false; //死亡判定



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }


    void Update()
    {
        //常に右に進む
        transform.Translate(Vector2.right * runSpeed * Time.deltaTime);

        //ジャンプ（Spaceキー）
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            // 上に力を加える
            rb.AddForce(Vector2.up * jumpPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //デバッグログ
        //print(collision.collider.name);

        if (collision.collider.CompareTag("Obstacle"))  { Dedrestart();}
        if (collision.collider.CompareTag("DedArea"))   { Dedrestart();}
        if (collision.collider.CompareTag("Gool"))      { SceneManager.LoadScene("Clear"); }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")){ isGrounded = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")){ isGrounded = false;}
    }

    private void Dedrestart()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
    }
}
