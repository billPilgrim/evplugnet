﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EvPlugNet1.Models;

public partial class ChargeTag
{
    public string TagId { get; set; }

    public string TagName { get; set; }

    public string ParentTagId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? Blocked { get; set; }
}