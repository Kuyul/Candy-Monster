using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    public float speed = 2f;
    public float maxRotation = 45f;

    private float initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, initialRotation + maxRotation * Mathf.Sin(Time.time * speed));
    }
}
