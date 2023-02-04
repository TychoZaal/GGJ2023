using UnityEngine;
using UnityEngine.AI;

public class KnolWalkingBehavior : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;

    private Vector2Range boundsX = default;
    private Vector2Range boundsZ = default;

    private NavMeshAgent navMeshAgent;

    private Vector3 dest;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameObject walkableArea = GameEnvironment.Instance.ground;
        Renderer r = walkableArea.GetComponent<Renderer>();
        float minX = walkableArea.transform.position.x - (r.bounds.size.x / 2f);
        float maxX = walkableArea.transform.position.x + (r.bounds.size.x / 2f);
        float minZ = walkableArea.transform.position.z - (r.bounds.size.z / 2f);
        float maxZ = walkableArea.transform.position.z + (r.bounds.size.z / 2f);

        //Debug.Log("radius- " + navMeshAgent.radius);
        //Debug.Log("minX" + minX + "maxX" + maxX + "minZ" + minZ + "maxZ" + maxZ);

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
