using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class SlenderManAI : MonoBehaviour
{
    public Transform player; // Reference to the player's GameObject
    public Transform enemy;
 
    public float teleportDistance = 10f; // Maximum teleportation distance
    public float teleportCooldown = 5f; // Time between teleportation attempts
    public float returnCooldown = 10f; // Time before returning to base spot
    [Range(0f, 1f)] public float chaseProbability = 0.65f; // Probability of chasing the player
    public float rotationSpeed = 50f; // Rotation speed when looking at the player
    public AudioClip teleportSound; // Reference to the teleport sound effect
    private AudioSource audioSource;

    public GameObject staticObject; // Reference to the "static" GameObject
    public float staticActivationRange = 8f; // Range at which "static" should be activated
    public float killDistance = 2f;//Kill Distance

    private Vector3 baseTeleportSpot;
    private float teleportTimer;
    private bool returningToBase;

    //Navmesh
    public float followRadius = 5f;
    private NavMeshAgent agent;

    //PageCount
    public GameLogic gameLogic;
    private void Start()
    {
        baseTeleportSpot = transform.position;
        teleportTimer = teleportCooldown;

        //get agent 
        agent = GetComponent<NavMeshAgent>();

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the teleport sound
        audioSource.clip = teleportSound;

        // Ensure the "static" object is initially turned off
        if (staticObject != null)
        {
            staticObject.SetActive(false);
        }

    }

    private void Update()
    {

        if (player == null)
        {

            return;
        }

        aggression();

        teleportTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (teleportTimer <= 0f)
        {
            if (returningToBase)
            {
                TeleportToBaseSpot();
                teleportTimer = returnCooldown;
                returningToBase = false;
            }
            else
            {
                DecideTeleportAction();
                teleportTimer = teleportCooldown;
            }
        }
        if (distance <= followRadius)
        {

            agent.SetDestination(player.position);
        }
        else
        {

            agent.ResetPath();
        }

        RotateTowardsPlayer();

        // Check player distance and toggle the "static" object accordingly
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= staticActivationRange)
        {
            if (staticObject != null && !staticObject.activeSelf)
            {
                staticObject.SetActive(true);
            }
        }
        else
        {
            if (staticObject != null && staticObject.activeSelf)
            {
                staticObject.SetActive(false);
            }
        }

        if (distance < killDistance)
        {
            // If the distance is too close, kill the player
            Kill();
        }
    }

    private void DecideTeleportAction()
    {
        float randomValue = Random.value;

        if (randomValue <= chaseProbability)
        {
            TeleportNearPlayer();
        }
        else
        {
            TeleportToBaseSpot();
        }
    }

    private void TeleportNearPlayer()
    {
        Vector3 randomPosition = player.position + Random.onUnitSphere * teleportDistance;
        randomPosition.y = transform.position.y; // Keep the same Y position
        transform.position = randomPosition;

        // Play the teleport sound
        audioSource.Play();
    }

    private void TeleportToBaseSpot()
    {
        transform.position = baseTeleportSpot;
        returningToBase = true;

        // Play the teleport sound
        audioSource.Play();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0f; // Ignore the vertical component

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void Kill()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("DEAD");
    }

    private void aggression()
    {
        if(gameLogic.pageCount == 0)
        {
            chaseProbability = 0;
            followRadius = 0;
        }
        else if(gameLogic.pageCount == 1)
        {
            chaseProbability = .1f;
            followRadius = 5f;
            teleportDistance = 30f;
            teleportCooldown = 30f;
        }
        else if (gameLogic.pageCount == 2)
        {
            chaseProbability = .25f;
            followRadius = 5.3f;
            teleportDistance = 28f;
            teleportCooldown = 28f;
        }
        else if (gameLogic.pageCount == 3)
        {
            chaseProbability = .35f;
            followRadius = 5.5f;
            teleportDistance = 25f;
            teleportCooldown = 25f;
        }
        else if (gameLogic.pageCount == 4)
        {
            chaseProbability = .4f;
            followRadius = 5.5f;
            teleportDistance = 23.5f;
            teleportCooldown = 23.5f;
        }
        else if (gameLogic.pageCount == 5)
        {
            chaseProbability = .5f;
            followRadius = 5.7f;
            teleportDistance = 22f;
            teleportCooldown = 18.5f;
        }
        else if (gameLogic.pageCount == 6)
        {
            chaseProbability = .65f;
            followRadius = 5.7f;
            teleportDistance = 20f;
            teleportCooldown = 15f;
        }
        else if (gameLogic.pageCount == 7)
        {
            chaseProbability = .8f;
            followRadius = 5.9f;
            teleportDistance = 15f;
            teleportCooldown = 10f;
        }
        else if (gameLogic.pageCount >= 8)
        {
            chaseProbability = 1f;
            followRadius = 6f;
            teleportDistance = 13f;
            teleportCooldown = 8f;
        }
    }
}