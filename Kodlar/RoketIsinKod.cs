using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketIsinKod : MonoBehaviour
{
    float hizCarpani = 20.0f;

    Rigidbody2D _rigidbody;
    Yon _yon;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public Yon Yon { get { return _yon; } }

    public void YonAta(Yon yeniYon)
    {
        _yon = yeniYon;
        switch (_yon)
        {
            case Yon.Sag:
                _rigidbody.velocity = new Vector3(hizCarpani, 0, 0);
                break;
            case Yon.Sol:
                _rigidbody.velocity = new Vector3(-hizCarpani, 0.0f, 180.0f);
                transform.Rotate(0.0f, 0.0f, 180.0f);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RoketIsin"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sinirlar"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
