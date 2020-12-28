using UnityEngine;


namespace Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class VFXController : MonoBehaviour
    {
        public void PlayEffect(Vector3 pos)
        {
            transform.position = pos;

            GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject,2f);
        }
    }
}