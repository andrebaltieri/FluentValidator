namespace FluentValidator.Validation
{
    public partial class ValidationContract
    {
        #region IsGreaterThan
        public ValidationContract IsGreaterThan(decimal val, long comparer, string property, string message)
        {
            if ((double)val <= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterThan(double val, long comparer, string property, string message)
        {
            if (val <= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterThan(float val, long comparer, string property, string message)
        {
            if (val <= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterThan(int val, long comparer, string property, string message)
        {
            if (val <= comparer)
                AddNotification(property, message);

            return this;
        }
        #endregion

        #region IsGreaterOrEqualsThan
        public ValidationContract IsGreaterOrEqualsThan(decimal val, long comparer, string property, string message)
        {
            if ((double)val < comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterOrEqualsThan(double val, long comparer, string property, string message)
        {
            if (val < comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterOrEqualsThan(float val, long comparer, string property, string message)
        {
            if (val < comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsGreaterOrEqualsThan(int val, long comparer, string property, string message)
        {
            if (val < comparer)
                AddNotification(property, message);

            return this;
        }
        #endregion

        #region IsLowerThan
        public ValidationContract IsLowerThan(decimal val, long comparer, string property, string message)
        {
            if ((double)val >= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerThan(double val, long comparer, string property, string message)
        {
            if (val >= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerThan(float val, long comparer, string property, string message)
        {
            if (val >= comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerThan(int val, long comparer, string property, string message)
        {
            if (val >= comparer)
                AddNotification(property, message);

            return this;
        }
        #endregion

        #region IsLowerOrEqualsThan
        public ValidationContract IsLowerOrEqualsThan(decimal val, long comparer, string property, string message)
        {
            if ((double)val > comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerOrEqualsThan(double val, long comparer, string property, string message)
        {
            if (val > comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerOrEqualsThan(float val, long comparer, string property, string message)
        {
            if (val > comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsLowerOrEqualsThan(int val, long comparer, string property, string message)
        {
            if (val > comparer)
                AddNotification(property, message);

            return this;
        }
        #endregion

        #region AreEquals
        public ValidationContract AreEquals(decimal val, long comparer, string property, string message)
        {
            if ((double)val != comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreEquals(double val, long comparer, string property, string message)
        {
            if (val != comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreEquals(float val, long comparer, string property, string message)
        {
            if (val != comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreEquals(int val, long comparer, string property, string message)
        {
            if (val != comparer)
                AddNotification(property, message);

            return this;
        }
        #endregion

        #region AreNotEquals
        public ValidationContract AreNotEquals(decimal val, long comparer, string property, string message)
        {
            if ((double)val == comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreNotEquals(double val, long comparer, string property, string message)
        {
            if (val == comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreNotEquals(float val, long comparer, string property, string message)
        {
            if (val == comparer)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract AreNotEquals(int val, long comparer, string property, string message)
        {
            if (val == comparer)
                AddNotification(property, message);

            return this;
        }
        #endregion

        #region Between      
        public ValidationContract IsBetween(long val, long from, long to, string property, string message)
        {
            if (!(val > from && val < to))
                AddNotification(property, message);

            return this;
        }
        #endregion
    }
}
