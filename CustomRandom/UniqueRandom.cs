using System;
using System.Collections.Generic;


namespace Math.CustomRandom
{
    public class UniqueRandom
    {
        private readonly int[] _array;

        private List<int> _list;

        private int _lastId, _nextId;

        private Random _random;

        public UniqueRandom(int min, int max)
        {
            if (min > max)
            {
                min = max;
            }

            _array = new int[max - min + 1];

            _list = new List<int>();

            for (var i = 0; i < _array.Length; i++)
            {
                _array[i] = min + i;
                _list.Add(i);
            }

            _random = new Random();

            _lastId = -1;
            _nextId = 0;
        }

        public int Next()
        {
            _lastId = _nextId;

            _nextId = GetRandomFromList();

            return _array[_nextId];
        }

        private int GetRandomFromList()
        {
            if (_list.Count == 0)
            {
                ResetList();
            }

            int randId = _lastId;

            if (_list.Count == 1)
            {
                randId = 0;
            }
            else
            {
                while (randId == _lastId)
                {
                    randId = _random.Next(0, _list.Count - 1);
                }
            }

            int value = _list[randId];
            _list.RemoveAt(randId);

            return value;
        }

        private void ResetList()
        {
            for (var i = 0; i < _array.Length; i++)
            {
                _list.Add(i);
            }
        }
    }
}
