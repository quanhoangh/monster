using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class syems_scene : MonoBehaviour
{
    public int scene;
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void load_scene()
    {
        SceneManager.LoadScene(scene); 
    }
}
