using System;
using System.Collections.Generic;
using System.Text;

public class ClassAttribute:Attribute
{
    public string Author { get; set; }
    public int Revision { get; set; }
    public string Description { get; set; }
    public ICollection<string> Reviewers { get; set; }

    public ClassAttribute(string author, int revision, string description, params string[] reviewer)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = reviewer;
    }
}