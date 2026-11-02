using UnityEngine;
using UnityEngine.Timeline;

public class NoteSpawner : MonoBehaviour
{
    public TimelineAsset test;
    public GameObject notePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(test.duration.ToString());

        Instantiate(notePrefab, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
