using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume = 1;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0, 1)] float damageVolume = 1;

    [SerializeField] AudioClip music;
    [SerializeField][Range(0, 1)] float musicVolume = 1;

    public static AudioManager instance;
    static public AudioManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;

        //if (instanceCount > 1) 
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);        
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    public void PlayDamageSFX()
    {
        PlayAudioClip(damageClip,damageVolume);
    }

    void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
