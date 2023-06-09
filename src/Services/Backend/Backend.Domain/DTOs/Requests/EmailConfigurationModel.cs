﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.DTOs.Requests;

public class EmailConfigurationModel
{
    public string EmailFrom { get; set; }
    public string EmailServer { get; set; }
    public string EmailUser { get; set; }
    public string EmailPass { get; set; }
    public int EmailPort { get; set; }
    public bool EmailEnabledSsl { get; set; }

    public EmailConfigurationModel()
    {
        EmailFrom = "conejo64@gmail.com";
        EmailServer = "smtp.gmail.com";
        EmailUser = "conejo64@gmail.com";
        EmailPass = "dhjrpzomgzksqbjm";
        EmailPort = 587;
        EmailEnabledSsl = true;
    }
}
