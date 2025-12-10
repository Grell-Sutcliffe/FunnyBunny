using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Slider slder;
    public AudioSource audio;
    public float volume;
    // public Toggle toggle;

    void Start()
    {
        Load();
        ValumeMusik();

        // toggle = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        slder = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
    }

    public void SliderMusik()
    {
        volume = slder.value;
        Save();
        ValumeMusik();

    }

    /*
    public void TogleMusik()
    {
        if (toggle.isOn == true)
        {
            volume = 1;
        }
        else
        {
            volume = 0;
        }
        Save();
        ValumeMusik();
    }
    */

    private void ValumeMusik()
    {
        audio.volume = volume;
        slder.value = volume;
        volume = slder.value;
        /*
        if (volume == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
        */
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volume);
    }

    private void Load()
    {
        volume = PlayerPrefs.GetFloat("volume", volume);
    }
}
