using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    private bool canRotate = false;
    private XRBaseInteractable interactable;

    private void OnEnable()
    {
        interactable = GetComponentInParent<XRBaseInteractable>();
        interactable.activated.AddListener(ActiveRotatation);
        interactable.deactivated.AddListener(DeactiveRotation);
    }

    private void OnDisable()
    {
        interactable = GetComponentInParent<XRBaseInteractable>();
        interactable.activated.RemoveListener(ActiveRotatation);
        interactable.deactivated.RemoveListener(DeactiveRotation);
    }

    private void Update()
    {
        Rotate();
    }

    private void ActiveRotatation(ActivateEventArgs arg0)
    {
        canRotate = true;
    }

  
    private void DeactiveRotation(DeactivateEventArgs arg0)
    {
        canRotate = false;
    }



    private void Rotate()
    {
        if (!canRotate) return;
        transform.Rotate((Vector3.forward * speed) * Time.deltaTime);
    }

}
