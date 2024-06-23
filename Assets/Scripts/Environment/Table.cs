using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Table : MonoBehaviour, IUseable
{
    [SerializeField] private float itemMass;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private Rigidbody2D rigidBody2D;
    private bool itemUsed = false;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void UseItem()
    {
        if (!itemUsed)
        {
            // Get item collider bounds
            Bounds bounds = boxCollider2D.bounds;

            // Calculate closest point to player on collider bounds
            Vector3 closestPointToPLayer = bounds.ClosestPoint(GameManager.Instance.GetPlayer().GetPlayerPosition());

            // If player is to the right of the table the flip left
            if (closestPointToPLayer.x == bounds.max.x)
            {
                animator.SetBool(Settings.flipLeft, true);
            }
            // if player is to the left of the table then flip right
            else if (closestPointToPLayer.x == bounds.min.x)
            {
                animator.SetBool(Settings.flipRight, true);
            }
            // If the player is below the table then flip up
            else if (closestPointToPLayer.y == bounds.min.y)
            {
                animator.SetBool(Settings.flipUp, true);
            }
            else
            {
                animator.SetBool(Settings.flipDown, true);
            }

            // Set the layer to environment - bullets will now collide with the table
            gameObject.layer = LayerMask.NameToLayer("Environment");

            // Set the mass of the object to the specified amount so that the player can move the item 
            rigidBody2D.mass = itemMass;

            SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.tableFlip);

            itemUsed = true;
        }
    }
}

