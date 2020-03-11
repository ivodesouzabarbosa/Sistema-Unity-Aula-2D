using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandyCoded;

public class ManageCenario : MonoBehaviour
{
    public List<GameObject> _plataformasinicial = new List<GameObject>();
    public List<GameObject> _plataformasL1 = new List<GameObject>();
    public List<GameObject> _plataformasL2 = new List<GameObject>();
    public List<GameObject> _plataformasL3 = new List<GameObject>();
    public List<GameObject> inimigosL = new List<GameObject>();
    public List<GameObject> PontosL = new List<GameObject>();

    public List<GameObject> _plataformasVariadas = new List<GameObject>();
    public GameObject _plataformaintervalo;
    public Transform _paiPlataformas;
    public GameObject _prefbPlataforma;
    public GameObject _prefbPlarLevel;
    public int _numeroPlaraformas;
    public float _valorDistplataforma;
    public int _levelgame;
    int _numbplatordem;
    public int QuantVidas;
    public int QuantPontos;
    public MenuControl MenuControl2;
    public GameObject Player;
    public Transform posTiro;


    void Start()
    {

        Calculodistanciaplataforma();
        Gerarplataformas(_plataformasL1.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Calculodistanciaplataforma()// calcula distanacia entre a primeira e a segunda plataforma
    {
        _valorDistplataforma = _plataformasinicial[0].transform.position.x - _plataformasinicial[1].transform.position.x;
        if (_valorDistplataforma < 0)// checa se o valor é negativo, caso seja, transforma em positivo
        {
            _valorDistplataforma = _valorDistplataforma * -1;
        }
    }
    void PassLevel()
    {
        switch (_levelgame)
        {
            case 0:
                _prefbPlataforma = _plataformasL1[_numbplatordem];
                break;
            case 1:
                _prefbPlataforma = _plataformasL2[_numbplatordem];
                break;
            case 2:
                _prefbPlataforma = _plataformasL3[_numbplatordem];
                break;
            default:
                break;
        }
    
    }

    void instacPlatLevel()
    {
        GameObject _clone = Instantiate(_prefbPlataforma, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar plataformas
        _plataformasVariadas.Add(_clone); //add na lista
        _clone.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
        _clone.transform.position = new Vector2(0, 0);// posicionar 

    }

    void Gerarplataformas(int _numerolocal)// gera outras plataformas pela primeira vez
        {
        _plataformasVariadas = _plataformasVariadas.Shuffle();
      

        for (int i = 0; i < _numerolocal; i++)
        {
            PassLevel();
            GameObject _clone = Instantiate(_prefbPlataforma, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar plataformas
            _plataformasVariadas.Add(_clone); //add na lista
            _clone.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
            _clone.transform.position = new Vector2(0, 0);// posicionar 

            if (i == 0) {// se for a primeira pegar posição da plataformas iniciais
                _clone.transform.position = new Vector2(_plataformasinicial[1].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
            }
            else
            {
                _clone.transform.position = new Vector2(_plataformasVariadas[i - 1].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
                if (i == _numerolocal - 1)// se for colocado a ultima plataforma, coloca plataforma level
                {
                    _plataformaintervalo = Instantiate(_prefbPlarLevel, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar intervalo de plataformas
                    _plataformaintervalo.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject  
                    _plataformaintervalo.transform.position = new Vector2(0, 0);// posicionar 0
                    _plataformaintervalo.transform.position = new Vector2(_plataformasVariadas[i].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);

                }
            }
            _numbplatordem++;
            if (_numbplatordem== _plataformasL1.Count)
            {
               // Debug.Log(_numbplatordem +" "+ _plataformasL1.Count);
                _numbplatordem = 0;
            }
        }
       
    } 

    public void Repetirplataformas()
    {
        _levelgame++;
        StartCoroutine(MenuControl2.OnLevel());

        if (_levelgame == 1)
        {
            PassLevel();

            for (int i = 0; i < _plataformasL2.Count; i++)
            {
                instacPlatLevel();
            }
        }
        else if (_levelgame == 2)
        {
            PassLevel();

            for (int i = 0; i < _plataformasL3.Count; i++)
            {
                instacPlatLevel();
            }
        }
        else
        {

            int nn = _plataformasVariadas.Count;
            for (int m = 0; m <nn; m++)
            {
             //   Debug.Log("Else _levelgame " + _levelgame);
                GameObject _clone = Instantiate(_plataformasVariadas[m], _plataformasVariadas[m].transform.position, _plataformasVariadas[m].transform.rotation);// instanciar plataformas
                _plataformasVariadas.Add(_clone); //add na lista
                _clone.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
                _clone.transform.position = new Vector2(0, 0);// posicionar 
                 
              //  Debug.Log("_plataformasVariadas.Count " + _plataformasVariadas.Count);
            }
            
        }

        _plataformasVariadas = _plataformasVariadas.Shuffle();
        for (int i = 0; i < _plataformasVariadas.Count; i++)
        {
            if (i == 0)
            {// se for a primeira pegar posição da plataformas iniciais
                _plataformasVariadas[i].transform.position = new Vector2(_plataformaintervalo.transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
            }
            else
            {
                _plataformasVariadas[i].transform.position = new Vector2(_plataformasVariadas[i - 1].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
            }
            _numbplatordem++;
            if (_numbplatordem == _plataformasL1.Count)
            {
    
                _numbplatordem = 0;
            }
        }

        for (int i = 0; i < inimigosL.Count; i++)
        {
            inimigosL[i].GetComponent<ControlInimigo>().PosIni();
            inimigosL[i].GetComponent<ControlInimigo>().StatusMorte(false);
        }

    }
    public void Repetirplataformalevel()
    {

        _plataformaintervalo.transform.position = new Vector2(_plataformasVariadas[_plataformasVariadas.Count-1].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
    }
   
}
