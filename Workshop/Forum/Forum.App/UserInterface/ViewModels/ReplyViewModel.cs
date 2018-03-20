﻿using System.Linq;
using Forum.App.Services;
using Forum.Data;
using Forum.Models;

namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel()
        {
            
        }
        public ReplyViewModel(Reply reply)
        {
            this.ReplyId = reply.Id;
            this.Author = UserService.GetUser(reply.AuthorId).Username;
            this.Content = GetLines(reply.Content);
        }

        public int ReplyId { get; set; }
        public string Author { get; set; }

        public IList<string> Content { get; set; }

        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            IList<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                char[] row = contentChars.Skip(i).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}