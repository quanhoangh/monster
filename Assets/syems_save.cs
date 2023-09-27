using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class syems_save : MonoBehaviour
{
    public List<AudioSource> sound;
    public Slider volume;
    // Start is called before the first frame update
    void Start()
    {
       volume.value= PlayerPrefs.GetFloat("sound", 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        foreach (AudioSource source in sound)
        {
            source.volume = volume.value;
            PlayerPrefs.SetFloat("sound",volume.value);
        }
    }
}
