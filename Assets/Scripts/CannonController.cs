using System.Collections;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject Bullet;
    public Transform cannonGun;

    private IEnumerator shootCoroutine;

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            cannonGun.GetComponent<CannonGunController>().RotateRandomly();
            yield return new WaitForSeconds(1f);

            GameObject bullet = Instantiate(Bullet, cannonGun.TransformPoint(0.04f, 0.8f, 1.47f), new Quaternion());
            float shootForce = Random.Range(5, 15);
            Vector3 shootDirection = cannonGun.TransformDirection(new Vector3(0, 0, 1));

            bullet.GetComponent<Rigidbody>().AddForce(shootDirection * shootForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(shootDirection * -shootForce, ForceMode.Impulse);
        }
    }

    public void OnWatchStart()
    {
        cannonGun.GetComponent<CannonGunController>().Activate();
        shootCoroutine = Shoot();
        StartCoroutine(shootCoroutine);
    }

    public void OnWatchEnd()
    {
        cannonGun.GetComponent<CannonGunController>().Deactivate();
        StopCoroutine(shootCoroutine);
    }
}
