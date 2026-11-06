using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public static float currentVolume = 0.5f;
    [SerializeField] public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Slider>().value = currentVolume;
    }

    // Update is called once per frame
    void Update()
    {
        currentVolume = GetComponent<Slider>().value;
        audioSource.volume = currentVolume;
    }
}
