using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicionaplayer : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] public List<GameObject> Fases = new List<GameObject>();
    public bool apertou;
    private Vector3[] PosicaoFases { get; set; }
    [HideInInspector] public int fase;
    void Start()
    {
        Player = GameObject.Find("Player");
        PosicaoFases = new Vector3[Fases.Count];
        for (int i = 0; i < Fases.Count; i++)
        {
            PosicaoFases[i] = Fases[i].transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {

        PosicaoFases = new Vector3[Fases.Count];
        for (int i = 0; i < Fases.Count; i++)
        {
            PosicaoFases[i] = Fases[i].transform.position;
        }

        if(apertou)
            {
            if (Player.transform.position == PosicaoFases[fase] + (Vector3.down))
                apertou = false;
            else
              Player.transform.position = Vector3.MoveTowards(Player.transform.position, PosicaoFases[fase] + (Vector3.down), 500f * Time.deltaTime);
            }
        else
        { Player.transform.position = PosicaoFases[fase] + (Vector3.down); }
       

     //   transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);

        //, _movementTime * Time.fixedDeltaTime);
    }
}
