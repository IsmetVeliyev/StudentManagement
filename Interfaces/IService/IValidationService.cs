using System.Web.Helpers;

namespace StudentManagement.Interfaces;

public interface IValidationService
{
    public Task<bool> validatedRequestValues(string authHeader);

}