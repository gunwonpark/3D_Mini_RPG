using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonScene : MonoBehaviour
{
    private GameObject _player;
    private void Awake()
    {
        Debug.Log("3");
        GameManager.ResourceManager.LoadGameObject("TestDungeon");
        // TODO ���� StartScene���� ������ �÷��̾�� ����
        _player = MainScene._player;
        Debug.Log("4");
    }
}
