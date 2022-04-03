using UnityEngine.SceneManagement;
using UnityEngine;

public class HandleCollision : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject == Enemy)
        //{
            Debug.Log("You got caught");
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }
}
