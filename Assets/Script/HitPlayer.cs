using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    ManageCenario _manageCenario2;
    public Transform PosrespwPref;
    public ControlInimigo ControlInimigo2;
  

    void Start()
    {
        _manageCenario2 = Camera.main.GetComponent<ManageCenario>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ControlInimigo2 != null)
            {
                _manageCenario2.MenuControl2.ControlInimigo2 = ControlInimigo2;
                ControlInimigo2.velPatrulheiro = 0;
                ControlInimigo2.focaPulo=0;
            }
            if (ControlInimigo2 != null && ControlInimigo2.transform.localScale.x > 0)
            {
                ControlInimigo2.MudarLado();
            }
            _manageCenario2.MenuControl2.posresp = PosrespwPref;          
            _manageCenario2.MenuControl2.ChamarMenuVida(true);

        }
    }
}
