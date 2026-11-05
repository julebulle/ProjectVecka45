using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject currentMenu;
    public static int levelToOpen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenu(GameObject menuToClose)
    {
        menuToClose.SetActive(false);
    }

    public void OpenMenu(GameObject menuToOpen)
    {
        CloseMenu(currentMenu);
        currentMenu = menuToOpen;
        menuToOpen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnterLevel(int LevelIndex)
    {
        SceneManager.LoadScene(1);
        levelToOpen = LevelIndex + 2;
    }
}
