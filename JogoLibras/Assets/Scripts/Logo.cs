using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
 
public class Logo : MonoBehaviour
{

    VideoPlayer video;
    public int Tela;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(Tela);
    }
}
 

