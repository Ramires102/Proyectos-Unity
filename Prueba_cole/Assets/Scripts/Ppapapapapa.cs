using UnityEngine;
using UnityEngine.UI;

public class Ppapapapapa : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;

    public float pa;
    public float pb;
    public float pb2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        escala_inservible();
        escala_t();
    }
    void escala_inservible()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(pa, pb, pb2);
    }
    void escala_t()
    {
        transform.localScale = new Vector3(
            slider4.value,
            slider4.value,
            slider4.value
            );
    }
}
