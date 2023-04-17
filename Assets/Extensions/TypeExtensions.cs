using System;

namespace Extensions
{
    public static class TypeExtensions
    {
        #region Methods

        public static bool HasInterface<TInterface>(this Type currentType)
        {
            Type interfaceType = typeof(TInterface);
            Type[] interfaces = currentType.GetInterfaces();
            for (int i = 0; i < interfaces.Length; i++)
                if (interfaces[i] == interfaceType) return true;
            return false;
        }

        #endregion
    }
}