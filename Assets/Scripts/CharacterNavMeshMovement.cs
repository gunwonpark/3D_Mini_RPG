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

        // agentPosition와의 동기화를 막아준다
        _agent.updatePosition = false;
        _agent.updateRotation = true;

        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 월드 위치로 표시
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            // rayHit 확인
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, groundLayerMask))
            {
                // 목표 지점을 세팅한다
                _agent.SetDestination(hit.point);
            }
        }

        // 현재 위치와 목표 위치와의 거리를 확인
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
