using Coherence;
using Coherence.Toolkit;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator animator;

    [field: Header("Inputs")] public Vector3 MoveInput { get; set; }
    public bool IsSprinting { get; set; }

    [Header("Horizontal movement")]
    public float movementSpeed = 8f;
    public float runMultiplier = 1.3f;
    public float rotationSpeed = 4f;
    public float acceleration = 2f;
    public float airAcceleration = .5f;
    public float deceleration = 8f;
    public float airDeceleration = 0;

    [Header("Jump")]
    public float weight = 2f;
    public float jumpLength = .5f; // time for a "full jump", releasing button within this time limits jump height
    public float jumpForce = 10;
    public float jumpCutOff = .25f; // when releasing button mid-jump, up-vel is multiplied by this value
    public float coyoteTime = .125f;
    public float maxFallSpeed = 1;

    [Header("Spring")]
    public float cruiseHeight = .5f;
    public float raycastLength = .8f;
    public float springStrength = 200f;
    public float dampenFactor = 20f;
    public LayerMask walkableLayers;

    private bool _isGrounded;
    private float _currentSpeed;
    private Rigidbody _rigidbody;
    private CoherenceSync _sync;
    private Vector3 _horizontalVelocity;
    private Vector3 _pushbackVelocity;
    private Vector3 _verticalVelocity;
    private Vector3 _springVector;
    private Vector3 _previousInputVector;
    private float _previousInputMagnitude;
    private float _timeSinceGrounded = 0;
    private float _jumpTimer = 0;
    private bool _isFalling = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sync = GetComponent<CoherenceSync>();
    }

    private void Update()
    {
        if (IsKinematic) return;
        UpdateJumping();
    }

    private void FixedUpdate()
    {
        if (IsKinematic)
        {
            UpdateAnimatorParameters();
            return;
        }

        Vector3 velocity = _rigidbody.linearVelocity;

        VerticalMovement(velocity);

        // Horizontal movement
        float inputMagnitude = MoveInput.magnitude;

        float inputAcceleration = inputMagnitude > _previousInputMagnitude
            ? _isGrounded ? acceleration : airAcceleration
            : _isGrounded
                ? deceleration
                : airDeceleration;

        Vector3 lerpedInputVector = Vector3.Lerp(_previousInputVector, MoveInput, Time.deltaTime * inputAcceleration);
        float lerpedMagnitude = lerpedInputVector.magnitude;

        // Reduce pushback (coming from hits or from crate throws)
        _pushbackVelocity *= .85f;

        _currentSpeed = IsSprinting ? movementSpeed * runMultiplier : movementSpeed;
        _horizontalVelocity = (lerpedInputVector + _pushbackVelocity) * _currentSpeed;

        // Caching for next frame
        _previousInputMagnitude = lerpedMagnitude;
        _previousInputVector = lerpedInputVector;

        // Cap vertical velocity when falling 
        if (_isFalling && _verticalVelocity.magnitude > maxFallSpeed)
            _verticalVelocity = _verticalVelocity.normalized * maxFallSpeed;

        // Apply both components to find final frame velocity
        _rigidbody.linearVelocity = _horizontalVelocity + _verticalVelocity;
        if (!_isGrounded) _verticalVelocity = Vector3.Project(_rigidbody.linearVelocity, Vector3.up);

        if (inputMagnitude > 0f)
        {
            Quaternion newRotation = Quaternion.LookRotation(MoveInput);
            transform.rotation = Quaternion.Lerp(_rigidbody.rotation, newRotation, Time.deltaTime * rotationSpeed);
        }

        UpdateAnimatorParameters();
    }
    
    public bool IsKinematic => _rigidbody.isKinematic;

    public void SetKinematic(bool toKinematic)
    {
        _rigidbody.isKinematic = toKinematic;
        if (toKinematic)
        {
            InterruptJump();
            _previousInputVector = Vector3.zero;
            _horizontalVelocity = Vector3.zero;
            _verticalVelocity = Vector3.zero;
            _isGrounded = true;
            _pushbackVelocity = Vector3.zero;
        }
    }

    private void VerticalMovement(Vector3 velocity)
    {
        // Vertical movement
        float rayLength = _isGrounded ? raycastLength : cruiseHeight;
        if (_jumpTimer > 0)
        {
            // Is jumping up
            ApplyGravity();
        }
        else
        {
            // Check for ground
            bool wasGrounded = _isGrounded;
            Ray ray = new(transform.position, Vector3.down);
            _isGrounded = Physics.Raycast(ray, out RaycastHit raycastHit, rayLength, walkableLayers,
                QueryTriggerInteraction.Ignore);
            if (_jumpTimer > 0)
                _isGrounded = false;

            if (_isGrounded)
            {
                // Ground spring
                float delta = raycastHit.distance - cruiseHeight;
                float spring = delta * springStrength - -velocity.y * dampenFactor;

                _springVector = spring * ray.direction;

                _verticalVelocity = Vector3.Lerp(_verticalVelocity, _springVector, Time.deltaTime * 20f);
                _timeSinceGrounded = 0;

                // Jump again if landing on a bouncy object
                Transform transformHit = raycastHit.transform;
                if (transformHit.CompareTag("Bouncy"))
                {
                    Jump();
                    if (transformHit.parent.TryGetComponent(out BouncyObject bo)) bo.GetJumpedOn();
                }
            }
            else
            {
                // Free falling
                if (wasGrounded) LeaveGround();
                ApplyGravity();
            }
        }
    }

    private void UpdateAnimatorParameters()
    {
        // This is used to blend between the Walk and Run animation clips in the Animator
        float animationSpeed = _horizontalVelocity.magnitude / _currentSpeed;
        if (IsSprinting) animationSpeed *= runMultiplier;

        animator.SetFloat("MoveSpeed", animationSpeed);
        animator.SetBool("Grounded", _isGrounded);
    }

    private void ApplyGravity()
    {
        _verticalVelocity += Vector3.up * (-weight * Time.deltaTime);
        _timeSinceGrounded += Time.deltaTime;
    }

    public void TryJump()
    {
        bool canJump = _isGrounded || _timeSinceGrounded < coyoteTime;
        if (!IsKinematic && canJump) Jump();
    }

    public void InterruptJump()
    {
        _jumpTimer = -1;
        _verticalVelocity *= jumpCutOff;
    }

    private void UpdateJumping()
    {
        if (_jumpTimer > 0)
        {
            _jumpTimer -= Time.deltaTime;
            if (_jumpTimer < 0f) InterruptJump();
        }

        _isFalling = !_isGrounded && Vector3.Dot(_rigidbody.linearVelocity, Vector3.up) < 0;
    }

    /// <summary>
    /// Invoked when a jump happens. This method is not invoked when dropping off high ground.
    /// </summary>
    public void Jump()
    {
        if (_isGrounded)
        {
            animator.SetTrigger("Jump");
            _sync.SendCommand<Animator>(nameof(Animator.SetTrigger), MessageTarget.Other, "Jump");
            // Animation will produce the sound
        }

        _jumpTimer = jumpLength;
        LeaveGround();

        _verticalVelocity = Vector3.up * jumpForce;
        Vector3 d = _rigidbody.linearVelocity;
        d -= Vector3.Project(d, Vector3.up);
        d += _verticalVelocity;
        _rigidbody.linearVelocity = d;
    }

    /// <summary>
    /// Invoked when jumping, but also when dropping off a high ground into the air.
    /// </summary>
    private void LeaveGround()
    {
        _isGrounded = false;
    }

    /// <summary>
    /// Returns a value to be used as a force when throwing objects. It points in the direction of movement,
    /// but only if moving forward. If moving backwards, it's zero.
    /// </summary>
    public float ThrowSpeed()
    {
        float throwSpeed = Vector3.Dot(transform.forward, _horizontalVelocity) * .8f;
        throwSpeed = Mathf.Clamp(throwSpeed, 0f, Mathf.Infinity);
        return throwSpeed;
    }

    /// <summary>
    /// Applies a pushback force to the player, coming from a throw or from a hit.
    /// The pushback is added on top of player input,
    /// and will fade in time over the course of a few frames.
    /// </summary>
    public void ApplyThrowPushback(float amount)
    {
        _pushbackVelocity += -transform.forward * amount * .7f;
    }
}