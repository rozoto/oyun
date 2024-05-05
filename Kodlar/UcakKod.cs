using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcakKod : MonoBehaviour
{
    [SerializeField] float hizCarpani;
    [SerializeField] GameObject _mermiSablonu;
    [SerializeField] Rigidbody2D _rigidBody;
    [SerializeField] GameObject _cikisNoktasi;
    [SerializeField] float _MermiCikisAraligi = 0.2f;
    float mermiGecenSuresi;

    OyunYoneticiKod _OyunYoneticiKod;
    Vector2 hiz;
    int _yasam = 900;

    void Start()
    {
        _OyunYoneticiKod = GameObject.Find("OyunYonetici").GetComponent<OyunYoneticiKod>();
       _rigidBody= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HareketEt();
        AtesKontrol();
    }
    void HareketEt()
    {
        hiz.x = 0.0f;
        hiz.y = 0.0f;

       hiz.x= Input.GetAxis("Horizontal")*hizCarpani;
       hiz.y= Input.GetAxis("Vertical")*hizCarpani;

        _rigidBody.velocity = hiz;
    }
    public void YasamAzalt(UcakHasarlari hasar)
    {
        _yasam -= (int)hasar;
        _OyunYoneticiKod.YasamAta(_yasam);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Yon mermiYonu = collision.gameObject.GetComponent<mermiKod>().Yon;
        bool dusmanMermisiCarptimi = collision.CompareTag("DusmanMermi");
        bool beyazDusmanMermisiCarptimi = collision.CompareTag("BeyazDusmanMermi");
        bool isinCarptimi = collision.CompareTag("RoketIsin");

        bool dusmanCarptimi = collision.CompareTag("Dusman");
        bool kareDusmanCarptimi = collision.CompareTag("KareDusman");
        bool beyazDusmanCarptimi = collision.CompareTag("BeyazDusman");
        bool roketCarptimi = collision.CompareTag("Roket");

        if (dusmanMermisiCarptimi||beyazDusmanMermisiCarptimi||isinCarptimi)
        {
            YasamAzalt(UcakHasarlari.MermiCarpti);
            Destroy(collision.gameObject);
        }
        if (kareDusmanCarptimi||beyazDusmanCarptimi||dusmanCarptimi||roketCarptimi)
        {
            YasamAzalt(UcakHasarlari.DusmanCarpti);
           
        }
        
    }
    

    public void AtesKontrol()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (mermiGecenSuresi >= _MermiCikisAraligi)
            {
                var yeniMermi = Instantiate(_mermiSablonu);
                yeniMermi.transform.position = _cikisNoktasi.transform.position;
                yeniMermi.GetComponent<mermiKod>().YonAta(Yon.Sag);
                yeniMermi.tag = "UcakMermi";
                mermiGecenSuresi = 0.0f;
            }

        }
        mermiGecenSuresi+=Time.deltaTime;
    }

}
