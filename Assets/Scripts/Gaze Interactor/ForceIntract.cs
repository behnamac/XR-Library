using System.Collections;
using UnityEngine;

public class ForceIntract : Intractable
{
    private Rigidbody rb;
    [SerializeField] private float power = 50;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public override void OnRayHit()
    {
        base.OnRayHit();
        rb.AddForce(Vector3.forward * power * Time.deltaTime, ForceMode.Impulse);
   }
}
