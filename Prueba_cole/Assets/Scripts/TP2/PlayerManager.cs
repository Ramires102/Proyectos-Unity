using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public ManagerPlayersTP2 manager;
    public float velocidadPlayer;
    public GameObject bara_propia;

    private int indice = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager.slider.value = velocidadPlayer;
        manager.baras.Add(bara_propia);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isbarasPropia == true)
        {
            transform.position = new Vector3(
            bara_propia.transform.position.x + velocidadPlayer,
            bara_propia.transform.position.y + velocidadPlayer,
            bara_propia.transform.position.z + velocidadPlayer
            );
        }

        if (manager.iscorrer == true)
        {
            indice++;
            transform.position = new Vector3(
                manager.baras[indice + 1].transform.position.x + velocidadPlayer,
                manager.baras[indice + 1].transform.position.y + velocidadPlayer,
                manager.baras[indice + 1].transform.position.z + velocidadPlayer
                );
        }

        indice = (indice + 1) % manager.baras.Count;
    }
}
