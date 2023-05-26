using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoomSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _sounds;
    [SerializeField] private AudioSource _source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NiggaRoom")
        {
            _source.clip = _sounds[0];
            _source.Play();
        }
        if(other.gameObject.tag == "NoNiggaRoom")
        {
            _source.clip = _sounds[1];
            _source.Play();
        }
    }
}
