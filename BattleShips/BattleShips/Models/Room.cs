﻿using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace BattleShips.Models
{
    public class Room
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime DateCreated { get; set; }
        public int MaxPlayerCount { get; set; } = 2;
        public int CurrentPlayerCount => UserFields.Count;

        //Mapas;Naudotojas;Ar pasiruoses
        public List<Tuple<Field, User,bool>> UserFields = new List<Tuple<Field, User,bool>>();

        public bool IsGameStarted = false;
        public bool IsFull => UserFields.Count >= MaxPlayerCount;

        public string CurrentUserTurnID { get; set; }

        public string RoomType { get; set; }

        public Room(string roomName, string roomType)
        {
            RoomId = Guid.NewGuid().ToString();
            RoomName = roomName;
            IsGameStarted = false;
            DateCreated = DateTime.Now;
            RoomType = roomType;
        }

        public void SetPlayerReady(string userId)
        {
            var user = UserFields.Where(n => n.Item2.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                UserFields.Remove(user);
                UserFields.Add(new Tuple<Field, User, bool>(user.Item1, user.Item2, true));
            }

            if (UserFields.Where(n=>(bool)n.Item3).Count() == MaxPlayerCount)
            {
                IsGameStarted = true; // All players are ready
            }
        }

        public void ChangeTurn()
        {
            var currentIndex = UserFields.FindIndex(u => u.Item2.UserId == CurrentUserTurnID);
            var nextIndex = (currentIndex + 1) % MaxPlayerCount; // Alternate turns
            CurrentUserTurnID = UserFields[nextIndex].Item2.UserId;
        }
    }


}
