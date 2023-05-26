using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReloadFlashLight : MonoBehaviour
{
    [SerializeField] private FlashLight _flashLight;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Battery")
        {
            _flashLight.CanReload = true;
            _flashLight._objectToDestroy = collision.gameObject;
        } ;
    }
}
