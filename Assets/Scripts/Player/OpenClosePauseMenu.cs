using UnityEngine;

public class OpenClosePauseMenu : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _UICamera;
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _endGame;
    private AudioSource[] _audioSources;

    private void Start()
    {
        _audioSources = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _endGame.activeSelf == false)
        {
            _playerCamera.enabled = !_playerCamera.enabled;
            Time.timeScale = _playerCamera.enabled == false ? 0 : 1;
            _UICamera.enabled = !_UICamera.enabled;
            _UI.SetActive(!_UI.activeSelf);
            Cursor.visible = _UI.activeSelf;
            Cursor.lockState = _UI.activeSelf == true ? CursorLockMode.None : CursorLockMode.Locked;
            if (_playerCamera.enabled) UnPauseAudio();
            else PauseAudio();
        }
    }

    private void PauseAudio()
    {
        foreach (var audio in _audioSources)
        {
            audio.Pause();
        }
    }

    private void UnPauseAudio()
    {
        foreach (var audio in _audioSources)
        {
            audio.UnPause();
        }
    }
}
