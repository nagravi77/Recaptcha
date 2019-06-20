using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;

namespace GoogleRecaptcha.Validation
{
    public class GoogleRecaptchaValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);

            Lazy<ValidationResult> validationResult = new Lazy<ValidationResult>(() => new ValidationResult("Google reCAPTCHA validation failed", new String[] { validationContext.MemberName })); 

             if (value == null || String.IsNullOrWhiteSpace( value.ToString())) 
            {
                return validationResult.Value;
            }

             string recaptchaResponse = value.ToString();
             string recaptchaSecreat = WebConfigurationManager.AppSettings["SecretKey"].ToString();

            HttpClient httpClient = new HttpClient();
            var httpResponse = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={recaptchaSecreat}&response={recaptchaResponse}").Result;

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                return validationResult.Value;
            }

            String jsonResponse = httpResponse.Content.ReadAsStringAsync().Result;
            dynamic jsonData = JObject.Parse(jsonResponse);
            if (jsonData.success != true.ToString().ToLower())
            {
                return validationResult.Value;
            }

            return ValidationResult.Success;
        }
    }
}