
using UnityEngine;

namespace Effects
{
    public enum ParticleEffect
    {
        TankExplosion,
        ShellExplosionOnGround,
        ShellExplosionOnTank
    }

    public class VFXService : MonoSingletonGeneric<VFXService>
    {
        [SerializeField]
        private VFXController ShellExplosionOnSand, ShellExplosionOnTank, TankExplosionEffect;

        public VFXController SetEffect(ParticleEffect type)
        {
            VFXController Effect = null;
            switch (type)
            {
                case ParticleEffect.ShellExplosionOnGround:
                   Effect = Instantiate(ShellExplosionOnSand);
                    break;
                case ParticleEffect.ShellExplosionOnTank:
                    Effect = Instantiate(ShellExplosionOnTank);
                    break;
                case ParticleEffect.TankExplosion:
                    Effect = Instantiate(TankExplosionEffect);
                    break;
            }
            return Effect;
        }
    }
}