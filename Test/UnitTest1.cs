using System.ComponentModel.DataAnnotations;
using ContactManagement.Models;
using Xunit;
using System.Collections.Generic;

namespace ContactManagement.Tests
{
    public class ContactValidationTests
    {
        private IList<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, results, true);
            return results;
        }

        [Fact]
        public void Should_Fail_When_Name_Too_Short()
        {
            var c = new Contact { Name = "abc", ContactNumber = "912345678", Email = "a@b.com" };
            var results = ValidateModel(c);
            Assert.Contains(results, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Should_Fail_When_ContactNumber_Invalid()
        {
            var c = new Contact { Name = "Nome Valido", ContactNumber = "123", Email = "a@b.com" };
            var results = ValidateModel(c);
            Assert.Contains(results, r => r.MemberNames.Contains("ContactNumber"));
        }

        [Fact]
        public void Should_Fail_When_Email_Invalid()
        {
            var c = new Contact { Name = "Nome Valido", ContactNumber = "912345678", Email = "not-an-email" };
            var results = ValidateModel(c);
            Assert.Contains(results, r => r.MemberNames.Contains("Email"));
        }
    }
}