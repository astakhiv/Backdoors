using UnityEngine;
using UnityEngine.Rendering.Universal;
public class ItemCamera : MonoBehaviour
{
    [SerializeField] private UniversalAdditionalCameraData _playerCamera;
    void Awake()
    {
        GetComponent<Camera>().enabled = true;
        Time.timeScale = 1;
    }

    private void Start()
    {
        _playerCamera.renderPostProcessing = PlayerPrefs.GetInt("PostProcessing") == 1 ? true : false;
        _playerCamera.antialiasing = PlayerPrefs.GetInt("AntiAlicing") == 1 ? AntialiasingMode.SubpixelMorphologicalAntiAliasing: AntialiasingMode.None;
    }

}
