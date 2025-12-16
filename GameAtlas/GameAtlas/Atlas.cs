using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleAtlas
{
    public class Atlas : IEnumerable<Location>
    {
        private List<Location> _locations;
        private Dictionary<string, Location> _byId;

        public int Count
        {
            get { return _locations.Count; }
        }

        public Atlas()
        {
            _locations = new List<Location>();
            _byId = new Dictionary<string, Location>();
        }

        // Индексатор по индексу
        public Location this[int index]
        {
            get
            {
                return _locations[index];
            }
        }

        // Индексатор по Id
        public Location this[string id]
        {
            get
            {
                return _byId[id];
            }
        }

        // Добавить локацию
        public void Add(Location location)
        {
            _locations.Add(location);
            _byId.Add(location.Id, location);
        }

        // Удалить по индексу
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _locations.Count)
                return false;

            Location location = _locations[index];
            _locations.RemoveAt(index);
            _byId.Remove(location.Id);

            return true;
        }

        // Удалить по Id
        public bool RemoveById(string id)
        {
            if (!_byId.ContainsKey(id))
                return false;

            Location location = _byId[id];
            _locations.Remove(location);
            _byId.Remove(id);

            return true;
        }

        // Ленивое перечисление по рангу
        public IEnumerable<Location> EnumerateByRank(RegionRank minRank)
        {
            foreach (Location location in _locations)
            {
                if (location.Rank >= minRank)
                {
                    yield return location;
                }
            }
        }

        // Для foreach
        public IEnumerator<Location> GetEnumerator()
        {
            return _locations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}