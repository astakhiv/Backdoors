using UnityEngine;

public class StopAndPlayParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _oldParticleSystem;
    [SerializeField] private ParticleSystem _newParticleSystem;

    public void StartAndStop()
    {
        _oldParticleSystem.Pause();
        _newParticleSystem.Play();
    }
}
