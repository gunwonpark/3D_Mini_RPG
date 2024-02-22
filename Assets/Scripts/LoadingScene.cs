using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static string nextScene;

    [SerializeField]
    Image progressBar;
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
        Debug.Log("Hello");
    }
    
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                // 1초동안은 대기하게 한다
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(progressBar.fillAmount >= 1f)
                {
                    Debug.Log("1");
                    op.allowSceneActivation = true;
                    Debug.Log("2");
                    yield break;
                }
            }
        }
    }
}
