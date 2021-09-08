using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orakeshi.ApocalypseZ.Lighting
{
    public class LightFlicker : MonoBehaviour
    {
        private float timeOn = 0.8f;
        private float timeOff = 0.6f;
        private float changeTime = 0f;

        private Light light;

        private void Start()
        {
            light = this.gameObject.GetComponent<Light>();
        }
        void Update()
        {
            if (Time.time > changeTime)
            {
                light.enabled = !light.enabled;
                if (light.enabled)
                {
                    changeTime = Time.time + timeOn;
                }
                else
                {
                    changeTime = Time.time + timeOff;
                }
            }
        }
    }
}

