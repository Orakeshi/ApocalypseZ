using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Game.Lighting
{
    [RequireComponent(typeof(Light))]
    public class LightFlicker : MonoBehaviour
    {
        private const float TimeOn = 0.8f;
        private const float TimeOff = 0.6f;
        private float changeTime = 0f;

        private new Light light;

        private void Start()
        {
            light = this.gameObject.GetComponent<Light>();
        }

        private void Update()
        {
            if (Time.time > changeTime)
            {
                light.enabled = !light.enabled;
                if (light.enabled)
                {
                    changeTime = Time.time + TimeOn;
                }
                else
                {
                    changeTime = Time.time + TimeOff;
                }
            }
        }
    }
}

