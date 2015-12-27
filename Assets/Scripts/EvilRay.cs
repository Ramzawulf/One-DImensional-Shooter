#region



#endregion

namespace Assets.Scripts
{
    public class EvilRay : BaseRay
    {
        protected override void HeroHit()
        {
            Hero.Ctrl.ChangeScore(-2);
            Die();
        }
    }
}