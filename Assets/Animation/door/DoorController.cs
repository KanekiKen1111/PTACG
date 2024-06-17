using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDoorState(bool open)
    {
        animator.SetBool("isOpen", open);
    }
}
