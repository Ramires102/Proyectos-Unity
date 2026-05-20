using UnityEngine;

public class Puerta_Estado : MonoBehaviour
{
    public UIManager UIManager;
    private Quaternion rotacionFinal;
    public float velocidad = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotacionFinal = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.puerta == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionFinal, velocidad * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, 0f), velocidad * Time.deltaTime);
        }
        
    }
}
