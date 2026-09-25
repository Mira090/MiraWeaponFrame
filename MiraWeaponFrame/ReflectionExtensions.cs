using System;
using System.Collections.Generic;
using System.Text;

namespace MiraWeaponFrame
{
    public static class ReflectionExtensions
    {
        public static bool TryGetField<T>(this object instance, string name, out T result)
        {
            try
            {
                result = (T)instance.GetType().GetField(name).GetValue(instance);
                return true;
            }
            catch (Exception ex)
            {
                Core.LoggerError(ex);
                result = default;
                return false;
            }
        }
        public static bool TryGetStaticField<T>(this Type type, string name, out T result)
        {
            try
            {
                result = (T)type.GetField(name).GetValue(type);
                return true;
            }
            catch (Exception ex)
            {
                Core.LoggerError(ex);
                result = default;
                return false;
            }
        }
        public static bool TryGetProperty<T>(this object instance, string name, out T result)
        {
            try
            {
                var pros = instance.GetType().GetProperties();
                foreach (var pro in pros)
                {
                    //Core.Logger($"Property {pro.Name}");
                    if (pro.Name == name)
                    {
                        result = (T)pro.GetValue(instance);
                        return true;
                    }
                }
                Core.LoggerError($"No Property {name} in {(instance == null ? "null" : instance.GetType().Name)}");
                result = default;
                return false;
            }
            catch (Exception ex)
            {
                if (instance != null)
                    Core.Logger(instance.GetType().FullName);
                Core.LoggerError(ex);
                result = default;
                return false;
            }
        }
        public static bool TryGetStaticProperty<T>(this Type type, string name, out T result)
        {
            try
            {
                result = (T)type.GetProperty(name).GetValue(type);
                return true;
            }
            catch (Exception ex)
            {
                Core.LoggerError(ex);
                result = default;
                return false;
            }
        }
    }
}
