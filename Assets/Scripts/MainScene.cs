using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    // ���� ĳ���� ���� ���� �����Ƿ� ���⿡�� Player �ӽ� ����
    public static GameObject _player;
    [SerializeField] private Vector3 _startPosition;
    void Start()
    {
         GameManager.ResourceManager.LoadGameObject("MainMap");
        _player = GameManager.ResourceManager.LoadGameObject("Player");
        _player.transform.position = _startPosition;

        Camera.main.GetComponent<CameraController>().SetTarget(_player.transform);
    }
}
