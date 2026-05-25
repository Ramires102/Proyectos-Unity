using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sobolManager : MonoBehaviour
{
    [Header("scripts de objetos")]
    public bola bola_sobol;
    public PlayerSobol jugador;
    public Bate_sobol bate;

    [Header("Objetos en ecenario")]
    public GameObject lineaStrike;

    [Header("Prefabs")]
    public GameObject bolaPrefab;
    public GameObject playerPrefab;

    [Header("Spawner/posiciones de objetos")]
    public GameObject Spawner_Bola;

    public GameObject Posicion_Player;
    public GameObject Posicion_batear;
    public GameObject posicionRetirada;

    [Header("Textos")]
    public Text TextoStrike;
    public Text TextoBola;
    public Text TextoFuera;
    public Text TextoPuntos;

    public Text TextoHacerFuerza;

    public Text ContadorSalida;

    [Header("Listas")]
    public List<GameObject> bases;

    [Header("Contadores")]
    public int cant_strike = 0;
    public int bola = 0;
    public int puntos = 0;

    [Header("flotantes")]
    private float fuerzaGolpe = 0f;

    [Header("Estados")]
    public bool EnJuego = false;
    public bool BolaLanzada = false;
    public bool Strike = false;

    private bool Lanzado = false;
    private bool FuerzaLista = false;

    private bool movidoUnaVez = false;

    [Header("sliders")]
    public Slider fuerzaSlider;

    [Header("Controles")]
    [SerializeField] public KeyCode teclacorrer;
    [SerializeField] public KeyCode teclaAtras;
    [SerializeField]public KeyCode TeclaHacerFuerza;
    [SerializeField] public KeyCode teclaBatear;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPrefab = Instantiate(playerPrefab, Posicion_Player.transform.position, Quaternion.identity);
        playerPrefab.GetComponent<PlayerSobol>().velocidad = 20f;
        playerPrefab.GetComponent<PlayerSobol>().PoderMoverse = false;

        bate = FindAnyObjectByType<Bate_sobol>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!movidoUnaVez && playerPrefab != null)
        {
            playerPrefab.transform.position = Vector3.MoveTowards(
                playerPrefab.transform.position,
                bases[0].transform.position,
                5f * Time.deltaTime
            );

            if (Vector3.Distance(playerPrefab.transform.position, bases[0].transform.position) < 0.01f)
            {
                movidoUnaVez = true; 
            }
        }

        if (Strike == true)
        {
            StartCoroutine(Strike_Señal());
        }

        if (cant_strike == 3)
        {
            StartCoroutine(Fuera());
        }

        if (playerPrefab.GetComponent<PlayerSobol>().llegoBase)
        {
            StartCoroutine(PuntoPropio());
        }

        if (Lanzado && !FuerzaLista)
        {
            if (Input.GetKeyDown(TeclaHacerFuerza))
            {
                fuerzaGolpe += 35f * Time.deltaTime;
            }

            fuerzaGolpe -= 0.5f * Time.deltaTime;
            fuerzaGolpe = Mathf.Clamp(fuerzaGolpe, 0f, 5f);
            fuerzaSlider.value = fuerzaGolpe;
        }

        if (FuerzaLista)
        {
            bate.fuerzaGolpe = fuerzaGolpe;
            FuerzaLista = false;
        }

        TextoPuntos.text = "Puntos: " + puntos.ToString();
    }

    public void LanzarBola()
    {
        if (Lanzado) return;
        fuerzaGolpe = 0;
        bate.fuerzaGolpe = 0;
        StartCoroutine(Contadora());
    }

    IEnumerator Strike_Señal()
    {
        TextoStrike.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Strike = false;
        TextoStrike.gameObject.SetActive(false);
    }

    IEnumerator Fuera()
    {
        TextoFuera.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        TextoFuera.gameObject.SetActive(false);
    }

    IEnumerator Contadora()
    {
        Lanzado = true;
        ContadorSalida.gameObject.SetActive(true);

        TextoHacerFuerza.gameObject.SetActive(true);

        ContadorSalida.text = "3";
        yield return new WaitForSeconds(1f);

        ContadorSalida.text = "2";
        yield return new WaitForSeconds(1f);

        ContadorSalida.text = "1";
        yield return new WaitForSeconds(1f);

        FuerzaLista = true;
        TextoHacerFuerza.gameObject.SetActive(false);

        ContadorSalida.text = "YA";
        yield return new WaitForSeconds(1f);

        ContadorSalida.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        bola_sobol = Instantiate(bolaPrefab, Spawner_Bola.transform.position, Quaternion.identity).GetComponent<bola>();
        BolaLanzada = true;

        Lanzado = false;
    }

    IEnumerator PuntoPropio()
    {
        puntos++;
        playerPrefab.GetComponent<PlayerSobol>().llegoBase = false;
        playerPrefab.GetComponent<PlayerSobol>().PoderMoverse = true;

        yield return new WaitForSeconds(1f);

        playerPrefab.transform.position = Vector3.MoveTowards(
            playerPrefab.transform.position,
            posicionRetirada.transform.position,
            5f * Time.deltaTime
        );

        yield return null;
    }
}
