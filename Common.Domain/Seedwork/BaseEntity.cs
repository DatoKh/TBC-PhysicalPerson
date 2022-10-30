namespace Common.Domain.Seedwork
{
    public abstract class BaseEntity<T>
    {
        T _id;
        public virtual T Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }

        bool _isActive;
        public virtual bool IsActive
        {
            get
            {
                return _isActive;
            }
            protected set
            {
                _isActive = value;
            }
        }

        public void Delete()
        {
            IsActive = false;
        }
    }
}
