using UnityEngine;

public class GazeInteractor : MonoBehaviour
{
    [SerializeField] private float gazeDuration = 5f; // Duration to gaze before triggering OnRayHit
    private float gazeTimer;
    private Intractable _currentIntractableObj = null;
    private Intractable _lastIntractableObj = null;

    private void Awake()
    {
        //gazeTimer = gazeDuration;
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
                if (intractableObj != _lastIntractableObj)
                {
                    _currentIntractableObj = intractableObj;
                    _lastIntractableObj = _currentIntractableObj;
                    ResetGaze();
                }
                else
                {
                    // Continue gazing at the same object
                    gazeTimer -= Time.deltaTime;
                    if (gazeTimer <= 0f)
                    {
                        _lastIntractableObj.OnRayHit();
                        ResetGaze(); // Optionally reset gaze after triggering OnRayHit
                    }
                }
            }
        }
        else
        {
            if (_lastIntractableObj != null)
            {
                _lastIntractableObj.OnRayExit();
                ResetGaze();
                _lastIntractableObj = null;
            }
        }
    }

    private void ResetGaze()
    {
        gazeTimer = _lastIntractableObj.getTimer();
        _currentIntractableObj = null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
