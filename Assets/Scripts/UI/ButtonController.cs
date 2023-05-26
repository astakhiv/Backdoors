using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class ButtonController : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _loadScreen;

    private Animator _animator;
    private int _sceneToLoad = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeToLevel(int scene)
    {
        _sceneToLoad = scene;
        _sound.Play();
        _animator.SetTrigger("fade");
    }

    private void OnFadeComplete()
    {
        StartCoroutine(LoadiongScreenOnFade());
    }
    

    public void Exit()
    {
        _sound.Play();
        Application.Quit();
    }

    IEnumerator LoadiongScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneToLoad);
        _loadScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            _slider.value = progress;
            yield return null;
        }
    }
}
