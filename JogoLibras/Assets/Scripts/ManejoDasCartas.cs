using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoDasCartas : MonoBehaviour
{
    private List<GameObject> _Cartas = new List<GameObject>();
    [SerializeField]private Sprite[] _Sprites;
    [SerializeField]private float[] _regulacaos;
    [SerializeField]private GameObject _CartaEmBranco;
    private List<Vector3> _posicao = new List<Vector3>();
    private List<bool> _valido = new List<bool>();
    [SerializeField]private float addcolum, addlinha;
    [SerializeField] private Vector3[] comeca;
    private int _Carta,type, dupla, coluna, linha, possiveis;
    private float length;
    private bool a, b = true;
    private GameObject Definer;
    private int _Dificudade;
    private void Start(){
        Definer = GameObject.FindGameObjectWithTag("GameController");
        if(GameObject.FindGameObjectWithTag("GameController") != null){
            if(Definer.GetComponent<GameDefiner>() != null){
                _Dificudade = Definer.GetComponent<GameDefiner>().Dificuldade;
            }
        }
        Regula();
        SetCarts();
        length = _Cartas.Count;
        Scrumble();
    }
    private void Update(){
        int types = _Sprites.Length;
        if(a){
            if(type <= types){
                if(type<=types){
                    if(dupla < 2){
                        GameObject verso = _Cartas[_Carta].transform.GetChild(1).gameObject;
                        if(_Cartas[_Carta].GetComponent<testandoClick>() != null){
                            _Cartas[_Carta].GetComponent<testandoClick>().Type = type;
                        }
                        verso.GetComponent<SpriteRenderer>().sprite = _Sprites[type];
                        _Carta +=1;
                        dupla +=1;
                    }else{
                        type +=1;
                        dupla =0;
                    } 
                }
            }else{
                a= false;
            }
        }
        if(_Carta >= length){
            a = false;
        }
    }
    public void Scrumble(){
        /*
            2. um random para ver qual posção aquela carta vai
            3. verifica c tem alguma carta naquela posição, se tiver faz o 1 dnv
            4. se não tiver, aquela posição vai mudar a bool para true 
            5. aquela carta vai para a posição livre
        */
        possiveis = _posicao.Count;
        for (int i = 0; i < _posicao.Count; i++)
        {
            verifica(i);
        }
    }
    private void verifica(int i){
        int esse = Random.Range(0, possiveis);
        if(_valido[esse] == true){
            _Cartas[i].transform.Translate(_posicao[esse], Space.World);
            _valido[esse] = false;
        }else{
            verifica(i);
        }
    }

    private void Regula(){
        switch(_Dificudade){
            case 0:
                for (int i = 0; i < _regulacaos[0]; i++)
                {
                    if(_CartaEmBranco != null){
                        _Cartas.Add(Instantiate(_CartaEmBranco, transform.position, Quaternion.identity));
                        if(coluna == 0 && linha == 0 && b == true){
                            _posicao.Add(new Vector3(comeca[0].x, comeca[0].y, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(coluna == 0 && linha > 0 && b == true){
                            _posicao.Add(new Vector3(comeca[0].x, _posicao[i-1].y + addlinha, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(b == true){
                            _posicao.Add(new Vector3(_posicao[i-1].x, _posicao[i-1].y + addlinha, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(b == false){
                            _posicao.Add(new Vector3(_posicao[i-1].x + addcolum, _posicao[i-4].y, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }
                        if(linha >= 4){
                            coluna ++;
                            linha = 0;
                            b = false;
                        }
                    }
                }
            break;
            case 1:
                for (int i = 0; i < _regulacaos[1]; i++)
                {
                    if(_CartaEmBranco != null){
                        _Cartas.Add(Instantiate(_CartaEmBranco, transform.position, Quaternion.identity));
                        if(coluna == 0 && linha == 0 && b == true){
                            _posicao.Add(new Vector3(comeca[1].x, comeca[1].y, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(coluna == 0 && linha > 0 && b == true){
                            _posicao.Add(new Vector3(comeca[1].x, _posicao[i-1].y + addlinha, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(b == true){
                            _posicao.Add(new Vector3(_posicao[i-1].x, _posicao[i-1].y + addlinha, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(b == false){
                            _posicao.Add(new Vector3(_posicao[i-1].x + addcolum, _posicao[i-4].y, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }
                        if(linha >= 4){
                            coluna ++;
                            linha = 0;
                            b = false;
                        }
                    }
                }
            break;
            case 2:
                for (int i = 0; i < _regulacaos[2]; i++)
                {
                    if(_CartaEmBranco != null){
                        _Cartas.Add(Instantiate(_CartaEmBranco, transform.position, Quaternion.identity));
                        if(coluna == 0 && linha == 0){
                            _posicao.Add(new Vector3(comeca[2].x, comeca[2].y, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(coluna == 0 && linha > 0){
                            _posicao.Add(new Vector3(comeca[2].x, _posicao[i-1].y + addlinha, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(b == true){
                            _posicao.Add(new Vector3(_posicao[i-1].x, _posicao[i-1].y + addlinha, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }else if(b == false){
                            _posicao.Add(new Vector3(_posicao[i-1].x + addcolum, _posicao[i-4].y, 0f));
                            _valido.Add(true);
                            linha++;
                            b = true;
                        }
                        if(linha >= 4){
                            coluna ++;
                            linha = 0;
                            b = false;
                        }
                    }
                }
            break;
        }
    }
    public void SetCarts(){
        a = true;
    }
}
