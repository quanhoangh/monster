using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syems_menu_0 : MonoBehaviour
{
    public GameObject Menu_settings;
    public GameObject Menu_ask;
    // Start is called before the first frame update
    void Start()
    {
        Menu_settings.SetActive(false);   
        Menu_ask.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void opeenMenu_setting()
    {
        Menu_settings.SetActive(true);
    }
    public void closeMenuSetting()
    {
        Menu_settings.SetActive(false);
    }
    public void exit()
    {
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        }
    }
    public void close_askExit()
    {
        Menu_ask.SetActive(false);
    }
    public void open_menuAsk()
    {
        Menu_ask.SetActive(true);
    }
}
