using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibracao 
{
    // Start is called before the first frame update
    public static void vibra()
    {
        if (PlayerPrefs.GetInt("Vibra") == 1)
        {
            Handheld.Vibrate();
            Debug.Log("Vibrei");

        }
        else
            Debug.Log("Não Vibrei");
        return;
    }


}
