using Yoda.Services.Data;

using Yoda.Services.Entities;
using Yoda.Services.Models;

namespace Yoda.Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly YodaContext _yodaContext;

        public UserService(YodaContext yodaContext)
        {
            _yodaContext = yodaContext;
        }

        public UserModel GetById(Guid userId)
        {
            var user = _yodaContext.Users.FirstOrDefault(x => x.Id == userId.ToString());
            if (user == null)
                return null;
            return new UserModel()
            {
                Id = Guid.Parse(user.Id),
                Username = user.Username,
                Password = user.Password,
                DisplayName = user.DisplayName,
                Avatar = user.Avatar
            };
        }

        public Guid Create(RegisterModel register)
        {
            var user = new UserEntity();
            user.Id = Guid.NewGuid().ToString();
            user.Username = register.Username;
            user.Password = register.Password;
            user.DisplayName = register.DisplayName;
            user.Avatar = register.Avatar;
            _yodaContext.Users.Add(user);
            _yodaContext.SaveChanges();
            return Guid.Parse(user.Id);
        }

        public void Update(Guid userId, RegisterModel register)
        {
            var user = _yodaContext.Users.FirstOrDefault(s => s.Id == userId.ToString());
            if (user != null)
            {
                user.Username = register.Username;
                user.Password = register.Password;
                user.DisplayName = register.DisplayName;
                user.Avatar = register.Avatar;
                _yodaContext.Users.Update(user);
                _yodaContext.SaveChanges();
            }
        }
    }
}
