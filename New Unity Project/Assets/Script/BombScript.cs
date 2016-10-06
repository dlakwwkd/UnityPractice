using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour 
{
    public GameObject groundExplosionParticle;
    public GameObject explosionParticle;
    public AudioClip clip;

    public void BombGround()
    {
        GameObject explosionParticleObj = Instantiate(groundExplosionParticle) as GameObject; // Cloning
        explosionParticleObj.transform.position = transform.position;
        Destroy(gameObject);
    }

    public void BombAir()
    {
        GameObject explosionParticleObj = Instantiate(explosionParticle) as GameObject; // Cloning
        explosionParticleObj.transform.position = transform.position;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("OnCollisionEnter : " + other.gameObject.name);

        if (other.gameObject.tag == "Ground")
            BombGround();
        else
            BombAir();

        AudioManager.instance.PlaySfx(clip);
    }
}
