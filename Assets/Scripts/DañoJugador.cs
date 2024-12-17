using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vida máxima del jugador
    private int currentHealth; // Vida actual del jugador
    
    private Animator animator; // Referencia al Animator del jugador

    void Start()
    {
        // Inicializa la salud al máximo cuando el juego comienza
        currentHealth = maxHealth;
        
        // Obtiene el componente Animator
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // Reduce la vida del jugador
        currentHealth -= damage;
        
        // Reproduce la animación de daño
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Asegúrate de tener un trigger "hit" en tu Animator
        }
        
        // Comprueba si el jugador ha muerto
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Reproduce la animación de muerte
        if (animator != null)
        {
            animator.SetTrigger("Death"); // Asegúrate de tener un trigger "death" en tu Animator
        }
        
        // Desactiva el jugador o destruyelo
        gameObject.SetActive(false);
        // Opcional: Reiniciar nivel, mostrar pantalla de game over, etc.
    }

    public void OnEnemyKilled()
    {
        // Gana 1 de vida al matar un enemigo, sin exceder la vida máxima
        currentHealth = Mathf.Min(currentHealth + 1, maxHealth);
        
        // Opcional: Reproducir animación de curación o efecto de sonido
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Asegúrate de tener un trigger "heal" en tu Animator
        }
    }
}