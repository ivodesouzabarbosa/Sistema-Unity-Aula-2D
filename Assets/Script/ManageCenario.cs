using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCenario : MonoBehaviour
{
    public GameObject _plataformasinicial;
    public List<GameObject> _plataformaintervalo = new List<GameObject>();
    public List<GameObject> _plataformasVariadas = new List<GameObject>();
    public Transform _paiPlataformas;
    public GameObject _prefbPlataforma;
    public GameObject _prefbPlarLevel;
    public int _numeroPlaraformas;
    public bool inicialGame;
    public float _valorDistplataforma;

    void Start()
    {
        Calculodistanciaplataforma();
        Gerarplataformas(_numeroPlaraformas, _plataformaintervalo[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Calculodistanciaplataforma()// calcula distanacia entre a primeira e a segunda plataforma
    {
        _valorDistplataforma = _plataformasinicial.transform.position.x - _plataformaintervalo[0].transform.position.x;
        if (_valorDistplataforma < 0)// checa se o valor é negativo, caso seja, transforma em positivo
        {
            _valorDistplataforma = _valorDistplataforma * -1;
        }
    }

    void Gerarplataformas(int _numerolocal, GameObject _platintervalo)// gera outras plataformas pela primeira vez
    {
         
        for (int i = 0; i < _numerolocal; i++)
        {
            GameObject _clone = Instantiate(_prefbPlataforma, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar plataformas
            _plataformasVariadas.Add(_clone); //add na lista
            _clone.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
            _clone.transform.position = new Vector2(0, 0);// posicionar 
           
            if (i == 0){// se for a primeira pegar posição da plataformas iniciais
                _clone.transform.position = new Vector2(_platintervalo.transform.position.x + _valorDistplataforma, _platintervalo.transform.position.y);
            }
            else
            {
                _clone.transform.position = new Vector2(_plataformasVariadas[i - 1].transform.position.x + _valorDistplataforma, _platintervalo.transform.position.y);
            }
            if(i == _numerolocal - 1)// se for colocado a ultima plataforma, coloca plataforma level
            {

                for (int j = 0; j < 2; j++)
                {
                    GameObject _cloneintervalo = Instantiate(_prefbPlarLevel, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar intervalo de plataformas
                    _cloneintervalo.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
                  

                    if (j == 0)
                    {// se for a primeira pegar posição da plataformas iniciais
                        _cloneintervalo.transform.position = new Vector2(_plataformasVariadas[i].transform.position.x + _valorDistplataforma, _platintervalo.transform.position.y);
                        _plataformaintervalo[0] = _cloneintervalo;
                        _cloneintervalo.GetComponent<ControlPlataforma>()._plataformaIntervalo = false;
                        Destroy(_cloneintervalo.GetComponent<CircleCollider2D>());
                    }
                    else
                    {
                        _plataformaintervalo.Add(_cloneintervalo);
                        _cloneintervalo.transform.position = new Vector2(_plataformaintervalo[j-1].transform.position.x + _valorDistplataforma, _platintervalo.transform.position.y);
                        _cloneintervalo.GetComponent<ControlPlataforma>()._plataformaIntervalo = true;
                    }

                }               
            }
        }
    }

    public void Repetirplataformalevel()
    {
        for (int i = 0; i < _plataformasVariadas.Count; i++)
        {
            if (i == 0)
            {// se for a primeira pegar posição da plataformas iniciais
                _plataformasVariadas[i].transform.position = new Vector2(_plataformaintervalo[1].transform.position.x + _valorDistplataforma, _plataformaintervalo[0].transform.position.y);
            }
            else
            {
                _plataformasVariadas[i].transform.position = new Vector2(_plataformasVariadas[i - 1].transform.position.x + _valorDistplataforma, _plataformaintervalo[0].transform.position.y);
            }
        }
    }
}
