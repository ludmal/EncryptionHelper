using System;
using System.ComponentModel.DataAnnotations;

namespace EncryptionHelper
{
    /// <summary>
    /// Property will be encrypted automatically when saving to Db
    /// </summary>
    public class Encrypted : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                validationContext
                    .ObjectType
                    .GetProperty(validationContext.MemberName)
                    .SetValue(validationContext.ObjectInstance, CryptoHelper.Encrypt(value.ToString()), null);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}