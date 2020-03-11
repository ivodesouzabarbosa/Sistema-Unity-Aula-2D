using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoControl : MonoBehaviour
{
    // Start is called before the first frame update
    public ManageCenario _manageCenario2;
    void Start()
    {
        _manageCenario2 = Camera.main.GetComponent<ManageCenario>();
        _manageCenario2.PontosL.Add(gameObject);
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _manageCenario2.QuantPontos++;
            _manageCenario2.MenuControl2.numPontos.text =""+ _manageCenario2.QuantPontos.ToString("D3");
            sair();
        }
    }
    void sair()
    {
        gameObject.SetActive(false);
    }
   
}
