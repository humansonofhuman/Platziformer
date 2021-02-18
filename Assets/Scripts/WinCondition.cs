using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool isLastLevel = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLastLevel)
                SceneChanger.ChangeSceneTo("WinScreen");
            else
                SceneChanger.NextScene();
        }
    }
}
