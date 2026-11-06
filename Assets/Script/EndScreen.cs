using UnityEngine;
using UnityEngine.Timeline;

public class EndScreen : MonoBehaviour
{
    public TimelineAsset timeline;
    public FinalScore resultScreen;
    public AudioSource music;

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
        if(music != null) { music.Play(); }
        music.time += Time.deltaTime;
        StartCoroutine(resultScreen.AnimateResults());
        Time.timeScale = 0;
    }
}
