using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

public class Category
{
    public Category()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<Service> Services { get; set; }

    /*
    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
        Description = command.Description;
    }
    */
}