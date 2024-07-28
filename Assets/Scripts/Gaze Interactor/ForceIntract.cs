using UnityEngine;

public class ForceIntract : Intractable
{
    private Rigidbody rb;
    [SerializeField] private float power = 50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void OnRayHit(float timer)
    {
        base.OnRayHit(timer);
        rb.AddForce(Vector3.forward * power * Time.deltaTime, ForceMode.Impulse);
        
    }
}
