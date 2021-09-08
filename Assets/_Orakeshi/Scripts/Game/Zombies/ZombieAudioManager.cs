using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Zombies
{
    [RequireComponent(typeof(AudioSource))]
    public class ZombieAudioManager : MonoBehaviour
    {
        private AudioSource zombieSound;
        public AudioClip[] audioClips;

        private void Start()
        {
            if (gameObject.GetComponent<AudioSource>())
            {
                zombieSound = this.gameObject.GetComponent<AudioSource>();
                int randomTime = Random.Range(3, 5);
                
                InvokeRepeating(nameof(PlaySound), 0, randomTime);

            }
            else
            {
                return;
            }

        }

        private void PlaySound()
        {
            int randomIdleAudio = Random.Range(0, audioClips.Length);
            this.GetComponent<AudioSource>().clip = audioClips[randomIdleAudio];
            zombieSound.Play();
        }
    }
}

