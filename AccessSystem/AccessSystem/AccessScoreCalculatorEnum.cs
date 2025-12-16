namespace AccessSystemSimple
{
    public class AccessScoreCalculatorEnum
    {
        public int CalculateScore(UserRole role, AccessContext context)
        {
            int baseScore = 0;

            switch (role)
            {
                case UserRole.Viewer:
                    baseScore = 1;
                    break;
                case UserRole.Editor:
                    baseScore = 3;
                    break;
                case UserRole.Manager:
                    baseScore = 5;
                    break;
                case UserRole.Admin:
                    baseScore = 7;
                    break;
            }

            if (context.HasTwoFactor)
                baseScore += 1;

            if (context.IsFromTrustedIP)
                baseScore += 1;

            if (context.IsSuspicious)
                baseScore -= 2;

            if (baseScore < 0)
                baseScore = 0;

            return baseScore;
        }
    }
}