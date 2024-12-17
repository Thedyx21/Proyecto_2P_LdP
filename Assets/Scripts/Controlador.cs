using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public int score; // Variable para almacenar el puntaje actual
    public Text textScore; // UI Text para mostrar el puntaje

    // Incrementa la puntuación
    public void AddScore()
    {
        score++;
        UpdateScoreUI(); // Actualiza la UI
    }

    // Resta puntos
    public void SubtractScore()
    {
        score--; // Disminuye el puntaje
        if (score < 0) 
        {
            score = 0; // Evita puntajes negativos
        }
        UpdateScoreUI(); // Actualiza la UI
    }

    // Método para actualizar la UI del puntaje
    private void UpdateScoreUI()
    {
        textScore.text = score.ToString(); // Actualiza el texto en pantalla
    }

    void Start()
    {
        UpdateScoreUI(); // Inicializa el texto del puntaje al inicio
    }
}
