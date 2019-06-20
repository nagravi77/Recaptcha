using GoogleRecaptcha.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoogleRecaptcha.Models
{
    public class Comment : GoogleReCaptchaModelBase
    {
        [Required]
        public String Title { get; set; }

        [Required]
        public String Content { get; set; }
    }
}