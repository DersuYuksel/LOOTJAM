using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hareket Ayarlar�")]
    public float moveSpeed = 5f; // Karakterin h�z�

    private Rigidbody2D rb;
    private float moveInput;

    private Animator animator;

    public static float x = 0;

    void Start()
    {
        // Karakterdeki Rigidbody2D bile�enini kodumuza �ekiyoruz
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Klavyeden sa�/sol (A-D veya Ok tu�lar�) girdisini al�yoruz.
        // GetAxisRaw kullanmak, karakterin kaymadan an�nda durmas�n� sa�lar (Platformer oyunlar� i�in idealdir).
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Karakterin bakt��� y�n� de�i�tirmek i�in (Flipping)
        YonuCevir();

        if (moveInput != 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        x += Time.deltaTime;

        if(x > 10f)
        {
            Time.timeScale = 1.2f;
        }
    }    


    private void YonuCevir()
    {
        // E�er sa�a bas�l�yorsa (1) karakter normal dursun
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // E�er sola bas�l�yorsa (-1) karakteri X ekseninde ters �evir
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}