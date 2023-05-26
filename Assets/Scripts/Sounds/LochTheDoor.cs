using UnityEngine;

public class LochTheDoor : MonoBehaviour
{
    [SerializeField] private GameObject _trigger;
    [SerializeField] private GameObject _door;
    [SerializeField] private AudioSource[] _sounds;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lock")
        {
            _door.GetComponent<Animator>().SetBool("Closed", true);
            _sounds[0].Play();
            _sounds[1].Play();
            Destroy(_trigger);
        }
    }
}
