using UnityEngine;
using UnityEngine.AI;
public class CarController : MonoBehaviour
{
    private Camera _mainCamera;
    
    public GameManager gameManager;

    public Transform destination;

    public double lowLimit;
    
    private NavMeshAgent _agent;

    private bool _check;

    private void Start()
    {
        lowLimit = 1E-10;
        _agent = GetComponent<NavMeshAgent>();
        _agent.isStopped = true;
        _check = false;
    }

    private void Update()
    {
        var rb = GetComponent<Rigidbody>();
        if (_check && (Mathf.Abs(rb.velocity.x) < lowLimit && Mathf.Abs(rb.velocity.z) < lowLimit))
        {
            Fail();
            _check = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered " + other.gameObject.name);
        if (other.CompareTag("Finish"))
        {
            _check = false;
            Complete();
        }
        else if (other.CompareTag("Fail"))
        {
            Fail();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with: " + other.gameObject);
        if (other.collider.CompareTag("Finish"))
        {
            _check = false;
            Complete();
        }
        else if (other.collider.CompareTag("Fail"))
        {
            Fail();
        }
        else if (other.collider.CompareTag("Piece"))
        {
            _check = true;
        }
    }

    public void SetOwnDestination()
    {
        if (_agent.SetDestination(destination.position))
        {
            Debug.Log("Run to: " + _agent.destination);
        }
        else
        {
            Debug.Log("Stoop");
        }
    }
    
    private void Fail()
    {
        _agent.isStopped = true;
        gameManager.FailLevel();
    }
    
    private void Complete()
    {
        _agent.isStopped = true;
        gameManager.CompleteLevel();
    }
}
