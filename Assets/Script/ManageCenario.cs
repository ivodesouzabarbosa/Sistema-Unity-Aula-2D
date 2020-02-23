using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCenario : MonoBehaviour
{
    public List<GameObject> _plataformasinicial = new List<GameObject>();
    public List<GameObject> _plataformasVariadas = new List<GameObject>();
    public GameObject _plataformaintervalo;
    public Transform _paiPlataformas;
    public GameObject _prefbPlataforma;
    public GameObject _prefbPlarLevel;
    public int _numeroPlaraformas;
    public float _valorDistplataforma;

    void Start()
    {
        Calculodistanciaplataforma();
        Gerarplataformas(_numeroPlaraformas);
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

    void Gerarplataformas(int _numerolocal)// gera outras plataformas pela primeira vez
    {
        for (int i = 0; i < _numerolocal; i++)
        {
            GameObject _clone = Instantiate(_prefbPlataforma, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar plataformas
            _plataformasVariadas.Add(_clone); //add na lista
            _clone.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
            _clone.transform.position = new Vector2(0, 0);// posicionar 

            if (i == 0) {// se for a primeira pegar posição da plataformas iniciais
                _clone.transform.position = new Vector2(_plataformasinicial[i].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
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
        }
    } 

    public void Repetirplataformas()
    {
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
        }
    }
    public void Repetirplataformalevel()
    {
        _plataformaintervalo.transform.position = new Vector2(_plataformasVariadas[_plataformasVariadas.Count-1].transform.position.x + _valorDistplataforma, _plataformasinicial[0].transform.position.y);
    }
}
