﻿using System.Collections.Generic;
using System.Linq;
using Forum.App.UserInterface.ViewModels;
using Forum.Data;
using Forum.Models;

namespace Forum.App.Services
{
    public static class PostService
    {
        public static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            Category category = forumData.Categories.Find(c => c.Id == categoryId);

            return category;
        }

        public static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            IList<ReplyViewModel> replies = new List<ReplyViewModel>();


            foreach (var replyId in post.ReplyIds)
            {
                var reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();

            var allCategories = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategories;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();

            var postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;

            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);
            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();

            Category category = EnsureCategory(postView, forumData);

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = UserService.GetUser(postView.Author);

            int authorId = author.Id;
            string content = string.Join("", postView.Content);

            Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);
            forumData.SaveChanges();

            postView.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(int postId, ReplyViewModel replyView)
        {
            ForumData forumData = new ForumData();
            bool emptyContent = !replyView.Content.Any();

            if (emptyContent)
            {
                return false;
            }
            int replyId = forumData.Replies.Any() ? forumData.Replies.Last().Id + 1 : 1;
            
            string content = string.Join("", replyView.Content);

            var authorId = UserService.GetUser(replyView.Author).Id;
            

            Reply reply = new Reply(replyId, content, authorId, postId);
            Post post = forumData.Posts.FirstOrDefault(p => p.Id == postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();
            

            return true;
        }
    }
}