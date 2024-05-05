using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyunBitti : MonoBehaviour
{
    public static Text oyunDurumu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void DurumuGoster(string durum)
    {
        oyunDurumu.text = durum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
