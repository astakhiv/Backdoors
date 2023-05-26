using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSpot : MonoBehaviour
{
    public float speed;
    public Transform camera;
    public Transform spot;

    void Update()
    {
        spot.rotation = Quaternion.Lerp(spot.rotation, camera.rotation, Time.deltaTime * speed);
        spot.position = camera.position;
    }
}
