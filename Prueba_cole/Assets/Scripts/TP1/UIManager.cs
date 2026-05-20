using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool pausa = false;
    public bool puerta = false;

    public void pausas()
    {
        pausa = !pausa;
    }

    public void Estado_Puerta()
    {
        puerta = !puerta;
    }

    private void Update()
    {
        if (pausa == false)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
