using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    [SerializeField] public Slider slider;
    [SerializeField] public AudioSource source;
    static float currentVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value -= 0.01f;
    }

    public void UpdateVolume()
    {
        currentVolume = slider.value;
        source.volume = currentVolume;
    }
}