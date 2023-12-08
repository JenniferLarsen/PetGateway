using Microsoft.AspNetCore.Identity;

namespace PetGateway.Models
{
    public class ConfigureIdentity
    {


        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";


            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            //if username doesn't exist, create it and add to role

            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
    }
}
