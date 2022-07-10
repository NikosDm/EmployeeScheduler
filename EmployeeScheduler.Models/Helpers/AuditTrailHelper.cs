using System.ComponentModel.DataAnnotations;
using EmployeeScheduler.Models.Entities;

namespace EmployeeScheduler.Models.Helpers;

/*
The static class AudiTrailHelper creates AuditTrail entities
which have to do with any changes (creation or update) on entities Employee and Skill.

Since I want to work with multiple entities (in that case two entities), I created a static class 
with a static method that creates AuditTrail instances depending on the type that is given. More specifically: 
-using reflection I retrieve the type, the key and its value of the type. 
-I retrieve the data of each entity by using method ToString() which is overriden on each entity to receive the details of the entity.
-having gathered all the data I create and return an instance of AuditTrail.
*/
public static class AuditTrailHelper<T>
{
    public static async Task<AuditTrail> AddAuditTrailRecordAsync(T entity, string action)
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

        return await Task.FromResult(new AuditTrail(type, entityIDValue, action, data));
    }   
}

