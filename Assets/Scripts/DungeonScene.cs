using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonScene : MonoBehaviour
{
    private void Awake()
    {
        GameManager.ResourceManager.LoadGameObject("TestDungeon");
    }
}
