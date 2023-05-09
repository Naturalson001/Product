using System;
using Microsoft.AspNetCore.Http.HttpResults;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.data1;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Product.product
{
    public class UserServices : UserService
    {
        private  UserDbContext _dbContext;

        public UserServices(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        IEnumerable<User> UserService.getAllUser()
        {
            
           
            var data = _dbContext.users.ToList();

            return data;
        }

        void UserService.createUser(User user)
        {
           
            _dbContext.users.Add(user);
           
            //_dbContext.SaveChanges();
        }


        


        public User getUserByEmail(string Email)
        {
            return _dbContext.users.FirstOrDefault(r => r.Email == Email);
        }

        public User getUserById(int UserId)
        {
            return _dbContext.users.FirstOrDefault(r => r.UserId == UserId);
        }

      

       public  void delectUser(int UserId)
        {
            var user = _dbContext.users.FirstOrDefault(r => r.UserId == UserId);
            if (user != null)
            {
                _dbContext.users.Remove(user);
                _dbContext.SaveChanges();
            }

        }


        public void UpdateUser(int UserId, User user, string Email)
        {
            var oldusers = _dbContext.users.FirstOrDefault(r => r.UserId == UserId)
                ?? _dbContext.users.FirstOrDefault(r => r.Email == Email);
            if (oldusers != null)
            {
                oldusers.UserId = user.UserId;
                oldusers.Firstname = user.Firstname;
                oldusers.Lastname = user.Lastname;
                oldusers.Email = user.Email;
                oldusers.Phonenumber = user.Phonenumber;
                oldusers.Address = user.Address;
                oldusers.Gender = user.Gender;

                _dbContext.SaveChanges();

            }
        }


        
    }

}