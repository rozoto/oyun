using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketKod : MonoBehaviour
{
    [SerializeField] GameObject _isinSablon;
    [SerializeField] float _isinFirlatmaAraligi = 1f;
    float _isinGecenSure = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10.0f, 0.0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sinirlar"))
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
    }
    // Update is called once per frame
    void Update()
    {
        IsinFirlat();
    }
    void IsinFirlat()
    {
        if (_isinGecenSure >= _isinFirlatmaAraligi)
        {
            var yeniMermi = Instantiate(_isinSablon);
            yeniMermi.transform.position = transform.position;
            yeniMermi.GetComponent<RoketIsinKod>().YonAta(Yon.Sol);
            yeniMermi.tag = "RoketIsin";
            _isinGecenSure = 0.0f;
        }
        else
        {
            _isinGecenSure += Time.deltaTime;
        }
    }
}
