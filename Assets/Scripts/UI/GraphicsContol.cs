using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class GraphicsContol : MonoBehaviour
{
    [SerializeField] private Toggle _postProcessing;
    [SerializeField] private Toggle _antiAlacing;   
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("PostProcessing"));
        _postProcessing.isOn = PlayerPrefs.GetInt("PostProcessing") == 1 ? true : false;
        _antiAlacing.isOn = PlayerPrefs.GetInt("AntiAlicing") == 1 ? true : false;
    }
    public void SetPostProcessing(bool val)
    {
        var numToSet = val == true ? 1 : 0;
        PlayerPrefs.SetInt("PostProcessing", numToSet);
    }

    public void SetAntiAlacing(bool val)
    {
        var numToSet = val == true ? 1 : 0;
        PlayerPrefs.SetInt("AntiAlicing", numToSet);
    }
}
