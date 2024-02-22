using System;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine;

public interface IBaseScene
{
    public abstract void Init();
    public virtual void Exit()
    {
        GameManager.ResourceManager.UnloadUnusedAssets();
    }
}
public enum SceneState
{
    MainScene,
    LoadingScene,
    DungeonScene
    
}

public class SceneManagerEx
{
    private readonly IBaseScene[] _scenes = new IBaseScene[Enum.GetValues(typeof(SceneState)).Length];
    private IBaseScene _curScene;
    private IBaseScene _lateScene;
    private SceneState _curState = SceneState.MainScene;

    private void Awake()
    {
        SceneManager.sceneLoaded += ChangScene;
        for (int i = 0; i < _scenes.Length; i++)
        {
            Type type = Type.GetType(((SceneState)i).ToString());
            Assert.IsNotNull(type);
            _scenes[i] = (IBaseScene)Activator.CreateInstance(type);
        }
        _curScene = _scenes[0];
    }

    public void ChangeScene(SceneState state)
    {
        _lateScene = _curScene;
        _curScene = _scenes[(int)state];
        _curState = state;
        SceneManager.LoadScene((int)_curState);
    }

    private void ChangScene(Scene scene, LoadSceneMode mode)
    {
        _lateScene?.Exit();
        _curScene.Init();
    }
}