using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip sound;
    public float delayTime;



    public GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = this.gameObject.AddComponent<AudioSource>();
        this.audiosource.clip = this.sound;
        this.audiosource.loop = false;
 

    }

public string LoadSceneName;

    public string RetrySceneName;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLoadStage()
    {
        this.audiosource.Play();
        
        SceneManager.LoadScene(LoadSceneName);
    }

    public void OnClickRetry()
    {
        this.audiosource.Play();
        SceneManager.LoadScene(RetrySceneName);
    }

}
