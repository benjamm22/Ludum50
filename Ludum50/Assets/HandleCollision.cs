using UnityEngine.SceneManagement;
using UnityEngine;

public class HandleCollision : MonoBehaviour
{
    public GameObject Ground;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != Ground)
        {
            Debug.Log("You got caught");
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
