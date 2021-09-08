using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Orakeshi.ApocalypseZ.XR
{
    public class XRSocketInteractorTag : XRSocketInteractor
    {
        public string targetTag;

        public override bool CanSelect(XRBaseInteractable interactable)
        {
            return base.CanSelect(interactable) && interactable.CompareTag(targetTag);
        }
    }
}

