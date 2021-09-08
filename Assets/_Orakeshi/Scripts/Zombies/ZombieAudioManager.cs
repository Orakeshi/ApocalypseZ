using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Zombie
{
    public class ZombieAudioManager : MonoBehaviour
    {
        AudioSource zombieSound;
        public AudioClip[] audioClips;

        private void Start()
        {
            if (gameObject.GetComponent<AudioSource>())
            {
                zombieSound = this.gameObject.GetComponent<AudioSource>();
                int randomTime = Random.Range(3, 5);
                
                InvokeRepeating("PlaySound", 0, randomTime);

            }
            else
            {
                return;
            }

        }

        void PlaySound()
        {
            int randomIdleAudio = Random.Range(0, audioClips.Length);
            this.GetComponent<AudioSource>().clip = audioClips[randomIdleAudio];
            zombieSound.Play();
        }
    }
}

