using UnityEngine;
using UnityEngine.UI;

public class RunControl : MonoBehaviour
{
    [SerializeField] private float _endurance;
    [SerializeField] private Image _enduranceImage;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _viewChange;
    [SerializeField] private AudioSource _breathingSound;

    public bool IsRunning = false;
    public bool IsShift = false;
    private float _timer = 0;
    private float _fieldOfView = 60f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
            IsRunning = true;
        else if (Input.GetKeyUp(KeyCode.W))
            IsRunning = false;
        if (IsShift) IsRunning = false;
        _breathingSound.mute = !(_endurance < 30);

        if (IsRunning && _endurance > 0)
        {
            _fieldOfView += _viewChange;
            GetComponent<Movement>().MoveSpeedChange = 2f;
            _endurance -= 0.1f;
            _timer = 0;

        }
        else if (!IsRunning || _endurance <= 0)
        {
            _fieldOfView -= _viewChange * 2;
            GetComponent<Movement>().MoveSpeedChange = 1f;
            _timer += Time.deltaTime;
            if (_endurance < 100 && (_timer >= 5f || _endurance >= 30))
                _endurance += 0.1f;

        }

        if (_endurance <= 1)
            IsRunning = false;
        _enduranceImage.fillAmount = _endurance / 100f;
        if (_fieldOfView > 80) _fieldOfView = 80;
        else if (_fieldOfView < 60) _fieldOfView = 60;

        _playerCamera.fieldOfView = _fieldOfView;
    }
}
