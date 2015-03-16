namespace SchoolClasses.Contracts
{
    using System.Collections.Generic;

    using SchoolClasses.Models;

    public interface IHaveComments
    {
        ICollection<Comment> Comments { get; }

        void AddComment(Comment comment);

        void RemoveComment(Comment comment);
    }
}
