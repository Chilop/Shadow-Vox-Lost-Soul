using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterStatsLoader : MonoBehaviour
{
    public string statsUrl = "http://localhost:3000/stats";

    void Start()
    {
        StartCoroutine(LoadStats());
    }

    IEnumerator LoadStats()
    {
        UnityWebRequest request = UnityWebRequest.Get(statsUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al descargar stats: " + request.error);
            yield break;
        }

        string json = request.downloadHandler.text;
        CharacterStatsData data = JsonUtility.FromJson<CharacterStatsData>(json);

        // Aplicar stats al PlayerController
        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.speed = data.speed;
            controller.jumpForce = data.jumpForce;
        }

        // Aplicar stats al PlayerHealth
        PlayerHealth health = GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.maxHealth = data.maxHealth;
            // Reiniciar vida también
            typeof(PlayerHealth)
                .GetField("currentHealth", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(health, data.maxHealth);
        }

        Debug.Log("Stats aplicadas desde la API.");
    }

    [System.Serializable]
    public class CharacterStatsData
    {
        public float speed;
        public float jumpForce;
        public int maxHealth;
    }
}
