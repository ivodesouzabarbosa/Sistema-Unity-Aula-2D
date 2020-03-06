using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlataforma : MonoBehaviour
{
    // Start is called before the first frame update
    public bool _plataformaIntervalo;
    ManageCenario _manageCenario2;
    void Start()
    {
        _manageCenario2 = Camera.main.GetComponent<ManageCenario>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_plataformaIntervalo && collision.gameObject.CompareTag("Level"))
        {
            _manageCenario2.Repetirplataformas();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_plataformaIntervalo && collision.gameObject.CompareTag("Level"))
        {
            _manageCenario2.Repetirplataformalevel();
        }

    }
}
