using System.Text;

namespace Extensions
{
    public static class Int32Extensions
    {
        #region Methods

        /// <summary>
        /// Create timer string (for example: 07:58 | 245.25.05)
        /// </summary>
        /// <param name="seconds">time in seconds</param>
        /// <param name="separator">separator between digits</param>
        /// <param name="minDigitsNumber">min digits number in timer (2 = 00:00, 3 = 0:00:00)</param>
        /// <returns></returns>
        public static string AsTimer(this int seconds, char separator = ':', int minDigitsNumber = 2)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int hours = seconds / 3600;
            if (minDigitsNumber == 3 || hours > 0)
            {
                stringBuilder.Append(hours);
                seconds -= hours * 3600;
                stringBuilder.Append(separator);
            }
            
            if (minDigitsNumber == 2 || seconds / 60 > 0)
            {
                stringBuilder.Append($"{seconds / 60:00}");
                stringBuilder.Append(separator);
            }
            
            stringBuilder.Append($"{seconds % 60:00}");
            return stringBuilder.ToString();
        }

        #endregion
    }
}