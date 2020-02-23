using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCenario : MonoBehaviour
{
    public List<GameObject> _plataformasIniciais = new List<GameObject>();
    public List<GameObject> _plataformasVariadas = new List<GameObject>();
    public Transform _paiPlataformas;
    public GameObject _prefbPlataforma;
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
        _valorDistplataforma = _plataformasIniciais[0].transform.position.x - _plataformasIniciais[1].transform.position.x;
        if (_valorDistplataforma < 0)// checa se o valor é negativo, caso seja, transforma em positivo
        {
            _valorDistplataforma = _valorDistplataforma * -1;
        }
    }

    void Gerarplataformas(int _numerolocal)// gera outras plataformas
    {
        for (int i = 0; i < _numerolocal; i++)
        {
            GameObject clone = Instantiate(_prefbPlataforma, _prefbPlataforma.transform.position, _prefbPlataforma.transform.rotation);// instanciar plataformas
            _plataformasVariadas.Add(clone); //add na lista
            clone.transform.SetParent(_paiPlataformas);// colocar como filho de outro gameobject
            clone.transform.position = new Vector2(0, 0);// posicionar 
            if (i == 0)// se for a primeira pegar posição da plataformas iniciais
            {
                clone.transform.position = new Vector2(_plataformasIniciais[1].transform.position.x + _valorDistplataforma, _plataformasIniciais[1].transform.position.y);
            }
            else// se não for a primeira, pegar as posições da outras plataformas
            {
                clone.transform.position = new Vector2(_plataformasVariadas[i - 1].transform.position.x + _valorDistplataforma, _plataformasIniciais[1].transform.position.y);
            }
        }
    }
}
