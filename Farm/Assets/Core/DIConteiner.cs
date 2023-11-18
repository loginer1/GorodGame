using System;
using System.Collections.Generic;

namespace Assets.Core
{
    public class DiContainer
    {
        private Dictionary<Type, object> _dipendecy = new Dictionary<Type, object>();

        public void Register<T>(T instance)
        {
            _dipendecy.Add(typeof(T), instance);
        }

        public T Resolve<T>()
        {
            var type = typeof(T);

            if (_dipendecy.TryGetValue(type, out object resut))
                return (T)resut;
            throw new InvalidOperationException($"nema ({typeof(T)})");
        }
    }
}