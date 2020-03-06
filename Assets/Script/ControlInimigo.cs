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
    public bool voador;
    public bool pulador;
    public float velPatrulheiro;
    public Transform posIniPatrulheiro;
    public Transform posfinalPatrulheiro;
    GameObject chao;
    ManageCenario _manageCenario2;
    bool chaocheck;
    public Vector3 posIni;
    Vector3 scale;
    Animator anim;
    Collider2D cool;
    bool pularC;
    public float focaPulo;
    public float tempoPulo;
    public Vector2 vel;
    Vector3 diff;
    RaycastHit2D hit;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posIni = GetComponent<Transform>().localPosition;
        anim = GetComponent<Animator>();
        scale = transform.localScale;
        anim = GetComponent<Animator>();
        cool = GetComponent<Collider2D>();
        vel.x = velPatrulheiro;
        vel.y = focaPulo;
        _manageCenario2 = Camera.main.GetComponent<ManageCenario>();
        _manageCenario2.inimigosL.Add(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (patrulheiro)
        {
            diff = posfinalPatrulheiro.position - posIniPatrulheiro.position;
            hit = Physics2D.Raycast(posIniPatrulheiro.transform.position, diff);
            Debug.DrawRay(posIniPatrulheiro.transform.position, diff, Color.green);
            if (!chaocheck)
            {
                chaocheck = true;
                chao = hit.collider.gameObject;
            }

            rig.velocity = new Vector2(velPatrulheiro, rig.velocity.y);
            timer += Time.deltaTime;

            if ((hit.collider.gameObject != chao && !hit.collider.CompareTag("Level")) || timer > waitTime)
            {
                MudarLado();
            }
        }
        else if (voador)
        {


            rig.velocity = new Vector2(velPatrulheiro, rig.velocity.y);
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                timer = timer - waitTime;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                velPatrulheiro = velPatrulheiro * -1;

            }
        }
        else if (pulador)
        {
            Vector3 diff1 = posfinalPatrulheiro.position - posIniPatrulheiro.position;
            RaycastHit2D hit1 = Physics2D.Raycast(posIniPatrulheiro.transform.position, diff1);
            Debug.DrawRay(posIniPatrulheiro.transform.position, diff1, Color.green);
            if (!chaocheck)
            {
                chaocheck = true;
                chao = hit1.collider.gameObject;
            }
            if (!pularC)
            {
                rig.AddForce(transform.up * focaPulo);
                pularC = true;

                Invoke("puclarCC", tempoPulo);


            }
            if (rig.velocity.y > 0.1f)
            {
                anim.SetBool("Sobe", true);
                anim.SetBool("Desce", false);
            }
            else if (rig.velocity.y < -0.1f)
            {
                anim.SetBool("Sobe", false);
                anim.SetBool("Desce", true);
            }
            else if (rig.velocity.y == 0)
            {
                anim.SetBool("Sobe", false);
                anim.SetBool("Desce", false);
            }
        }

    }


    void puclarCC()
    {
        pularC = false;
    }
    public void PosIni()
    {
        transform.position = posIni;
        rig.velocity = new Vector2(velPatrulheiro, rig.velocity.y);
        timer = timer - waitTime;
        StatusMorte(false);

    }
    public void StatusMorte(bool checkM)
    {
        anim.SetBool("Morte", checkM);
        cool.enabled = !checkM;
        if (voador)
        {
            rig.isKinematic = !checkM;
            rig.velocity = new Vector2(rig.velocity.x, 0);
        }
    }

    public void MudarLado(){
        timer = timer - waitTime;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        velPatrulheiro = velPatrulheiro * -1;
    }

}
