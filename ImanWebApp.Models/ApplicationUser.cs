using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImanWebApp.Models;

public class ApplicationUser : IdentityUser
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
}
