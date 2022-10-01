using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Aquarius"))
        {
            //puan verilecek
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            GameManager.Instance.BallEntared();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            GameManager.Instance.BallWrongTarget();
        }
    }
}
