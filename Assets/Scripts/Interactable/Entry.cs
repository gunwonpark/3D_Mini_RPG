using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Entry : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshPro _text;
    // TODO 이름을 토대로 맵 생성 
    [SerializeField] private string _dungeonName;
    public void OnInteract()
    {
        LoadingScene.nextScene = "DungeonScene";
        GameManager.SceneManager.ChangeScene(SceneState.LoadingScene);
    }

    public void OnInteractionEnter()
    {
        _text.gameObject.SetActive(true);
    }

    public void OnInteractionExit()
    {
        _text.gameObject.SetActive(false);
    }
}
