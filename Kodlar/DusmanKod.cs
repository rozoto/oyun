using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKod : MonoBehaviour
{
    int yasam = 5;
    [SerializeField] GameObject mermiSablon;
    [SerializeField] float _mermiFirlatmaAraligi = 0.4f;
    float _mermiGecenSure = 0.0f;
    OyunYoneticiKod _oyunYoneticiKod;
 
    void Awake()
    {
        _oyunYoneticiKod = GameObject.Find("OyunYonetici").GetComponent<OyunYoneticiKod>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10.0f, 0.0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SolSinir"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ucak"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("UcakMermi"))
        {
            Destroy(collision.gameObject);
            _oyunYoneticiKod.PuanArttir(Puanlar.DusmanVuruldu);

            if (Vuruldu() == 0)
            {
                _oyunYoneticiKod.PuanArttir(Puanlar.DusmanYokEdildi);
            }
        }
    }
    public int Vuruldu()
    {
        yasam--;
        if (yasam == 0)
        {
            Destroy(gameObject);
        }
        return yasam;
    }
    // Update is called once per frame
    void Update()
    {
        MermiFirlat();
    }
    void MermiFirlat()
    {
        if (_mermiGecenSure >= _mermiFirlatmaAraligi)
        {
            var yeniMermi = Instantiate(mermiSablon);
            yeniMermi.transform.position = transform.position;
            yeniMermi.GetComponent<mermiKod>().YonAta(Yon.Sol);
            yeniMermi.tag = "DusmanMermi";
            _mermiGecenSure = 0.0f;
        }else
        {
            _mermiGecenSure += Time.deltaTime;
        }
    }
}
