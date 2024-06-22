using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // spawn gamobject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        // assign audioclip
        audioSource.clip = audioClip;

        // assign volume
        audioSource.volume = volume;

        // play clip
        audioSource.Play();

        // clip length
        float clipLemgth = audioSource.clip.length;

        // destroy self
        Destroy(audioSource.gameObject, clipLemgth);
    }
}
