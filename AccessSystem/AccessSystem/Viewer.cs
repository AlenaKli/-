namespace AccessSystemSimple
{
    public class Viewer : Role
    {
        public Viewer() : base(1) { }

        public override int GetAccess(AccessContext context)
        {
            int score = BasePoints;

            if (context.HasTwoFactor)
                score += 1;

            if (context.IsFromTrustedIP)
                score += 1;

            if (context.IsSuspicious)
                score -= 2;

            if (score < 0)
                score = 0;

            return score;
        }
    }
}