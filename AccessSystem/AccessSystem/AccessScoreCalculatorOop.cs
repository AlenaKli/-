namespace AccessSystemSimple
{
    public class AccessScoreCalculatorOop
    {
        public int CalculateScore(Role role, AccessContext context)
        {
            return role.GetAccess(context);
        }
    }
}