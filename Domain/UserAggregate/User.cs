using CBTPreparation.BuildingBlocks.Domain;
using CBTPreparation.BuildingBlocks.Domain.Exceptions;

namespace CBTPreparation.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public bool IsOAuthProvider { get; private set; }
    public Role Role { get; private set; }
    private User() : base(null!) { }
    private User(UserId id) : base(id) { }
    //private User(UserId id,
    //             string firstName,
    //             string lastName,
    //             string email,
    //             bool isOAuthProvider,
    //             Role role,
    //    string? passwordHash) : base(id)
    //{
    //    InvalidEmailAddressException.Throw(email);
    //    ArgumentException.ThrowIfNullOrWhiteSpace(email);
    //    ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
    //    ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

    //    FirstName = firstName;
    //    LastName = lastName;
    //    Email = email;
    //    PasswordHash = passwordHash;
    //    Role = role;
    //    IsOAuthProvider = isOAuthProvider;
    //}

    public static User Create(string firstName, string lastName, string email, bool isOAuthProvider, string role, string? passwordHash = null)
    {
        InvalidEmailAddressException.Throw(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        var user = new User(UserId.CreateUniqueId())
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IsOAuthProvider = isOAuthProvider,
            Role = Role.Assign(role),
            PasswordHash = passwordHash
        };

        return user;
    }
}
