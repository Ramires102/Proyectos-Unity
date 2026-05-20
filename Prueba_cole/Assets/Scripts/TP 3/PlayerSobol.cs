using UnityEngine;
public class PlayerSobol : MonoBehaviour
{
    public sobolManager manager;
    public float velocidad;
    private int indiceActual = 0;
    private bool yendoAdelante = true;
    [Header("Controles")]
    [SerializeField] private KeyCode teclacorrer;
    [SerializeField] private KeyCode teclaAtras;

    void Start()
    {
        manager = FindAnyObjectByType<sobolManager>();
    }

    void Update()
    {
        if (manager.EnJuego == false) return;

        if (Input.GetKey(teclacorrer))
        {
            yendoAdelante = true;
            if (indiceActual < manager.bases.Count - 1)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    manager.bases[indiceActual + 1].transform.position,
                    velocidad * Time.deltaTime
                );
                if (Vector3.Distance(transform.position, manager.bases[indiceActual + 1].transform.position) < 0.01f)
                {
                    indiceActual++;
                }
            }
        }

        if (Input.GetKey(teclaAtras))
        {
            yendoAdelante = false;
            int baseAtras = yendoAdelante ? indiceActual : indiceActual;

            transform.position = Vector3.MoveTowards(
                transform.position,
                manager.bases[indiceActual].transform.position,
                velocidad * Time.deltaTime
            );
            if (Vector3.Distance(transform.position, manager.bases[indiceActual].transform.position) < 0.01f)
            {
                if (indiceActual > 0) indiceActual--;
            }
        }

        if (transform.position == manager.bases[4].transform.position)
        {
            manager.puntos++;
        }
    }
}