using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rig;
    public float waitTime;
    public float timer = 0.0f;
    public bool patrulheiro;
    public float velPatrulheiro;
    public Transform posIniPatrulheiro;
    public Transform posfinalPatrulheiro;
    GameObject chao;
    bool chaocheck;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
   
    



        if (patrulheiro)
        {
            Vector3 diff = posfinalPatrulheiro.position - posIniPatrulheiro.position;
            RaycastHit2D hit = Physics2D.Raycast(posIniPatrulheiro.transform.position, diff);
            Debug.DrawRay(posIniPatrulheiro.transform.position, diff, Color.green);
            if (!chaocheck)
            {
                chaocheck = true;
                chao = hit.collider.gameObject;
            }

            rig.velocity = new Vector2(-velPatrulheiro, rig.velocity.y);
            timer += Time.deltaTime;

            if (hit.collider.gameObject != chao|| timer > waitTime)
            {
                timer = timer - waitTime;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                velPatrulheiro = velPatrulheiro * -1;
            }


        }
    }


}
