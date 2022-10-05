using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    public Transform firePoint;
    public float bombForce;
    public float spawnTime;

    public void startCausticBomb()
    {
        StartCoroutine(CausticBombCorutine());
    }
    private IEnumerator CausticBombCorutine()
    {
        while (true)
        {
            firePoint.rotation = Quaternion.Euler(new Vector3(-32f, Random.Range(0f, 360f), 0));
            GameObject newBomb = Instantiate(bomb, firePoint.position, firePoint.rotation);
            Rigidbody rb = newBomb.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bombForce, ForceMode.Impulse);
            yield return new WaitForSeconds(spawnTime);      
        }
    }

}
