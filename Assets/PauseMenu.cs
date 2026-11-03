using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 100000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1)
            {
                transform.position = new Vector3(960, 540, 0);
                Time.timeScale = 0;
            }
            else
            {
                transform.position = new Vector3(0, 100000, 0);
                Time.timeScale = 1;
            }
        }
    }

    public void OpenMainMenu(int MenuIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MenuIndex);
    }
}
