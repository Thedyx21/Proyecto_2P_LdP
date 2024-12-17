using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar la escena
using UnityEngine.UI; // Si usas una UI para mostrar el tiempo

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60; // Tiempo inicial en segundos (1 minuto)
    public Text timerText; // Referencia al componente Text para mostrar el tiempo (opcional)

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Restar el tiempo
            if (timerText != null)
            {
                timerText.text = FormatTime(timeRemaining); // Actualizar el texto del temporizador
            }
        }
        else
        {
            RestartScene(); // Llamar a la función para reiniciar la escena
        }
    }

    // Formatear el tiempo en minutos y segundos
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Reiniciar la escena actual
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
