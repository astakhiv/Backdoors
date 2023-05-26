using UnityEngine;

public class ShiftControl : MonoBehaviour
{

    [SerializeField] private float _speedLerp = 1;

    private float _timer = 1;

    private Vector3 _newPosition = new Vector3();

    private Transform _transform;


    private void Start()
    {

        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _timer += Time.deltaTime * _speedLerp;
        int endYPosition = 1;

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
            _timer = 0;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            endYPosition = 0;
            GetComponent<Movement>().MoveSpeedChange = 0.5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            endYPosition = 1;
            GetComponent<Movement>().MoveSpeedChange = 1f;
        }

        _newPosition = new Vector3(_transform.position.x, 
                                    Mathf.Lerp(_transform.position.y, endYPosition, _timer), 
                                    _transform.position.z);

        _transform.position = _newPosition;
    }
}
