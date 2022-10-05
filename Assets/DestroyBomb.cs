using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public GameObject bomb;
    //public GameObject hitEffect;
    public float bombLifeTime;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameObject newbomb = Instantiate(bomb, transform.position, Quaternion.identity);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 5f);
            Destroy(newbomb, bombLifeTime);
            Destroy(gameObject);

        }
    }
}
