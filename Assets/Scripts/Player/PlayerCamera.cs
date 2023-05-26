using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _sensX = 0.0f;
    [SerializeField] private float _sensY = 0.0f;  

    [SerializeField] private Transform _orientation;

    private Transform _transform;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _sensX = PlayerPrefs.GetFloat("MouseSens");
        _sensY = PlayerPrefs.GetFloat("MouseSens");
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        _transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        _orientation.localRotation= Quaternion.Euler(0, yRotation, 0);
    }
}
