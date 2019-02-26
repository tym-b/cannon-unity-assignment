using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject Bullet;
    private Transform cannonGun;
    private IEnumerator shootCoroutine;

    void Awake()
    {
        cannonGun = transform.Find("CannonGun");
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            cannonGun.GetComponent<CannonGunRotator>().RotateRandomly();
            yield return new WaitForSeconds(1f);

            GameObject bullet = Instantiate(Bullet, cannonGun.TransformPoint(0.04f, 0.8f, 1.47f), new Quaternion());
            float shootForce = Random.Range(15, 30);
            Vector3 shootDirection = cannonGun.TransformDirection(new Vector3(0, 0, 1));

            bullet.GetComponent<Rigidbody>().AddForce(shootDirection * shootForce, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(shootDirection * -shootForce, ForceMode.Impulse);
        }
    }

    public void OnWatchStart()
    {
        cannonGun.GetComponent<CannonGunRotator>().Activate();
        shootCoroutine = Shoot();
        StartCoroutine(shootCoroutine);
    }

    public void OnWatchEnd()
    {
        cannonGun.GetComponent<CannonGunRotator>().Deactivate();
        StopCoroutine(shootCoroutine);
    }
}
