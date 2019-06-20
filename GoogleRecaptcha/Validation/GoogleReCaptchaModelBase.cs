using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoogleRecaptcha.Validation
{
    public abstract class GoogleReCaptchaModelBase
    {
        [Required]
        [GoogleRecaptchaValidation]
        public string GoogleRecaptchaResponse { get; set; }
    }
}