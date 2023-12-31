public class CharacterBody2D : MonoBehavior
{
    private const float SPEED = 500.0f;
    private const float JUMP_VELOCITY = -500.0f;
    private Sprite2D sprite_2d;
    private float gravity;

    private void Start()
    {
        // Initialization code goes here
    }

    private void Update()
    {
        // Your update logic goes here
    }

    private void _on_jump_button_pressed()
    {
        // Your jump logic goes here

        // Play the sound effect
        PlaySoundEffect();
    }

    private void _physics_process(float delta)
    {
        // Animations
        if (velocity.x > 1 || velocity.x < -1)
        {
            sprite_2d.animation = "running";
        }
        else
        {
            sprite_2d.animation = "default";
        }

        // Add the gravity.
        if (!is_on_floor())
        {
            velocity.y += gravity * delta;
            sprite_2d.animation = "jumping";
        }

        // Handle Jump.
        if (Input.GetButtonDown("Jump") && is_on_floor())
        {
            velocity.y = JUMP_VELOCITY;
        }

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        float direction = GetInputDirection();
        if (direction != 0)
        {
            velocity.x = direction * SPEED;
        }
        else
        {
            velocity.x = MoveToward(velocity.x, 0, 15);
        }

        MoveAndSlide();

        bool isLeft = velocity.x < 0;
        sprite_2d.flip_h = isLeft;
    }

    private void PlaySoundEffect()
    {
        // Implementation for playing the sound effect
    }

    private bool IsJumpButtonPressed()
    {
        // Implementation for checking if the jump button is pressed
        return Input.GetButtonDown("Jump");
    }

    private float GetInputDirection()
    {
        // Implementation for getting the input direction
        return Input.GetAxis("Horizontal");
    }
}