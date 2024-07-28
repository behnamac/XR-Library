using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;
using System.Threading;

public class GazeInteractor : MonoBehaviour
{
    private float gazeTime = 5;
    private float currentTime;
    private Intractable _intractableObj = null;

    private void Awake()
    {
        currentTime = gazeTime;
    }
    void Update()
    {
        // Check if the user is gazing at an object with a collider
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Intractable intractableObj))
            {
                _intractableObj = intractableObj;
                currentTime -= Time.deltaTime;
                if (currentTime < 0)
                {
                    print("I have an object");
                    _intractableObj.OnRayHit(currentTime);
                    currentTime = gazeTime;
                }
            }
            else
            {
                _intractableObj.OnRayExit();
                _intractableObj = null;
                currentTime = gazeTime;
            }

        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
