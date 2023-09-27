using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_gameover : MonoBehaviour
{
    //Menu gameover
    public int scene_;
    public TextMeshProUGUI time;
    float timer=0;

    //menu pause
    public GameObject Menu_pause;
    public bool isPause;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1.0f;
        Menu_pause.SetActive(false);
        
    }
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        time.text = "time : " + Math.Round(timer,1) ;
        
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(isPause)
            {
                resume_game();
            }
            else
            {
                pause_game();
            }
        }
    }
    public void load_scene()
    {
        SceneManager.LoadScene(scene_);
    }

    public void pause_game()
    {
        Time.timeScale = 0;
        Menu_pause.SetActive(true);
        isPause= true;
    }
    public void resume_game()
    {
        Time.timeScale = 1.0f;
        Menu_pause.SetActive(false);
        isPause= false;
    }
}
