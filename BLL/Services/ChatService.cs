using BLL.DTOs;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ChatService
    {
        public static List<ChatDTO> Get()
        {
            return Convert(DataAccessFactory.ChatData().Get());
        }
        public static ChatDTO Get(int id)
        {
            return Convert(DataAccessFactory.ChatData().Get(id));
        }
        public static bool Create(ChatDTO chat)
        {
            return DataAccessFactory.ChatData().Insert(Convert(chat));
        }

        public static bool Update(ChatDTO chat)
        {
            return DataAccessFactory.ChatData().Update(Convert(chat));
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ChatData().Delete(id);
        }
        static List<ChatDTO> Convert(List<Chat> chat)
        {
            var data = new List<ChatDTO>();
            foreach (Chat c in chat)
            {
                data.Add(Convert(c));
            }
            return data;
        }
        static ChatDTO Convert(Chat chat)
        {
            return new ChatDTO()
            {
                Id = chat.Id,
                Text=chat.Text,
                TextedOn=chat.TextedOn,
                UserFrom=chat.UserFrom,
                UserTo=chat.UserTo,

            };
        }
        static Chat Convert(ChatDTO chat)
        {
            return new Chat()
            {
                Id = chat.Id,
                Text = chat.Text,
                TextedOn = chat.TextedOn,
                UserFrom = chat.UserFrom,
                UserTo = chat.UserTo,

            };
        }
    }
}
