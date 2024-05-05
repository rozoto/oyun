using UnityEngine;

public class BeyazDusman : MonoBehaviour
{
    [SerializeField] GameObject _mermiSablonu;
    [SerializeField] GameObject _cikisNoktasi1;
    [SerializeField] GameObject _cikisNoktasi2;
    [SerializeField] float _MermiCikisAraligi = 0.2f;
    [SerializeField] float _yukariAsagiSapmaMiktari = 1f; // Yukarý veya aþaðý sapma miktarý
    [SerializeField] float _yukariAsagiHareketHizi = 2f; // Yukarý veya aþaðý hareket hýzý
    [SerializeField] float _sinirUst = 4.5f; // Yukarý sýnýr
    [SerializeField] float _sinirAlt = -4.5f; // Aþaðý sýnýr

    float mermiGecenSuresi;
    float hedefY;
    bool yukariYon;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10.0f, 0.0f);
        // Baþlangýçta rastgele bir hedef yükseklik belirle
        hedefY = transform.position.y + Random.Range(-_yukariAsagiSapmaMiktari, _yukariAsagiSapmaMiktari);
        // Baþlangýçta rastgele bir yukarý veya aþaðý yön belirle
        yukariYon = Random.value > 0.5f;
    }

    void Update()
    {
        Ates();
        Hareket();
    }

    void Ates()
    {
        if (mermiGecenSuresi >= _MermiCikisAraligi)
        {
            // Ýlk mermiyi oluþtur
            var yeniMermi1 = Instantiate(_mermiSablonu);
            yeniMermi1.transform.position = _cikisNoktasi1.transform.position;
            yeniMermi1.GetComponent<mermiKod>().YonAta(Yon.Sol);
            yeniMermi1.tag = "BeyazDusmanMermi";

            // Ýkinci mermiyi oluþtur
            var yeniMermi2 = Instantiate(_mermiSablonu);
            yeniMermi2.transform.position = _cikisNoktasi2.transform.position;
            yeniMermi2.GetComponent<mermiKod>().YonAta(Yon.Sol);
            yeniMermi2.tag = "BeyazDusmanMermi";

            mermiGecenSuresi = 0.0f;
        }
        else {mermiGecenSuresi += Time.deltaTime; }
            
    }

    void Hareket()
    {
        // Yukarý veya aþaðýya doðru hareket et
        if (yukariYon)
        {
            transform.Translate(Vector3.up * _yukariAsagiHareketHizi * Time.deltaTime);
            if (transform.position.y >= _sinirUst)
                yukariYon = false; // Yukarý sýnýra ulaþtýysa aþaðý yöne dön
        }
        else
        {
            transform.Translate(Vector3.down * _yukariAsagiHareketHizi * Time.deltaTime);
            if (transform.position.y <= _sinirAlt)
                yukariYon = true; // Aþaðý sýnýra ulaþtýysa yukarý yöne dön
        }

        // Yatayda düzgün bir þekilde hareket et
        Vector3 hareket = new Vector3(-10.0f * Time.deltaTime, 0f, 0f);
        transform.Translate(hareket);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ucak"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("SolSinir"))
        {
            Destroy(gameObject);
        }
    }
}
