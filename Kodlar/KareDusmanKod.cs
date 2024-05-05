using UnityEngine;

public class KareDusmanKod : MonoBehaviour
{
    public float hareketHizi = 5f;
    private Transform ucak;
    private Vector3 hedefYon;
    private bool takipEdiyor = true;

    void Start()
    {
        ucak = GameObject.FindWithTag("Ucak").transform;
        // Uçaðýn konumuna bir kez baktýktan sonra hedef yönü belirleyelim
        hedefYon = (ucak.position - transform.position).normalized;
    }

    void Update()
    {
        if (takipEdiyor)
        {
            // Düþmanýn hedef yönüne doðru hareket etmesi
            transform.position += hedefYon * hareketHizi * Time.deltaTime;

            // Düþmanýn hedef yönüne doðru dönmesi
            float aci = Mathf.Atan2(hedefYon.y, hedefYon.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, aci - 90f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ucak"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SolSinir"))
        {
            Destroy(gameObject);
        }
    }
}
