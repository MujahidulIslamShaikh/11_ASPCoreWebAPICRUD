﻿using System;
using System.Collections.Generic;

namespace ASPCoreWebAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public int Standard { get; set; }
}
