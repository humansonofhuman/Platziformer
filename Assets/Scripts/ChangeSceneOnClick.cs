using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName;
    [SerializeField] bool keepEnabledAfterClick = false;
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void OnEnable()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        button.enabled = keepEnabledAfterClick;
        SceneManager.LoadScene(sceneName);
    }

}
