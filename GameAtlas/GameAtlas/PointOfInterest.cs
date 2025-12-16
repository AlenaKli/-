namespace SimpleAtlas
{
    public class PointOfInterest
    {
        public string Code { get; }
        public string Label { get; }
        public int Importance { get; }

        public PointOfInterest(string code, string label, int importance)
        {
            Code = code;
            Label = label;
            Importance = importance;
        }
    }
}