using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepref : MonoBehaviour
{
    public float projetcSpeed;
    private Rigidbody2D rd;

    void OnEnable()
    {
        if (rd != null)
        {
            rd.velocity = Vector2.up * projetcSpeed;
        }
        Invoke("Disable", 2f);
    }

    // Update is called once per frame
    void Start()
    {

        rd =GetComponent<Rigidbody2D>();
        rd.velocity = Vector2.up * projetcSpeed;
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
