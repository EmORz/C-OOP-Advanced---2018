namespace CustomClassAttributee
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class ClassAttribute : Attribute
    {

        public ClassAttribute(string author, string description, int revision, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; private set; }

        public int Revision { get; private set; }

        public string Description { get; private set; }

        public string[] Reviewers { get; private set; }
    }

}



