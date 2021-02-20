using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    [SerializeField] IntEventChannelSO _onHealthChange = default;

    private void OnEnable()
    {
        _onHealthChange.OnEventRaised += EmptyHearts;
    }

    private void OnDisable()
    {
        _onHealthChange.OnEventRaised -= EmptyHearts;
    }

    void EmptyHearts(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health - 1 < i)
                hearts[i].gameObject.SetActive(false);
        }
    }
}
