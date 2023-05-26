using UnityEngine;
using UnityEngine.UI;

public class SetMouseSensitivity : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void Update()
    {
        PlayerPrefs.SetFloat("MouseSens", _slider.value * 400f);
    }
}
