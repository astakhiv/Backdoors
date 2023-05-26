using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _UICamera;
    [SerializeField] private GameObject _resturtMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private AudioSource _deathAudio;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }

    private void Death()
    {
        _player.SetActive(false);
        _resturtMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _deathAudio.Play();
        if (_UICamera.activeSelf == false)
            _UICamera.SetActive(true);
        if (_pauseMenu.activeSelf == true)
            _pauseMenu.SetActive(false);
    }
}
