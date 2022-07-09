using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeScheduler.Data.Database;
using System.ComponentModel.DataAnnotations;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.Data.Helpers;

/*
The static class AudiTrailHelper inserts records on AuditTrail table 
which have to do with any changes (creation or update) on entities Employee and Skill.

For that reason, I created a static class which will work for both entities (or any other entity that may be created in the future)
which contains only one method which does nothing but create audit trail record and add it to the database.

I could use the repository pattern just like I did with Employee and Skill but since I only want to insert records regarding any change that may
have occured and I want to work with multiple models, I created for that reason a static class with a static method that does the following: 
-using reflection I retrieve the type, the key and its value of the type. 
-I retrieve the data of each entity by using method ToString() which is overriden on each entity to receive the details of the entity.
-using the DbContext I insert an AuditTrail records on the database. 
*/
public static class AuditTrailHelper<T>
{
    public static async Task AddAuditTrailRecordAsync(T entity, string action, DataContext dataContext)
    {
        string type = typeof(T).Name;
        string entityIDValue = string.Empty;
        string data = entity.ToString();
        var properties = typeof(T).GetProperties().ToList();

        foreach (var property in properties) 
        {
            if (property.GetCustomAttributesData().Any()) {

                var attributes = property.GetCustomAttributesData().Where(x => x.AttributeType.Name == typeof(KeyAttribute).Name).ToList();

                if (attributes.Any()) 
                {
                    entityIDValue = entity.GetType().GetProperty(property.Name).GetValue(entity, null).ToString();
                    break;
                }
            } 
        }

        await dataContext.AuditTrails.AddAsync(new AuditTrail(type, entityIDValue, action, data));
    }   
}

