using UnityEngine;
using UnityEngine.UI;

public class CameraBlur : MonoBehaviour
{
    [SerializeField] private float _scale;
    [SerializeField] private Image _image;

    private void Update()
    {
        if (_image.color.a > 0)
        {
            _image.color = new Color(0, 0, 0, _image.color.a - _scale);
        }
    }
}
