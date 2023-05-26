using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private float maxTime = 5f;

    [SerializeField] private float interpolationPeriod = 0.1f;
    [SerializeField] private AudioSource _turnOn;
    [SerializeField] private AudioSource _turnOff;

    public bool IsEnabled = true;
    public bool CanReload = false;
    public GameObject _objectToDestroy;
    private float time;
    private float currentTime;
    public int BatteryPersents = 100;
    private bool _canTurnOff = true;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && BatteryPersents > 10)
            IsEnabled = !IsEnabled;
        if (BatteryPersents > 10)
        {
            if (IsEnabled == true) _turnOn.Play();
            else _turnOff.Play();
        }

        if (BatteryPersents == 0)
            IsEnabled = false;

        currentTime += Time.deltaTime * 2;


        if (currentTime >= maxTime && BatteryPersents > 0 && IsEnabled)
        {
            currentTime = 0;
            BatteryPersents--;
        }

        if (BatteryPersents <= 20)
            GetComponentInChildren<Light>().intensity = 6f; 

        if (BatteryPersents > 0 && BatteryPersents <= 10)
        {
            time += Time.deltaTime;

            if (time >= interpolationPeriod & _canTurnOff)
            {
                time = 0.0f;
                IsEnabled = !IsEnabled;
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && CanReload)
        {
            _animator.SetTrigger("IsReloading");
            BatteryPersents = 100;
            GetComponentInChildren<Light>().intensity = 15f;
            IsEnabled = true;
            CanReload = false;
            Destroy(_objectToDestroy);
        }

        GetComponentInChildren<Light>().enabled = IsEnabled;
    }
}
