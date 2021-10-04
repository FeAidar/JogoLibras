using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTime : MonoBehaviour
{
    private MochilaGameStarter _controller;
    private ItemSelector _itemselector;
    private Timer _timer;

    void Start()
    {
        _controller = FindObjectOfType<MochilaGameStarter>();
        _itemselector = FindObjectOfType<ItemSelector>();
        _timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        restart();
    }

    void restart ()
    {

            _controller.ComecaJogo();
        _itemselector.Restart();
        _timer.perdeu = false;
        Debug.Log("apertei");
        this.GetComponent<EndTime>().enabled = false;

    }
}
