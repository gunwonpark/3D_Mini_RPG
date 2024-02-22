using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    // 현재 캐릭서 선택 씬이 없으므로 여기에서 Player 임시 생성
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
