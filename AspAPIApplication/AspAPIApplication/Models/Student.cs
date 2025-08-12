using System;
using System.Collections.Generic;
namespace AspAPIApplication.Models;

public partial class Student
{
    public int StudId { get; set; }

    public string StudName { get; set; } = null!;

    public string Dept { get; set; } = null!;

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }
}
