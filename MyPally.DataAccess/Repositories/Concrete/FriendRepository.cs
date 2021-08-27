using MyPally.DataAccess.Dtos;
using MyPally.DataAccess.Repositories.Interface;
using MyPally.Domain.Context;
using MyPally.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPally.DataAccess.Repositories.Concrete
{
    public class FriendRepository : IFriendRepository
    {
        private readonly MyPallyContext _context;
        public FriendRepository(MyPallyContext context)
        {
            _context = context;
        }
        public List<FriendDto> GetAllFriends()
        {
            var friends = _context.Friends.Select(f => new FriendDto
            {
                Id = f.Id,
                FullName = f.FullName,
                DateOfBirth = f.DateOfBirth,
                Gender = f.Gender,
                Profession = f.Profession,
                CurrentLocation = f.CurrentLocation,
                Tribe = f.Tribe,
                Relationship = f.Relationship
            }).ToList();

            return friends;
        }

        public FriendDto GetFriendById(int Id)
        {
            var friend = _context.Friends.Where(fr => fr.Id == Id).Select(f => new FriendDto
            {
                Id = f.Id,
                FullName = f.FullName,
                DateOfBirth = f.DateOfBirth,
                Gender = f.Gender,
                Profession = f.Profession,
                CurrentLocation = f.CurrentLocation,
                Tribe = f.Tribe,
                Relationship = f.Relationship
            }).FirstOrDefault();

            return friend;
        }

        public void CreateFriend(FriendDto friendDto)
        {
            var friend = new Friend
            {
                FullName = friendDto.FullName,
                DateOfBirth = friendDto.DateOfBirth,
                Gender = friendDto.Gender,
                Profession = friendDto.Profession,
                CurrentLocation = friendDto.CurrentLocation,
                Tribe = friendDto.Tribe,
                Relationship = friendDto.Relationship
            };

            _context.Friends.Add(friend);
            _context.SaveChanges();
        }

        public void UpdateFriend(FriendDto friendDto)
        {
            var friend = _context.Friends.Where(f => f.Id == friendDto.Id).FirstOrDefault();

            friend.FullName = friendDto.FullName;
            friend.DateOfBirth = friendDto.DateOfBirth;
            friend.Gender = friendDto.Gender;
            friend.Profession = friendDto.Profession;
            friend.CurrentLocation = friendDto.CurrentLocation;
            friend.Tribe = friendDto.Tribe;
            friend.Relationship = friendDto.Relationship;

            _context.SaveChanges();
        }

        public void DeleteFriend(int Id)
        {
            var friend = _context.Friends.Where(f => f.Id == Id).FirstOrDefault();

            _context.Friends.Remove(friend);
            _context.SaveChanges();
        }
    }
}