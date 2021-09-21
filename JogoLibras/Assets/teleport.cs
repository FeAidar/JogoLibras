using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    [SerializeField] public string level;

    void Start()
    {
       
    }


    public void Carregalevel()
    {
        SceneManager.LoadScene(level);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
