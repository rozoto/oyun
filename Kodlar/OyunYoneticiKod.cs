using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OyunYoneticiKod : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _txtPuan;
    [SerializeField] TextMeshProUGUI _txtYasam;
    [SerializeField] TextMeshProUGUI _txtText;

    int _puan;
    // Start is called before the first frame update
    void Start()
    {        
        PuanAta(0);
        _txtText.enabled = false;
    }
    public void YasamAta(int yasam)
    {
        _txtYasam.text = "Yasam: " + yasam;
        if (yasam <= 0)
        {
            Time.timeScale = 0.0f;
            _txtText.enabled = true;
        }
    }
    void PuanAta(int puan)
    {
        _txtPuan.text = "puan: " + puan;
    }
    public void PuanArttir(Puanlar yenipuan)
    {
        _puan += (int)yenipuan;
        PuanAta(_puan);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
