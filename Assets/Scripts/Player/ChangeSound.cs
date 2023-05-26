using System.Linq;
using UnityEngine;

public class ChangeSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _walkSounds;
    [SerializeField] private AudioClip[] _runSounds;
    [SerializeField] private AudioClip[] _clothesSound;
    [SerializeField] private AudioSource _playerWalk;
    [SerializeField] private AudioSource _playerMovement;

    private bool _concrete = true;
    private bool _isRunning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Concrete")
        {
            _concrete = true;
        }
        else if (other.gameObject.tag == "Curpet")
        {
            _concrete = false;
        }
    }

    private void Update()
    {
        _isRunning = GetComponent<RunControl>().IsRunning;
        if (_isRunning)
        {
            _playerMovement.clip = _clothesSound[0];
            _playerWalk.clip = _runSounds[_concrete == true ? 1 : 0];
        }
        else
        {
            _playerMovement.clip = _clothesSound[1];
            _playerWalk.clip = _walkSounds[_concrete == true ? 1 : 0];
        }

        _playerWalk.Pause();
        _playerMovement.Pause();
        _playerWalk.Play();
        _playerMovement.Play();
    }
}