using UnityEngine;

public class Fish : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PickupFish();  
    }
    private void PickupFish()
    {
        anim?.SetTrigger("Pickup");
        GameStats.Instance.CollectFish();
        // Increment the fish count
        // Increment the score
        // Play sfx
        // Trigger an animation
    }
    public void OnShowChunk()
    {
        anim?.SetTrigger("Idle");
    } 
}
