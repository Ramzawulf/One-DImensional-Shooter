using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class FriendlyRay: EvilRay
    {
        public float Value = 5;

        protected override void HeroHit()
        {
            Hero.Ctrl.ChangeScore(Value);
            Die();
        }
    }
}
