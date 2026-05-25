using System.Collections;
using UnityEngine;

public class bola : MonoBehaviour
{
    public sobolManager manager;
    public Bate_sobol bate;

    public Rigidbody rb;
    public float velocidadBola = 0.5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false;
        manager = FindAnyObjectByType<sobolManager>();
        bate = FindAnyObjectByType<Bate_sobol>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.BolaLanzada == true && bate.puedeBatear == false)
        {
            rb.AddForce(Vector3.forward * -velocidadBola);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == manager.lineaStrike)
        {
            manager.cant_strike++;
            manager.Strike = true;
            Destroy(gameObject);
        }
    }
}
