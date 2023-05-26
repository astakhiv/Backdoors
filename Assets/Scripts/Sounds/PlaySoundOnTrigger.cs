using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _sound1;
    [SerializeField] private AudioSource _sound2;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ScarySound")
        {
            _sound1.Play();
            Destroy(other);
        }

        if (other.gameObject.tag == "ScarySound2")
        {
            _sound2.Play();
            Destroy(other);
        }
    }
}
