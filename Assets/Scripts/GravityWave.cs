using UnityEngine;

public class GravityWave : MonoBehaviour
{
    public float waveRadius = 5f; // Radio de la onda expansiva
    public float waveForce = 5000f; // Fuerza de la onda expansiva
    public float cooldownTime = 10f; // Tiempo de reutilización en segundos

    private float nextWaveTime = 0f; // Tiempo en el que se puede usar la siguiente onda expansiva

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextWaveTime)
        {
            GenerateGravityWave();
            nextWaveTime = Time.time + cooldownTime;
        }
    }

    void GenerateGravityWave()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, waveRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && nearbyObject.CompareTag("Enemy"))
            {
                Vector3 direction = (nearbyObject.transform.position - transform.position).normalized;
                rb.AddForce(direction * waveForce, ForceMode.Impulse);

                // Aplicar la fuerza usando el método ApplyPush del enemigo
                nearbyObject.GetComponent<EnemyCarController>().ApplyPush(direction * waveForce);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, waveRadius);
    }
}
