using UnityEngine;

public class MeteorDestroy : MonoBehaviour
{
    public float yokOlmaSiniriY = -10f;

    void Update()
    {
        // Eðer meteorun Y pozisyonu belirlediðimiz sýnýrýn altýndaysa
        if (transform.position.y < yokOlmaSiniriY)
        {
            Destroy(gameObject); // Kendisini yok et
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

}
