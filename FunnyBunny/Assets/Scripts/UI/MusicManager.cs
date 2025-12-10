using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;
    public float volume;
    // public Toggle toggle;

    public AudioClip[] tracks;

    public float defaultVolume = 1f;
    private int currentIndex = 0;

    void Start()
    {
        if (slider != null)
        {
            slider.value = defaultVolume;
            slider.onValueChanged.AddListener(SetVolume);
        }

        Load();
        ValumeMusik();

        audioSource.loop = false;

        // toggle = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();

        if (tracks != null && tracks.Length > 0)
        {
            PlayTrack(0);
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying && tracks.Length > 0)
        {
            NextTrack();
        }
    }

    public void NextTrack()
    {
        PlayTrack(currentIndex + 1);
    }

    public void PreviousTrack()
    {
        PlayTrack(currentIndex - 1);
    }

    void PlayTrack(int index)
    {
        if (tracks.Length == 0) return;

        currentIndex = (index + tracks.Length) % tracks.Length;
        audioSource.clip = tracks[currentIndex];
        audioSource.Play();
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
    }

    public void SliderMusik()
    {
        volume = slider.value;
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
        audioSource.volume = volume;
        slider.value = volume;
        volume = slider.value;
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
