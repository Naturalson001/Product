using System;
namespace Product.product
{
	public interface UserService
	{

        IEnumerable <User> getAllUser();
        void createUser(User user);
        User getUserById(int UserId);
        User getUserByEmail(string Email);
        void delectUser(int UserId);
        void UpdateUser(int UserId, User user, string email);

    }
}

