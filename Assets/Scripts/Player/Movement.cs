using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private AudioSource _walkSound;
    [SerializeField] private AudioSource _moveSound;

    public float MoveSpeedChange = 1;

    private float _horizontalInput;
    private float _verticalInput;

    private Animator _animator;

    private Vector3 _moveDirection;
    private Vector3 _previousMoveDirection;

    private bool _isMoving = false;

    private Rigidbody _rigidBody;

    private Transform _transform;
    private Transform _previousPosition;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _transform = GetComponent<Transform>();
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
        _animator.SetBool("IsWalking", _isMoving);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        if (_horizontalInput != 0 || _verticalInput != 0)
        {

            _isMoving = true;
            _walkSound.mute = false;
            _moveSound.mute = false;
        }
        else
        {
            _isMoving = false;
            _walkSound.mute = true;
            _moveSound.mute = true;
        }

    }

    private void MovePlayer()
    {
        _moveDirection = _transform.forward * _verticalInput + _transform.right * _horizontalInput;

        _rigidBody.velocity = _moveDirection * _moveSpeed * MoveSpeedChange;
    }
}
