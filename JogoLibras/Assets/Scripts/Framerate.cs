using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    public void Highframerate ()
    {
        Application.targetFrameRate = 60;

    }
    public void Lowframerate()
    {
        Application.targetFrameRate = 30;

    }

}
