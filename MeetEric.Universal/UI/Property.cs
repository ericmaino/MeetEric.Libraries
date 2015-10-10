using System;

namespace MeetEric.UI
{
    public class Property<T> : IProperty
    {
        private T _x;

        public Property(string name)
            : this(name, null)
        {
        }

        public Property(string name, IPropertyHost host)
        {
            IsEnabled = true;
            Name = name;

            if (host != null)
            {
                Changed += p =>
                {
                    if (p != null)
                    {
                        host.InvokePropertyChanged(p.Name);
                    }
                };
            }
        }

        public bool IsEnabled { get; set; }

        public virtual T Value
        {
            get { return _x; }
            set
            {
                var original = _x;
                _x = value;

                if (original == null || !original.Equals(value))
                {
                    Notify();
                }
            }
        }

        public string Name { get; }
        public event Action<IProperty> Changed;

        public virtual void Notify()
        {
            var changed = Changed;

            if (IsEnabled && changed != null)
            {
                changed(this);
            }
        }

        // define implicit Property<T>-to-T conversion operator:
        public static implicit operator T(Property<T> property)
        {
            if (property == null)
            {
                return default(T);
            }

            return property.Value;
        }

        public override string ToString()
        {
            string result = null;

            if (_x != null)
            {
                result = Value.ToString();
            }
            else
            {
                result = base.ToString();
            }

            return result;
        }
    }
}