using System;
using System.Text.RegularExpressions;
using Backend.Template.Core.Exceptions;
using Backend.Template.Core.Helpers;
using NUnit.Framework;

namespace Backend.Template.Core.Tests.Helpers
{
    public class IdentityHelperTests
    {

        [Test]
        public void GetUniqueId_nrOfHex_lesser_than_one_expects_formatException_thrown()
        {
            const uint numberOfHex = 0;
            var sut = new IdentityHelper();
            Assert.Throws<FormatException>(() => sut.GetUniqueId(1, numberOfHex));
        }
        
        [TestCase((uint) 1)]
        [TestCase((uint) 3)]
        [TestCase((uint) 6)]
        public void GetUniqueId_valid_nrOfHex_expects_uniqueId_in_the_form_of_the_given_regex_format(uint nrOfHex)
        {
            var sut = new IdentityHelper();
            var uniqueId = sut.GetUniqueId(1, nrOfHex);
            var regexQuery = @"[0-9a-fA-F]{5}-[0-9a-fA-F]{" + nrOfHex + "}";
            Assert.True(Regex.IsMatch(uniqueId, regexQuery));
        }
        
        [Test]
        public void GetUniqueId_nrOfHex_exceeds_int32_expects_exception_thrown()
        {
            const uint numberOfHex = 8;
            var sut = new IdentityHelper();
            Assert.Throws<DefaultException>(() => sut.GetUniqueId(1, numberOfHex));
        }
    }
}