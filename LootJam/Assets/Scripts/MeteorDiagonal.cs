using UnityEngine;

public class MeteorDiagonal : MonoBehaviour
{
    [Header("Çapraz Hareket Ayarları")]
    public float maxHorizontalSpeed = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer Sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponent<SpriteRenderer>();

        float speedX = 0f;

        // Karar Yapısı: Meteor nerede doğdu?

        if (transform.position.x > 0)
        {
            // Eğer X pozisyonu 0'dan büyükse (Ekranın SAĞ yarısında doğduysa)
            // Sadece sola doğru (eksi değerlerde) rastgele bir hız ver
            speedX = Random.Range(-maxHorizontalSpeed, 0f);
        }
        else
        {
            // Eğer X pozisyonu 0 veya daha küçükse (Ekranın SOL yarısında doğduysa)
            // Sadece sağa doğru (artı değerlerde) rastgele bir hız ver
            speedX = Random.Range(0f, maxHorizontalSpeed);
            Sprite.flipX = true;
        }

        // Hesaplanmış hızı X eksenine uygula, Y eksenindeki düşüşe (yerçekimine) dokunma
        rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y);
    }
}