using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Üretim Ayarlarý")]
    public GameObject caprazMeteorPrefab; // Yan gelen meteor prefabý
    public GameObject duzMeteorPrefab;    // Düz gelen meteor prefabý

    public float caprazUretimAraligi = 1.5f; // Çapraz meteorlarýn düþme sýklýðý
    public float duzUretimAraligi = 3.0f;    // Düz meteorlarýn düþme sýklýðý (Daha nadir/belli aralýkla)

    public float yUretimNoktasi = 7f;
    public float xSiniri = 8f;

    // Zamaný takip etmek için arka planda çalýþacak sayaçlar
    private float caprazSayac = 0f;
    private float duzSayac = 0f;

    void Update()
    {
        // Sayaçlarý oyunun zamanýna göre sürekli artýrýyoruz
        caprazSayac += Time.deltaTime;
        duzSayac += Time.deltaTime;

        // Senin eklediðin zorluk mekanizmasý (Süre 5'i geçince hýzlanmasý)
        // NOT: 0.1f saniyede 10 meteor demektir, oyun çok zorlaþýrsa bu deðerleri biraz büyütebilirsin (Örn: 0.5f)
        if (PlayerMovement.x > 5)
        {
            caprazUretimAraligi = 0.5f;
            duzUretimAraligi = 1.0f; // Düz meteorlar da hýzlansýn
        }

        // Çapraz meteor üretme zamaný geldiyse
        if (caprazSayac >= caprazUretimAraligi)
        {
            MeteorUret(caprazMeteorPrefab);
            caprazSayac = 0f; // Yeniden saymasý için sayacý sýfýrla
        }

        // Düz meteor üretme zamaný geldiyse
        if (duzSayac >= duzUretimAraligi)
        {
            MeteorUret(duzMeteorPrefab);
            duzSayac = 0f; // Yeniden saymasý için sayacý sýfýrla
        }
    }

    // Hangi prefabý (düz mü çapraz mý) gönderirsek onu üreten ortak fonksiyon
    void MeteorUret(GameObject uretilecekPrefab)
    {
        float rastgeleX = Random.Range(-xSiniri, xSiniri);
        Vector2 dogumNoktasi = new Vector2(rastgeleX, yUretimNoktasi);

        // Gönderilen prefabý sahnede oluþtur
        Instantiate(uretilecekPrefab, dogumNoktasi, Quaternion.identity);
    }
}