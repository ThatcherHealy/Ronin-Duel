using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    public float _jumpForce = 400f;                          // Amount of instantaneous force added when the player jumps.
    [Range(0, .3f)] public float _movementSmoothing = .05f;  // How much to smooth out the movement
    public bool _airControl = false;                         // Whether or not a player can steer while jumping;
    public LayerMask _whatIsGround;                          // A set of Physics Layers determining what is ground to the character
    public Transform _groundCheck;                           // A position marking where to check if the player is grounded.
    public float _topOfScreen = 10f;                         // Y-position of top of screen to spawn character if it falls
    public float _bottomOfScreen = -10f;                     // Y-position of bottom of screen to detect that the character has fallen
    public bool _facingRight = true;  // For determining which way the player is currently facing.
    public UnityEvent OnLandEvent;                           // A message to send when the player lands

    private const float GROUNDED_RADIUS = .2f; // Radius of the overlap circle to determine if grounded

    private bool _grounded;            // Whether or not the player is grounded.
    private Rigidbody2D _myRigidbody2D;
    private Vector3 _velocity = Vector3.zero;

    // Used to initialize the script
    private void Awake()
    {
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    /// <summary>
    /// Must be called in FixedUpdate()
    /// </summary>
    public void Move(float move, bool jump)
    {
        CheckGrounded();
        ApplyHorizontalMovement(move);
        ApplyVerticalMovement(jump);
    }

    private void CheckGrounded()
    {
        // The player is grounded if a circlecast at the groundcheck position hits anything designated as ground
        bool wasGrounded = _grounded;
        _grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, GROUNDED_RADIUS, _whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _grounded = true;
                if (!wasGrounded)
                    OnLandEvent?.Invoke();
            }
        }
    }

    private void ApplyHorizontalMovement(float move)
    {
        // Only control the player if grounded or airControl is turned on
        if (_grounded || _airControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, _myRigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            _myRigidbody2D.velocity = Vector3.SmoothDamp(_myRigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !_facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && _facingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
    }

    private void ApplyVerticalMovement(bool jump)
    {
        // Check if character has fallen
        if (transform.position.y < _bottomOfScreen)
        {
            transform.position = new Vector2(transform.position.x, _topOfScreen);
        }

        // If the player should jump...
        if (_grounded && jump)
        {
            // Add a vertical force to the player.
            _grounded = false;
            _myRigidbody2D.AddForce(new Vector2(0f, _jumpForce));
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _facingRight = !_facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}