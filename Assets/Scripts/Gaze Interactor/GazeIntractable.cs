using UnityEngine;

public class GazeIntractable : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float power =50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void GazeHit()
    {
        rb.AddForce(Vector3.forward * power *Time.deltaTime, ForceMode.Impulse);
        Debug.Log('T');  }
}
