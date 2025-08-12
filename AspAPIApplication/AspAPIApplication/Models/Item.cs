using System;
using System.Collections.Generic;

namespace AspAPIApplication.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
