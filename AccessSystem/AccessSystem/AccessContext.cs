namespace AccessSystemSimple
{
    public class AccessContext
    {
        public bool HasTwoFactor { get; set; }
        public bool IsFromTrustedIP { get; set; }
        public bool IsSuspicious { get; set; }
    }
}