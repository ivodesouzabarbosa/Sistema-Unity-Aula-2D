using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject backgroundMenu;
    public GameObject[] menuChance;
    public GameObject[] MenuInicar;
    public Text numVidas;
    public Text numVidasPanel;
    public Text numPontos;
    public Text numPOnstosPanel;
    ManageCenario _manageCenario2;
    public Transform posresp;
    bool pass;
    bool gameOver;
    public string NomeCena;
    public string NomeCenaMenu;
    public GameObject btMenu;
    public ControlInimigo ControlInimigo2;
    public GameObject panelLevel;
    public Text textLevel;


    void Start()
    {
        _manageCenario2 = Camera.main.GetComponent<ManageCenario>();
        _manageCenario2.MenuControl2 = gameObject.GetComponent<MenuControl>();
        _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
        _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = false;
        numVidas.text = "x " + _manageCenario2.QuantVidas;
        for (int i = 0; i < menuChance.Length; i++)
        {
            menuChance[i].transform.localScale = new Vector3(0, 0, 0);
            if (menuChance[i].GetComponent<Button>() != null)
            {
                menuChance[i].GetComponent<Button>().enabled=false;
            }
        }
        menuChance[menuChance.Length-1].gameObject.SetActive(false);
        btMenu.SetActive(false);
        panelLevel.transform.localScale = new Vector3(0, 0, 0);
       
    }

    // Update is called once per frame
    public IEnumerator OnLevel()
    {
        panelLevel.transform.localScale = new Vector3(0, 0, 0);
        textLevel.text = "Level " + _manageCenario2._levelgame;
        panelLevel.transform.DOScale(1, 0.3f);
        yield return new WaitForSeconds(2f);
        panelLevel.transform.DOScale(0, 0.3f);
    }
    public void ChamarMenuVida(bool on)
    {
        StartCoroutine(HitMenuON(on));
    }
    public void InicioGame()
    {
        StartCoroutine(Inicargame());

    }

    IEnumerator HitMenuON(bool checkON)
    {
        if (checkON)
        {
            menuChance[0].SetActive(true);
            _manageCenario2.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _manageCenario2.Player.GetComponent<Rigidbody2D>().isKinematic = true;
            _manageCenario2.Player.GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(0));
            _manageCenario2.Player.GetComponent<BoxCollider2D>().enabled = false;
            _manageCenario2.Player.GetComponent<CircleCollider2D>().enabled = false;
            _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
            _manageCenario2.Player.GetComponent <UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = false;

            backgroundMenu.GetComponent<Image>().DOFade(0.7f, 0.25f);
            yield return new WaitForSeconds(.25f);
            if (!pass)
            {
                pass = true;
                _manageCenario2.QuantVidas--;
            }
      
            numVidas.text = "x " + _manageCenario2.QuantVidas;
            if (_manageCenario2.QuantVidas==0)
            {
                numVidasPanel.text = "Game Over";
                numPOnstosPanel.text = "Total de Pontos: " + numPontos.text;
                gameOver = true;
            }
            else if (_manageCenario2.QuantVidas == 1)
            {
                numVidasPanel.text = "Última Vida";
            }
            else
            {
                numVidasPanel.text = _manageCenario2.QuantVidas + " Vidas";
            }

            if (!gameOver)
            {
                for (int i = 0; i < menuChance.Length; i++)
                {
                    menuChance[i].transform.DOScale(1.2f, .25f);
                    yield return new WaitForSeconds(.25f);
                    menuChance[i].transform.DOScale(1, .25f);
                }
                for (int i = 0; i < menuChance.Length; i++)
                {
                    if (menuChance[i].GetComponent<Button>() != null)
                    {
                        menuChance[i].GetComponent<Button>().enabled = checkON;
                    }
                }
                pass = false;
            }
            else
            {
                for (int i = 0; i < menuChance.Length; i++)
                {
                    menuChance[i].transform.DOScale(1.2f, .25f);
                    yield return new WaitForSeconds(.25f);
                    menuChance[i].transform.DOScale(1, .25f);
                    menuChance[menuChance.Length - 2].gameObject.SetActive(false);
                }
             
                menuChance[menuChance.Length - 1].gameObject.SetActive(true);
                menuChance[menuChance.Length - 1].GetComponent<Button>().enabled = true;
                btMenu.SetActive(true);
                btMenu.transform.DOScale(1, .25f);
          
            }
   
        }
        else
        {
            for (int i = 0; i < menuChance.Length; i++)
            {
                if (menuChance[i].GetComponent<Button>() != null)
                {
                    menuChance[i].GetComponent<Button>().enabled = checkON;

                }
            }
            for (int i = 0; i < menuChance.Length; i++)
            {
                yield return new WaitForSeconds(.20f);
                menuChance[i].transform.DOScale(0, .2f);
            }
            backgroundMenu.GetComponent<Image>().DOFade(0f, 0.2f);
            yield return new WaitForSeconds(.20f);
            _manageCenario2.Player.transform.position = posresp.position;
            yield return new WaitForSeconds(.20f);
            _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;
            _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = true;
            if (ControlInimigo2 != null)
            {
                ControlInimigo2.velPatrulheiro = ControlInimigo2.vel.x;
                ControlInimigo2.focaPulo = ControlInimigo2.vel.y;
            }
            _manageCenario2.Player.GetComponent<Rigidbody2D>().isKinematic = false;
            _manageCenario2.Player.GetComponent<BoxCollider2D>().enabled = true;
            _manageCenario2.Player.GetComponent<CircleCollider2D>().enabled = true;
            yield return new WaitForSeconds(.20f);
            menuChance[0].SetActive(false);

        }

    }
    IEnumerator Inicargame()
    {
        for (int i = 0; i < MenuInicar.Length; i++)
        {
            if (MenuInicar[i].GetComponent<Button>() != null)
            {
                MenuInicar[i].GetComponent<Button>().enabled = false;
            }
        }
     
        for (int i = 0; i < MenuInicar.Length; i++)
        {
            yield return new WaitForSeconds(.2f);
            MenuInicar[i].transform.DOScale(0, .2f);
        }
        backgroundMenu.GetComponent<Image>().DOFade(0f, 0.2f);
        yield return new WaitForSeconds(.2f);
        _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = true;
        _manageCenario2.Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = true;
        if (ControlInimigo2 != null)
        {
            ControlInimigo2.velPatrulheiro = ControlInimigo2.vel.x;
            ControlInimigo2.focaPulo = ControlInimigo2.vel.y;
        }
        _manageCenario2.Player.GetComponent<Rigidbody2D>().isKinematic = false;
        _manageCenario2.Player.GetComponent<BoxCollider2D>().enabled = true;
        _manageCenario2.Player.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(.20f);
        MenuInicar[0].SetActive(false);
    }
   public void ReinicarCena()
    {
        SceneManager.LoadScene(NomeCena);
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene(NomeCenaMenu);
    }
}
