using UnityEngine;
using System.Collections;

public class PickupBurst : MonoBehaviour {

    private ParticleSystem ps;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
