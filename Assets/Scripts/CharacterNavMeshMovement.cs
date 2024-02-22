using UnityEngine;
using UnityEngine.AI;

public class CharacterNavMeshAgentMovement : MonoBehaviour
{
    #region Variables
    public LayerMask groundLayerMask;
    //public Animator animator;

    private CharacterController _characterController;
    private NavMeshAgent _agent;
    private Camera _camera;

    //readonly int moveHash = Animator.StringToHash("Move");
    #endregion

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _agent = GetComponent<NavMeshAgent>();

        // agentPosition���� ����ȭ�� �����ش�
        _agent.updatePosition = false;
        _agent.updateRotation = true;

        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� ���� ��ġ�� ǥ��
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            // rayHit Ȯ��
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, groundLayerMask))
            {
                // ��ǥ ������ �����Ѵ�
                _agent.SetDestination(hit.point);
            }
        }

        // ���� ��ġ�� ��ǥ ��ġ���� �Ÿ��� Ȯ��
        if (_agent.remainingDistance > _agent.stoppingDistance)
        {
            _characterController.Move(_agent.velocity * Time.deltaTime);
            //animator.SetBool(moveHash, true);
        }
        else
        {
            _characterController.Move(Vector3.zero);
            //animator.SetBool(moveHash, false);
        }

        transform.position = _agent.nextPosition;
    }
}
