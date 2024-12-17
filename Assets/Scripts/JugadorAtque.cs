using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;  // Rango de ataque
    public int damageAmount = 1;      // Cantidad de daño por ataque
    public LayerMask enemyLayer;      // Capa de los enemigos
    
    private Animator animator;        // Referencia al Animator

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Método para llamar cuando el jugador ataca (puede ser llamado desde Input o AnimationEvent)
    public void Attack()
    {
        // Establece el trigger de ataque en el Animator
        animator.SetTrigger("Attack1");

        // Detecta enemigos en el rango de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            transform.position, 
            attackRange, 
            enemyLayer
        );

        // Daña a todos los enemigos en rango
        foreach (Collider2D enemy in hitEnemies)
        {
            // Intenta obtener el script de salud del enemigo
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }

    // Método opcional para visualizar el rango de ataque en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    void Update()
{
    if (Input.GetButtonDown("Fire1")) // Botón de ataque
    {
        Attack();
    }
}
}