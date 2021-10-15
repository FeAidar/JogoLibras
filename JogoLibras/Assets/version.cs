using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class version : MonoBehaviour
{
    private Text _gameversion;
    void Start()
    {
        _gameversion = GetComponent<Text>();
        _gameversion.text = ("Versão:" + Application.version);
    }

}
