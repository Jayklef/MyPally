using MyPally.DataAccess.Dtos;
using MyPally.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPally.DataAccess.Repositories.Interface
{
    public interface IFriendRepository
    {
        List<FriendDto> GetAllFriends();
        FriendDto GetFriendById(int Id);
        void CreateFriend(FriendDto friendDto);
        void UpdateFriend(FriendDto friendDto);
        void DeleteFriend(int Id);
    }
}
