﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EvPlugNet1.Models;

public partial class Node2node
{
    public int Id { get; set; }

    public int? ParentNode { get; set; }

    public int? ChildNode { get; set; }

    public DateTime DateCreate { get; set; }
}