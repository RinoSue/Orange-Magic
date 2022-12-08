using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : MonoBehaviour
{
    [SerializeField]
    private float accel;

    private Rigidbody rb;

    //Transform myTransform = this.transform;

        // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * accel, ForceMode.Acceleration);   
    }
}
