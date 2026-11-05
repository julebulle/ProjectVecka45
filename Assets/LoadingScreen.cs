using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    float switchSceneTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switchSceneTimer += Time.deltaTime;
        if (switchSceneTimer > 5)
        {
            SceneManager.LoadScene(MenuManager.levelToOpen);
        }
    }
}
