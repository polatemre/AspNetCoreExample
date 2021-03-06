using System.Reflection;

namespace ViewModelExample.Business.Reflection
{
    public static class TypeConversion
    {
        // TResult: Personel
        // T: PersonelCreateViewModel
        // gibi düşünebiliriz.
        public static TResult Conversion<T, TResult>(T model) where TResult : class, new()
        {
            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(p =>
            {
                PropertyInfo property = typeof(TResult).GetProperty(p.Name);
                property.SetValue(result, p.GetValue(model));
            });

            return result;
        }
    }
}
