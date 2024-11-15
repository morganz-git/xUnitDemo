using AutoFixture;
using AutoFixture.Xunit2;

namespace xUnitDemo.XUnitExtention;

public class RegisterUserAttribute : AutoDataAttribute
{
    public RegisterUserAttribute() : base(() =>
        {
            var fixture = new Fixture();
            /*
            fixture.Customize<RegisterUserModel>(x =>  // x 是 ICustomizationComposer<RegisterUserModel>
        x.With(x => x.Email, "m@m.m")        // 使用 x 来定制 Email 属性
         );
            */
            fixture.Customize<RegisterUserModel>(x => x
                .With(x => x.Email, "m@m.m")
                .With(x => x.Password, "password"));
            return fixture;
        }
    )
    {
    }
}