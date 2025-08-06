using System;
using System.Collections.Generic;

namespace EFcoreConsoleApp.Models;

public partial class MenuList
{
    public int MenuId { get; set; }

    public string? DishName { get; set; }

    public decimal Price { get; set; }

    public string? Category { get; set; }
}
