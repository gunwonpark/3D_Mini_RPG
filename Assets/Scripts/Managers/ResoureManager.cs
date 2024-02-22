using UnityEngine;
using UnityEngine.Assertions;
using System;

public class ResourceManager
{
    public GameObject LoadGameObject(string path)
    {
        var obj = Resources.Load<GameObject>(path);
        Assert.IsNotNull(obj, $"Prefab Load Faill : {path}");
        GameObject result = GameObject.Instantiate(obj);
        return result;
    }

    public GameObject LoadGameObject(string path, Transform parent)
    {
        var obj = Resources.Load<GameObject>(path);
        Assert.IsNotNull(obj, $"Prefab Load Faill : {path}");
        GameObject result = GameObject.Instantiate(obj, parent);
        return result;
    }

    public void UnloadUnusedAssets()
    {
        Resources.UnloadUnusedAssets();
    }
}
