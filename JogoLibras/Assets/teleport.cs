using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    [Header("Level para carregar")]
    [SerializeField] public string level;


    void Start()
    {
   
    }


    public void Carregalevel()
    {


        Handheld.Vibrate();
        SceneManager.LoadScene(level);
    


    }
    // Update is called once per frame
    void Update()
    {
        if (level == "")
        {
            if(GetComponent<Button>() != null)
            {
                GetComponent<Button>().enabled = false;
                GetComponent<Image>().enabled = false;
                if (GetComponentInChildren<Text>() != null)
                    GetComponentInChildren<Text>().enabled = false;
            }
        }

        if (level != "")
        {
            if (GetComponent<Button>() != null)
            {
                GetComponent<Button>().enabled = true;
                GetComponent<Image>().enabled = true;
                if(GetComponentInChildren<Text>() != null)
                GetComponentInChildren<Text>().enabled = true;
            }
        }
    }
}
