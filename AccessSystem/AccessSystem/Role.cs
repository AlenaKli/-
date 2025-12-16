namespace AccessSystemSimple
{
    public abstract class Role
    {
        private int basePoints;

        public int BasePoints
        {
            get { return basePoints; }
            set
            {
                if (value < 0)
                    value = 0;
                basePoints = value;
            }
        }

        protected Role(int points)
        {
            BasePoints = points;
        }

        public virtual int GetAccess(AccessContext context)
        {
            return BasePoints;
        }
    }
}