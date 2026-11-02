using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseMenu(GameObject menuToClose)
    {
        menuToClose.SetActive(false);
    }

    public void OpenMenu(GameObject menuToOpen, GameObject currentMenu)
    {
        CloseMenu(currentMenu);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
