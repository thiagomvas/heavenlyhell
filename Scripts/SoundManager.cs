using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    AudioSource audioS;
    private float volume = 0.5f;
    [SerializeField] private Slider volSlider;

    [SerializeField] AudioClip purifySFX;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        audioS.volume = volume;
    }
    
    public void PlayPurify()
    {
        audioS.PlayOneShot(purifySFX);
    }
    public void UpdateVolume()
    {
        volume = volSlider.value;
    }

}
