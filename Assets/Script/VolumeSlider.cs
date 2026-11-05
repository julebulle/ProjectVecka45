using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    static float currentVolume;
    [SerializeField] public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume()
    {
        currentVolume = GetComponent<Slider>().value;
        audioSource.volume = currentVolume;
        //audioSource.volume = GetComponent<Slider>().value;
    }
}
