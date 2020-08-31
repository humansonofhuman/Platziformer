using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public bool isLastLevel = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            if (isLastLevel)
                sceneChanger.ChangeSceneTo("WinScreen");
            else
                sceneChanger.NextScene();
        }
    }
}
