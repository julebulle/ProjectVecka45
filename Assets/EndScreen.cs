using UnityEngine;
using UnityEngine.Timeline;

public class EndScreen : MonoBehaviour
{
    public TimelineAsset timeline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0, 100000, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndLevel()
    {
        transform.position = new Vector3(960, 540, 0);
        Time.timeScale = 0;
    }
}
