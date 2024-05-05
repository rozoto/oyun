using UnityEngine;

public class BeyazDusman : MonoBehaviour
{
    [SerializeField] GameObject _mermiSablonu;
    [SerializeField] GameObject _cikisNoktasi1;
    [SerializeField] GameObject _cikisNoktasi2;
    [SerializeField] float _MermiCikisAraligi = 0.2f;
    [SerializeField] float _yukariAsagiSapmaMiktari = 1f; // Yukar� veya a�a�� sapma miktar�
    [SerializeField] float _yukariAsagiHareketHizi = 2f; // Yukar� veya a�a�� hareket h�z�
    [SerializeField] float _sinirUst = 4.5f; // Yukar� s�n�r
    [SerializeField] float _sinirAlt = -4.5f; // A�a�� s�n�r

    float mermiGecenSuresi;
    float hedefY;
    bool yukariYon;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10.0f, 0.0f);
        // Ba�lang��ta rastgele bir hedef y�kseklik belirle
        hedefY = transform.position.y + Random.Range(-_yukariAsagiSapmaMiktari, _yukariAsagiSapmaMiktari);
        // Ba�lang��ta rastgele bir yukar� veya a�a�� y�n belirle
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
            // �lk mermiyi olu�tur
            var yeniMermi1 = Instantiate(_mermiSablonu);
            yeniMermi1.transform.position = _cikisNoktasi1.transform.position;
            yeniMermi1.GetComponent<mermiKod>().YonAta(Yon.Sol);
            yeniMermi1.tag = "BeyazDusmanMermi";

            // �kinci mermiyi olu�tur
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
        // Yukar� veya a�a��ya do�ru hareket et
        if (yukariYon)
        {
            transform.Translate(Vector3.up * _yukariAsagiHareketHizi * Time.deltaTime);
            if (transform.position.y >= _sinirUst)
                yukariYon = false; // Yukar� s�n�ra ula�t�ysa a�a�� y�ne d�n
        }
        else
        {
            transform.Translate(Vector3.down * _yukariAsagiHareketHizi * Time.deltaTime);
            if (transform.position.y <= _sinirAlt)
                yukariYon = true; // A�a�� s�n�ra ula�t�ysa yukar� y�ne d�n
        }

        // Yatayda d�zg�n bir �ekilde hareket et
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
