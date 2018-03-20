﻿using System.Linq;
using Forum.App.Services;
using Forum.App.UserInterface.Input;
using Forum.App.UserInterface.ViewModels;
using Forum.App.Views;

namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;
        private PostViewModel post;
        public int PostId { get; private set; }
        public ReplyViewModel Reply { get; private set; }
        private TextArea TextArea { get; set; }
        public bool Error { get; private set; }

        public AddReplyController()
        {
            this.ResetReply();
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;
                case Command.Reply:
                    bool validReply = PostService.TrySaveReply(this.post.PostId, this.Reply);
                    if (!validReply)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    return MenuState.Back;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.post, this.Reply, this.TextArea, this.Error);
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            this.TextArea = new TextArea(centerLeft - 18, centerTop - 7,
                TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }
        public void SetReplyToPost(int postId, string username)
        {
            PostId = postId;
            post = PostService.GetPostViewModel(postId);

            ResetReply();
            Reply.Author = username;
        }
        private enum Command
        {
            Write, Reply, Back
        }
    }
}
