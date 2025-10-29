namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string resourceType,string resourceID) 
    : Exception($"{resourceType} with ID: {resourceID} doesn't exist.")
{
    // used primary constructor syntax available in C# 12
}