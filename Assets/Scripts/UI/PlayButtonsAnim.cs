using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonsAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayAnim()
    {
        _animator.enabled = true;
    }
}
