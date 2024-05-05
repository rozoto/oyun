using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyazDusmanUretici : MonoBehaviour
{
    [SerializeField] GameObject _dusmanSablon;
    [SerializeField] float dusmanUretmeAraligi = 2f;
    [SerializeField] Transform _UstSinirPozisyon;
    [SerializeField] Transform _AltSinirPozisyon;

    float dusmanUretmeSayaci;
    float _MinY;
    float _MaxY;
    float x;
    float y;
    void Start()
    {
        x = _AltSinirPozisyon.position.x;
    }

    void Update()
    {
        DusmanUret();
    }

    void DusmanUret()
    {
        _MinY = _AltSinirPozisyon.position.y;
        _MaxY = _UstSinirPozisyon.position.y;


        if (dusmanUretmeSayaci >= dusmanUretmeAraligi)
        {
            y = Random.Range(_MinY, _MaxY);
            Instantiate(_dusmanSablon).transform.position = new Vector3(x, y, 0.0f);
            dusmanUretmeSayaci = 0.0f;
        }
        dusmanUretmeSayaci += Time.deltaTime;
    }
}
