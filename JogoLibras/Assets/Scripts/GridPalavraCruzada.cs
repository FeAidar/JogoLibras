using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridPalavraCruzada : MonoBehaviour
{
    /*
        1. gerar o grid     x
        2. selecionar o pack de palavras(para selecionar as palavras)  x
        3. organizar as palavras selecionadas de maneira decresente   x
        4. colocar a maior palavra no grid   x
        5. verificar se tem alguma palavra que contenha um letra da ultima palavra e se cabe no grid naquela posição
        6. colocar tal palavra no grid
        8. repita os passos 5 e 6 ate n ter mais palavras
    */

    [Header("Parte das palavras")]
    [SerializeField]private GameObject[] Packs;
    private List<GameObject> ListaDePalavrasPossiveis = new List<GameObject>();
    private List<GameObject> ListaDePalavrasSelecionadas = new List<GameObject>();
    private List<GameObject> ListaDePalavrasPosicionadas = new List<GameObject>();

    [Header("Variaveis do Grid")]
    
    [SerializeField]private float x_start;
    [SerializeField]private float y_start;
    [SerializeField]private float x_space, y_space;
    [SerializeField]private GameObject[] espaco;
    public int CollumLength, RowLength;
    private int colluNum, RowNum;
    private Dictionary<Vector2, GameObject> OnGridPosi = new Dictionary<Vector2, GameObject>();
    

    //Game definer e suas variaveis
    private GameObject GameDefiner;
    private int dificuldade, quantia, pack;

    [Header("GameDefiner para a cruzadinha")]
    [SerializeField]private int[] Dificuldade; 
    [SerializeField]private int[] Quantia;


    Coroutine coroutine;

    GameObject temp;
    void Start()
    {
        GameDefiner = GameObject.FindGameObjectWithTag("GameController");
        dificuldade = GameDefiner.GetComponent<GameDefiner>().Dificuldade;
        quantia = GameDefiner.GetComponent<GameDefiner>().Quantia;
        pack = GameDefiner.GetComponent<GameDefiner>().pack;

        GeraGrid();
        SelecionaPack();
        SelecionaPalavras();
        OrganizaPalavras(ListaDePalavrasSelecionadas);
        ColocaPrimeiraNoGrid();
        Debug.Log("analizando ");
        
        ColocaAsOutras();
    }

    void Update(){

    }
    private void GeraGrid(){
        for (int i = 0; i < CollumLength * RowLength; i++)
        {
            espaco[i].transform.position = new Vector2(x_start+(x_space*colluNum),y_start+(-y_space*RowNum));
            OnGridPosi.Add(new Vector2(colluNum, RowNum), espaco[i]);
            colluNum++;
            if(colluNum >= CollumLength){
                colluNum = 0;
                RowNum ++;
            }
            espaco[i].SetActive(false);
        }
    }
    private void SelecionaPack(){
        GameObject a = Instantiate(Packs[pack],transform.position, Quaternion.identity);
        int b = a.transform.childCount;
        for (int i = 0; i < b; i++)
        {
            ListaDePalavrasPossiveis.Add(a.transform.GetChild(i).gameObject);
        }
    }
    private void SelecionaPalavras(){
        switch (quantia)
        {
            case 0:
                Palavras(Quantia[0]);
            break;
            case 1:
                Palavras(Quantia[1]);
            break;
            case 2:
                Palavras(Quantia[2]);
            break;
        }
    }
    private void Palavras(int a){
        for (int i = 0; i < a; i++)
        {
            int b = ramdum(ListaDePalavrasPossiveis.Count);
            ListaDePalavrasSelecionadas.Add(ListaDePalavrasPossiveis[b]);
            ListaDePalavrasPossiveis.Remove(ListaDePalavrasPossiveis[b]);
        }
        if(ListaDePalavrasPossiveis != null){
            for (int i = 0; i < ListaDePalavrasPossiveis.Count; i++)
            {
                Destroy(ListaDePalavrasPossiveis[i]);
            }
        }
        ListaDePalavrasPossiveis.Clear();
    }
    private int ramdum(int b){
        int r = Random.Range(0, b);
        return r;
    }

    private void OrganizaPalavras(List<GameObject> s){
        for (int i = 1; i <= Quantia[quantia]; i++)
        {
            if(i < Quantia[quantia]){
                temp = s[i];
                int j = i - 1;
                while (j >= 0 && temp.name.Length < s[j].name.Length)
                {
                    if(j+1 >=0 && j>=0 && j+1 <Quantia[quantia] && j <Quantia[quantia]){
                        s[j+1] = s[j];
                    }
                    j--;
                }
                if(j+1 >=0 && j+1 <Quantia[quantia]){
                    s[j+1] = temp;
                }
            }
        }
    }
    private void ColocaPrimeiraNoGrid(){
        int c = ramdum(2);
        if(c <= 0){
            int d = ramdum(colluNum);
            while((d- ListaDePalavrasSelecionadas[Quantia[quantia]-1].name.Length) > 0)
            {
                d = ramdum(colluNum);
            }
            int r = ramdum(RowLength);
            ColocaNaColuna(new Vector2(d, r),ListaDePalavrasSelecionadas[Quantia[quantia]-1]);
        }else if(c > 0){
            int d = ramdum(RowLength);
            while((ListaDePalavrasSelecionadas[Quantia[quantia]-1].name.Length + d) > RowLength)
            {
                d = ramdum(RowLength);
            }
            int r = ramdum(colluNum);
            ColocaNaLinha(new Vector2(r, d),ListaDePalavrasSelecionadas[Quantia[quantia]-1]);
        }
        ListaDePalavrasPosicionadas.Add(ListaDePalavrasSelecionadas[Quantia[quantia]-1]);
        ListaDePalavrasSelecionadas.Remove(ListaDePalavrasSelecionadas[Quantia[quantia]-1]);
    }

    private void ColocaAsOutras(){
        int q = ListaDePalavrasSelecionadas.Count;
        Debug.Log("analizando ");
        int u= 0;
        for (int i = 0; i < q; i++)
        {
            GameObject ultima= ListaDePalavrasPosicionadas[ListaDePalavrasPosicionadas.Count -1];
            int t= ListaDePalavrasSelecionadas.Count-1- u;
            int posiLetra= 0;
            foreach (char item in ultima.name)
            {
                int posiLetraoutra = 0 ;
                foreach (char m in ListaDePalavrasSelecionadas[t].name)
                {
                    Debug.Log("analizando " + ListaDePalavrasSelecionadas[t].name);
                    if(item == m){
                        if(ultima.GetComponent<PalavraNogrid>() != null){
                            Vector2 g= ultima.GetComponent<PalavraNogrid>().Espacos[posiLetra];
                            if(ultima.GetComponent<PalavraNogrid>().vertical == true){
                                int h = (int)g.y - posiLetraoutra;
                                int y = h + ListaDePalavrasSelecionadas[t].name.Length;
                                if(h >=0 && y <= 9 && ListaDePalavrasSelecionadas[t].GetComponent<PalavraNogrid>().posicionada == false){
                                    Debug.Log("ue");
                                    ColocaNaLinha(new Vector2(g.x,h), ListaDePalavrasSelecionadas[t]);
                                    ListaDePalavrasPosicionadas.Add(ListaDePalavrasSelecionadas[t]);
                                    u ++;
                                }else{
                                    Debug.Log("pode não");
                                }
                            }else{
                                int h = (int)g.x - posiLetraoutra;
                                int y = h + ListaDePalavrasSelecionadas[t].name.Length;
                                if(h >= 0 && y<= 9 && ListaDePalavrasSelecionadas[t].GetComponent<PalavraNogrid>().posicionada == false){
                                    Debug.Log("ue");
                                    ColocaNaColuna(new Vector2(h, g.y), ListaDePalavrasSelecionadas[t]);
                                    ListaDePalavrasPosicionadas.Add(ListaDePalavrasSelecionadas[t]);
                                    u ++;
                                }else{
                                    Debug.Log("pode não");
                                }
                            }
                        }
                    }
                    posiLetraoutra ++;
                }
                posiLetraoutra = 0;
                posiLetra ++;
            }
            posiLetra = 0;
        }
    }
    private void ColocaNaColuna(Vector2 v, GameObject o){
        int a = 0;
        foreach (char l in o.name)
        {
            if(o.transform.GetComponent<PalavraNogrid>() != null){
                o.transform.GetComponent<PalavraNogrid>().vertical = true;
                o.transform.GetComponent<PalavraNogrid>().posicionada = true;
                OnGridPosi[v].transform.GetChild(0).GetComponent<TextMeshPro>().text = ""+l;
                OnGridPosi[v].SetActive(true);
                o.transform.GetComponent<PalavraNogrid>().Espacos.Add(v);
                v.x++;
                a++;
            }
            
        }
    }
    private void ColocaNaLinha(Vector2 v, GameObject o){
        int a = 0;
        foreach (char l in o.name)
        {
            if(o.transform.GetComponent<PalavraNogrid>() != null){
                o.transform.GetComponent<PalavraNogrid>().vertical = false;
                o.transform.GetComponent<PalavraNogrid>().posicionada = true;
                OnGridPosi[v].transform.GetChild(0).GetComponent<TextMeshPro>().text = ""+l;
                OnGridPosi[v].SetActive(true);
                o.transform.GetComponent<PalavraNogrid>().Espacos.Add(v);
                v.y++;
                a++;
            }
        }
    }
}
