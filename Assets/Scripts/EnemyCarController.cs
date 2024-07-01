using UnityEngine;

public class EnemyCarController : MonoBehaviour
{
    public float baseSpeed = 10f; // Velocidad base del veh�culo enemigo
    public float rotationSpeed = 5f; // Velocidad de rotaci�n del veh�culo enemigo
    public float speedIncreaseRate = 0.01f; // Incremento de velocidad (1% por segundo)

    private float currentSpeed; // Velocidad actual del enemigo
    private Transform playerCar; // Referencia al transform del auto del jugador
    private Rigidbody rb;
    private bool isPushed = false; // Bandera para saber si el enemigo ha sido empujado
    private float totalTime; // Tiempo total desde el inicio para controlar el aumento de velocidad

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true; // Asegurarse de que la gravedad est� habilitada
        rb.mass = 3000f; // Ajustar la masa seg�n sea necesario para la f�sica

        currentSpeed = baseSpeed;
        totalTime = 0f;

        // Buscar el auto del jugador por su etiqueta
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerCar = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta 'Player'. Aseg�rate de que el auto del jugador tenga esta etiqueta.");
        }
    }

    void FixedUpdate()
    {
        if (playerCar != null && !isPushed)
        {
            // Direcci�n hacia el auto del jugador
            Vector3 direction = (playerCar.position - transform.position).normalized;

            // Movimiento hacia adelante
            rb.velocity = transform.forward * currentSpeed;

            // Rotaci�n hacia el auto del jugador
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.fixedDeltaTime * rotationSpeed);
        }
    }

    void Update()
    {
        // Aumentar la velocidad gradualmente
        totalTime += Time.deltaTime;
        currentSpeed = baseSpeed * (1 + speedIncreaseRate * totalTime);
    }

    public void ApplyPush(Vector3 force)
    {
        isPushed = true;
        rb.AddForce(force, ForceMode.Impulse);
        Invoke("ResetPush", 0.5f); // Restablecer el movimiento despu�s de 0.5 segundos
    }

    private void ResetPush()
    {
        isPushed = false;
    }
}
