using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFX
{
    CoinPickUp=0,
    TakeDamage=1,
    HeartPickUp=2,
    Jump=3,
    Death=4
}
public class AudioManger : MonoBehaviour
{
    public static AudioManger instnace;
    
    private AudioSource _audioSource;

    [SerializeField] private AudioClip[] sfxSounds;
    private void Awake()
    {
        instnace = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SFX soundFx)
    {
        _audioSource.clip = sfxSounds[(int) soundFx];
        _audioSource.Play();
    }
}
