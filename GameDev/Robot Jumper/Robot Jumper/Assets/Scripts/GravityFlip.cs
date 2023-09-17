using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    public float groundCheckDistance = 0.2f;
    public float floorCheckDistance = 0.2f;

    [SerializeField] private Transform floorCheck;
    [SerializeField] private LayerMask floorLayer;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (IsGrounded() || IsOnFloor()))
        {
            _rb.gravityScale *= -1;
        }
    }
    
    public bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, groundCheckDistance, groundLayer);
    
    public bool IsOnFloor() => Physics2D.OverlapCircle(floorCheck.position, floorCheckDistance,floorLayer);
}
