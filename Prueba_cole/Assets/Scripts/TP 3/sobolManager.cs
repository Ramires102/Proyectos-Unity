using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sobolManager : MonoBehaviour
{
    [Header("Objetos en ecenario")]
    public bola bola_sobol;
    public PlayerSobol jugador;
    public GameObject lineaStrike;

    [Header("Prefabs")]
    public GameObject bolaPrefab;
    public GameObject playerPrefab;

    [Header("Spawner")]
    public GameObject Posicion_Bola;
    public GameObject Posicion_Player;
    public GameObject Posicion_batear;

    [Header("Textos")]
    public Text TextoStrike;
    public Text TextoBola;
    public Text TextoFuera;
    public Text TextoPuntos;

    public Text ContadorSalida;

    [Header("Listas")]
    public List<GameObject> bases;

    [Header("Contadores")]
    public int cant_strike = 0;
    public int bola = 0;
    public int puntos = 0;

    [Header("Estados")]
    public bool EnJuego = false;
    public bool BolaLanzada = false;
    public bool Strike = false;

    private bool Lanzado = false;
    private bool movidoUnaVez = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPrefab = Instantiate(playerPrefab, Posicion_Player.transform.position, Quaternion.identity);
        playerPrefab.GetComponent<PlayerSobol>().velocidad = 20f;
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

        TextoPuntos.text = "Puntos: " + puntos.ToString();
    }

    public void LanzarBola()
    {
        if (Lanzado) return;
        StartCoroutine(Contadora());
    }

    public void Punto()
    {
        if (playerPrefab.transform.position == bases[3].transform.position)
        {
            puntos++;
        }
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

        ContadorSalida.text = "3";
        yield return new WaitForSeconds(1f);

        ContadorSalida.text = "2";
        yield return new WaitForSeconds(1f);

        ContadorSalida.text = "1";
        yield return new WaitForSeconds(1f);

        ContadorSalida.text = "YA";
        yield return new WaitForSeconds(1f);

        ContadorSalida.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        bola_sobol = Instantiate(bolaPrefab, Posicion_Bola.transform.position, Quaternion.identity).GetComponent<bola>();
        BolaLanzada = true;

        Lanzado = false;
    }
}
