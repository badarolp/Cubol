using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Menu movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "ZonaVermelha")
        {
            // movement.gameHasEnded = true;
            movement.enabled = false;
            FindObjectOfType<GameManager>().TenteNovamente();

        } 
        else if (collisionInfo.collider.tag == "End")
        {
            FindObjectOfType<GameManager>().Parabens();
        }
    }
}
