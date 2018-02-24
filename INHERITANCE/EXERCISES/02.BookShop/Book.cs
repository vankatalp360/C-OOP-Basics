using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string title;

    private string author;

    private decimal price;


    public Book(string author, string title, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }
    public virtual decimal Price
    {
        get { return price; }
        set { price = Validator.ValidatePrice(value); }
    }

    public string Author
    {
        get { return author; }
        set { author = Validator.ValidateAuthor(value); }
    }

    public string Title
    {
        get { return title; }
        set { title = Validator.ValidateTitle(value); }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Type: {GetType().Name}");
        builder.AppendLine($"Title: {this.Title}");
        builder.AppendLine($"Author: {this.Author}");
        builder.AppendLine($"Price: {this.Price:f2}");

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
