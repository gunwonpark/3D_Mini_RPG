using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    private static GameManager _instance { get { Init();  return s_instance; } }

    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    public static ResourceManager ResourceManager { get { return _instance._resource; } }   
    public static SceneManagerEx SceneManager { get { return _instance._scene; } }

    
    private void Awake()
    {
        Init();
    }
    private static void Init()
    {
        if(s_instance == null)
        {
            GameObject manager = GameObject.Find("@Managers");
            if(manager == null)
            {
                manager = new GameObject("@Managers");
                manager.AddComponent<GameManager>();
            }
            s_instance = manager.GetComponent<GameManager>();
            DontDestroyOnLoad(s_instance);
        }
    }
}
