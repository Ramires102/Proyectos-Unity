using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPlayersTP2 : MonoBehaviour
{

    public List<GameObject> baras;

    public Slider slider;

    public bool isbarasPropia = false;
    public bool iscorrer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.value = 1;
        slider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()       
    {

    }

    public void posiciones()
    {
        isbarasPropia = !isbarasPropia;
    }

    public void correr()
    {
        iscorrer = !iscorrer;
    }
}
