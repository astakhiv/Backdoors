using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;

    private float _volume = 0;
    private void Start()
    {
        _audioMixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
    }

    private void Update()
    {
        _slider.value = PlayerPrefs.GetFloat("Volume");
    }
    public void OnValueChange(float Value)
    {   
        _volume = PlayerPrefs.GetFloat("Volume");
        _audioMixer.SetFloat("Volume", Mathf.Log10(_volume) * 20);

        PlayerPrefs.SetFloat("Volume", _slider.value);
        PlayerPrefs.Save();
    }
}
