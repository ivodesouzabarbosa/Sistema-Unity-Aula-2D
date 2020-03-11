using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepref : MonoBehaviour
{
    public float projetcSpeed;
    private Rigidbody2D rd;
    public float speedDisable;
    void OnEnable()
    {
        if (rd != null)
        {
            rd.velocity = Vector2.right * projetcSpeed;
        }
        Invoke("Disable", speedDisable);
    }

    // Update is called once per frame
    void Start()
    {

        rd =GetComponent<Rigidbody2D>();
        rd.velocity = Vector2.right * projetcSpeed;
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
