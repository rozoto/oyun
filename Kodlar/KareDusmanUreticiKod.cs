using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KareDusmanUreticiKod : MonoBehaviour
{
    [SerializeField] GameObject _DusmanSablon;
    [SerializeField] float DusmanUretmeAraligi = 2f;
    [SerializeField] Transform _UstSinirPozisyon;
    [SerializeField] Transform _AltSinirPozisyon;

    float dusmanUretmeSayaci;
    float minX;
    float maxX;
    float minY;
    float maxY;
    // Start is called before the first frame update
    void Start()
    {
        minX = _AltSinirPozisyon.position.x;
        maxX = _UstSinirPozisyon.position.x;
        minY = _AltSinirPozisyon.position.y;
        maxY = _UstSinirPozisyon.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        DusmanUret();
    }

    public void DusmanUret()
    {
        if (dusmanUretmeSayaci >= DusmanUretmeAraligi)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0.0f);
            Instantiate(_DusmanSablon, randomPosition, Quaternion.identity);
            dusmanUretmeSayaci = 0.0f;
        }
        dusmanUretmeSayaci += Time.deltaTime;
    }
}
