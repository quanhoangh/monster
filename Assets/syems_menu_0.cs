using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syems_menu_0 : MonoBehaviour
{
    public GameObject Menu_settings;
    // Start is called before the first frame update
    void Start()
    {
        Menu_settings.SetActive(false);   
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
}
