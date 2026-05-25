using UnityEngine;
using UnityEngine.UI;

public class Bate_sobol : MonoBehaviour
{
    public sobolManager manager;

    public float fuerzaGolpe = 0f;
    public Vector3 direccionGolpe = new Vector3(0f, 1f, 1f);

    public bool puedeBatear = false;

    private void Start()
    {
        manager = FindAnyObjectByType<sobolManager>();

        Slider sliderFuerza = GameObject.Find("Potencia de bateo").GetComponent<Slider>();

        sliderFuerza.value = fuerzaGolpe;
    }

    void Update()
    { 
        if (Input.GetKeyDown(manager.teclaBatear))
        {
            puedeBatear = true;
            Batear();
        }
    }

    void Batear()
    {
        bola bolita = FindAnyObjectByType<bola>();

        if (bolita != null && puedeBatear)
        {
            bolita.rb.isKinematic = false;
            bolita.rb.useGravity = true;
            bolita.rb.linearVelocity = Vector3.zero;
            bolita.rb.AddForce(direccionGolpe.normalized * fuerzaGolpe, ForceMode.Impulse);
        }

    }
}

