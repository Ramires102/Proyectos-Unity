using System.Collections;
using UnityEngine;

public class bola : MonoBehaviour
{
    public sobolManager manager;

    public Rigidbody rb;
    public float velocidadBola = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindAnyObjectByType<sobolManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.BolaLanzada == true)
        {
            rb.AddForce(Vector3.forward * -velocidadBola);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == manager.lineaStrike)
        {
            manager.cant_strike++;
            manager.Strike = true;
            Destroy(gameObject);
        }
    }
}
