using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypographyShopBusinessLogic.BusinessLogics;

namespace TypographyShopDatabaseImplement.Implements
{
    public class BackUpLogiс : BackUpAbstractLogic
    {
        protected override Assembly GetAssembly()
        {
            return typeof(BackUpLogiс).Assembly;
        }
        protected override List<PropertyInfo> GetFullList()
        {
            using (var context = new TypographyShopDatabase())
            {
                Type type = context.GetType();
                return type.GetProperties().Where(x => x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
            }
        }
        protected override List<T> GetList<T>()
        {
            using (var context = new TypographyShopDatabase())
            {
                return context.Set<T>().ToList();
            }
        }
    }
}
