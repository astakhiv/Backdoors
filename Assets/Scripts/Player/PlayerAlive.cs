using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Video;

public class PlayerAlive : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _UICamera;
    [SerializeField] private GameObject _resturtMenu;
    [SerializeField] private GameObject _pauseMenu;
    private ChromaticAberration _chromaticAberration;

    private bool _result;
    private VolumeProfile _profile;

    private void Start()
    {
        _profile = GetComponent<Volume>().profile;
        _result = _profile.TryGet(out _chromaticAberration);
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad >= 900f)
        {
            Death();
        }

        _chromaticAberration.intensity.Override(Time.timeSinceLevelLoad / 900f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Debug.LogError("Death");
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
        if (_UICamera.activeSelf == false)
            _UICamera.SetActive(true);
        if (_pauseMenu.activeSelf == true)
            _pauseMenu.SetActive(false);
    }
}
