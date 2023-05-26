using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _rendering;
    [SerializeField] private GameObject _UICamera;
    [SerializeField] private GameObject _UIController;

    private AudioSource[] _audioSources;

    private void Start()
    {
        _audioSources = FindObjectsOfType<AudioSource>();
    }
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name == "Player")
        {
            _victoryMenu.SetActive(true);
            _player.SetActive(false);
            _rendering.SetActive(false);
            _UICamera.SetActive(true);
            _UIController.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PauseAudio();
        }
    }
    private void PauseAudio()
    {
        foreach (var audio in _audioSources)
        {
            audio.Pause();
        }
    }
}
