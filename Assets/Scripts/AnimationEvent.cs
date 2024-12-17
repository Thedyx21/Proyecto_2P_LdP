using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemy;          // Referencia al enemigo
    public int damage = 10;           // Daño del ataque
    public float attackRange = 2f;    // Rango del ataque
    public float detectionRange = 5f; // Rango de detección del jugador
    public int health = 100;          // Vida del enemigo

    private Transform player;         // Referencia al jugador
    private Animator animator;        // Animator del enemigo
    private bool isAttacking = false; // Controla si está atacando
    private bool isChasing = false;   // Controla si está persiguiendo

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del rango de detección, persigue
        if (distanceToPlayer <= detectionRange && distanceToPlayer > attackRange)
        {
            ChasePlayer();
        }
        // Si el jugador está dentro del rango de ataque, ataca
        else if (distanceToPlayer <= attackRange && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
        else
        {
            StopChasing();
        }
    }

    void ChasePlayer()
    {
        if (!isChasing)
        {
            isChasing = true;
            animator.SetBool("Bat_Animation", true);
        }

        // Movimiento hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, player.position, 2f * Time.deltaTime);
    }

    void StopChasing()
    {
        if (isChasing)
        {
            isChasing = false;
            animator.SetBool("Bat_Animation", false);
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        animator.SetTrigger("Bat_Animation"); // Inicia animación de ataque

        yield return new WaitForSeconds(0.5f); // Espera que termine la animación

        // Si el jugador está en rango, reinicia la escena directamente
        if (player != null && Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            PlayerDeath();
        }

        isAttacking = false;
    }

    void PlayerDeath()
    {
        Debug.Log("El jugador ha sido destruido. Reiniciando la escena...");
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
