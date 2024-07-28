using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;

public class GazeInteractor : MonoBehaviour
{
    public float gazeTime = 2.0f; // Time required to gaze at a button to select it
    private float gazeCounter;
    private bool isGazing;
    private GameObject gazedObject;
    [SerializeField] private UnityEvent onGazeEvent;

    void Update()
    {
        // Check if the user is gazing at an object with a collider
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject != gazedObject)
            {
                gazedObject = hit.collider.gameObject;
                gazeCounter = 0;
                isGazing = true;
            }
            else
            {
                gazeCounter += Time.deltaTime;
                if (gazeCounter >= gazeTime)
                {
                    onGazeEvent?.Invoke();
                    gazeCounter = 0;
                    isGazing = false;
                }
            }
        }
        else
        {
            isGazing = false;
            gazeCounter = 0;
            gazedObject = null;
        }
    }
}
