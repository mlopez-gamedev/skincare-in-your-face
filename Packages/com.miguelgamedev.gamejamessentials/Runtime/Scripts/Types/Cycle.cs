using UnityEngine.Assertions;

namespace MiguelGameDev
{
    public class Cycle
    {
        private int _value;
        private readonly int _minValue;
        private readonly int _maxValue;

        public int Value => _value;
        public bool IsFirst => _value == _minValue;
        public bool IsLast => _value == _maxValue;

        public Cycle(int minValue, int maxValue, int value = 0)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            Set(value);
        }

        public int Set(int value)
        {
            if (value < _minValue)
            {
                return CycleDown(value);
            }
            else if (value > _maxValue)
            {
                return CycleUp(value);
            }
            _value = value;
            return _value;
        }

        public int Next()
        {
            return Add(1);
        }

        public int Previous()
        {
            return Substract(1);
        }

        public int Add(int add)
        {
            if (add < 0)
            {
                return Substract(-add);
            }
            int nextValue = _value + add;
            return CycleUp(nextValue);
        }

        public int Substract(int substract)
        {
            if (substract < 0)
            {
                return Add(-substract);
            }
            int nextValue = _value - substract;
            return CycleDown(nextValue);
        }

        private int CycleUp(int nextValue)
        {
            Assert.IsTrue(nextValue >= _minValue);
            while (nextValue > _maxValue)
            {
                nextValue = _minValue + (nextValue - _maxValue) - 1;
            }

            _value = nextValue;
            return _value;
        }

        private int CycleDown(int nextValue)
        {
            Assert.IsTrue(nextValue <= _maxValue);
            while (nextValue < _minValue)
            {
                nextValue = _maxValue - (_minValue - nextValue) + 1;
            }

            _value = nextValue;
            return _value;
        }
    }
}

