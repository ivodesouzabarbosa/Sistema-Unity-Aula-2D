using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform fireposition;
    ManageCenario _manageCenario2;
    void Start()
    {
        _manageCenario2 = Camera.main.GetComponent<ManageCenario>();
        fireposition = _manageCenario2.posTiro;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled)
        {
;
            Fire();
        }
    }
    private void Fire() {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj != null)
        {
           // Debug.Log(obj.gameObject.name + " hhh");
            obj.transform.position = fireposition.position;
            obj.transform.rotation = fireposition.rotation;
            obj.SetActive(true);
        }
  



    }
}
