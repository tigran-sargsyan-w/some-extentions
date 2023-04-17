namespace Extensions
{
    public static class BooleanExtension
    {
        /// <summary>
        /// Inverts the value.
        /// </summary>
        public static bool ReverseValue(this bool value)
        {
            return !value;
        }
    }
}