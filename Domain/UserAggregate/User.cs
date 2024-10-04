using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.BuildingBlocks.Domain.Exceptions;

namespace CBTPreparation.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Role Role { get; private set; }

    private User(UserId id,
                 string firstName,
                 string lastName,
                 string email,
                 string passwordHash,
                 Role role) : base(id)
    {
        InvalidEmailAddressException.Throw(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    public static User Create(string firstName, string lastName, string email, string password, string role)
    {
        var user = new User(UserId.CreateUniqueId(),
                            firstName,
                            lastName,
                            email,
                            password,
                            Role.Assign(role));
        return user;
    }
}
