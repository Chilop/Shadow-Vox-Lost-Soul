using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida del jugador")]
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Método público para recibir daño
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Jugador recibió {amount} de daño. Vida restante: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
        // Aquí puedes añadir lógica para reiniciar nivel, desactivar input, etc.
        gameObject.SetActive(false); // ejemplo simple
    }

    // Método opcional para curarse
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log($"Jugador curado en {amount}. Vida actual: {currentHealth}");
    }

    // Método opcional para saber la vida actual
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
