using UnityEngine;
using UnityEngine.AI;

public class KnolWalkingBehavior : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    [SerializeField] private GameObject walkArea;

    private Vector2Range boundsX = default;
    private Vector2Range boundsZ = default;

    private NavMeshAgent navMeshAgent;

    private Vector3 dest;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        Renderer r = walkArea.GetComponent<Renderer>();
        float minX = walkArea.transform.position.x - (r.bounds.size.x / 2f);
        float maxX = walkArea.transform.position.x + (r.bounds.size.x / 2f);
        float minZ = walkArea.transform.position.z - (r.bounds.size.z / 2f);
        float maxZ = walkArea.transform.position.z + (r.bounds.size.z / 2f);

        Debug.Log("radius- " + navMeshAgent.radius);
        Debug.Log("minX" + minX + "maxX" + maxX + "minZ" + minZ + "maxZ" + maxZ);

        boundsX = new Vector2Range(minX, maxX);
        boundsZ = new Vector2Range(minZ, maxZ);

      //  movePositionTransform.position = new Vector3(maxX, 0f, maxZ);

        dest = RandomDestination();
    }
    void FixedUpdate()
    {
        if (dest != null)
        {
            navMeshAgent.destination = dest;

        }

        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance <= 0.5f)
        {
            dest = RandomDestination();
        }
    }

    Vector3 RandomDestination()
    {
        Vector3 dest = new Vector3(Random.Range(boundsX.min, boundsX.max), 0f, Random.Range(boundsZ.min, boundsZ.max));

        // movePositionTransform.position = dest;
        return dest;
    }
}

public class Vector2Range
{
    public float min;
    public float max;
    public Vector2Range(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}
