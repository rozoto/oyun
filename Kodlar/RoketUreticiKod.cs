using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketUreticiKod : MonoBehaviour
{
    [SerializeField] GameObject _DusmanSablon;
    [SerializeField] float DusmanUretmeAraligi = 3f;
    [SerializeField] Transform _AltSinirPozisyon;

    float dusmanUretmeSayaci;
    float _MinY;
    float _MaxY;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        x = _AltSinirPozisyon.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        DusmanUret();
    }
    public void DusmanUret()
    {
        _MinY = _AltSinirPozisyon.position.y;


        if (dusmanUretmeSayaci >= DusmanUretmeAraligi)
        {
            y = Random.Range(_MinY, _MaxY);
            Instantiate(_DusmanSablon).transform.position = new Vector3(x, y, 0.0f);
            dusmanUretmeSayaci = 0.0f;
        }
        dusmanUretmeSayaci += Time.deltaTime;
    }
}
