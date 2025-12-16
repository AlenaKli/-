using System.Collections.Generic;

namespace SimpleAtlas
{
    public class Location
    {
        public string Id { get; }
        public string Name { get; }
        public RegionRank Rank { get; }

        private List<PointOfInterest> _pois;

        // Исправлено: нужно возвращать AsReadOnly()
        public IReadOnlyList<PointOfInterest> PointsOfInterest
        {
            get { return _pois.AsReadOnly(); }
        }

        public Location(string id, string name, RegionRank rank)
        {
            Id = id;
            Name = name;
            Rank = rank;
            _pois = new List<PointOfInterest>();
        }

        public void AddPoi(PointOfInterest poi)
        {
            _pois.Add(poi);
        }
    }
}