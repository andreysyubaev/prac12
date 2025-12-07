using Microsoft.EntityFrameworkCore;
using prac12.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac12.Data
{
    public class InterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<InterestGroup> InterestGroups { get; set; } = new();
        public static ObservableCollection<UserInterestGroup> UserInterestGroups { get; set; } = new();

        public int Commit() => _db.SaveChanges();

        public void Add(InterestGroup interestGroup)
        {
            var _interestGroup = new InterestGroup
            {
                Id = interestGroup.Id,
                Title = interestGroup.Title,
                Description = interestGroup.Description,
            };
            _db.Add<InterestGroup>(_interestGroup);
            Commit();
            InterestGroups.Add(_interestGroup);
        }

        public void GetAll()
        {
            var interestGroups = _db.InterestGroups
                .Include(c => c.UserInterestGroups)
                .ThenInclude(cs => cs.User)
                .ToList();

            InterestGroups.Clear();
            foreach (var interestGroup in interestGroups)
                InterestGroups.Add(interestGroup);
        }

        public InterestGroupService()
        {
            GetAll();
        }

        public void Remove(InterestGroup interestGroup)
        {
            _db.Remove<InterestGroup>(interestGroup);
            if (Commit() > 0)
                if (InterestGroups.Contains(interestGroup))
                    InterestGroups.Remove(interestGroup);
        }

        public void AddUserToGroup(User user, UserInterestGroup userGroup, InterestGroup group)
        {
            bool Exists = _db.UserInterestGroups.Any(ug =>
                            ug.UserId == user.Id &&
                            ug.InterestGroupId == group.Id);

            if (Exists)
            {
                return;
            }

            var _groupUser = new UserInterestGroup
            {
                UserId = user.Id,
                InterestGroupId = group.Id,
                JoinedAt = userGroup.JoinedAt,
                IsModerator = userGroup.IsModerator,
            };
            _db.UserInterestGroups.Add(_groupUser);
            Commit();

        }

    }
}
