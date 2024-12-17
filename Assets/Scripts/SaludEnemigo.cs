using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private Animator animator;

    // Nombre de la escena a la que quieres cambiar
    public string nextSceneName = "SiguienteNivel";

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Reproduce animación de daño
        if (animator != null)
        {
            animator.SetTrigger("hit_1");
        }

        // Comprueba si el enemigo debe morir
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Reproduce animación de muerte
        if (animator != null)
        {
            animator.SetTrigger("death");
        }

        // Inicia la corutina para cambiar de escena
        StartCoroutine(ChangeSceneAfterDeath());
    }

    System.Collections.IEnumerator ChangeSceneAfterDeath()
    {
        // Espera 2 segundos
        yield return new WaitForSeconds(1f);

        // Cambia a la siguiente escena
        SceneManager.LoadScene(nextSceneName);
    }
}