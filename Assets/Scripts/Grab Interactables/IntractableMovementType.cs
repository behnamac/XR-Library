using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IntractableMovementType : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private XRGrabInteractable interactable;

    private void Start()
    {
        if (!interactable)
            interactable = GetComponentInParent<XRGrabInteractable>();
        text.text = interactable.movementType.ToString();
    }
}
