using System.Security.AccessControl;

namespace xUnitDemo;

public class RegisterUserModel
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string CPassword { get; set; }
    public string  Email { get; set; }
}