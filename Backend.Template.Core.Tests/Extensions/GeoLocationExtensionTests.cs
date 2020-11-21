using System;
using Backend.Template.Core.Extensions;
using Backend.Template.Domain.Location;
using NUnit.Framework;

namespace Backend.Template.Core.Tests.Extensions
{
    public class GeoLocationExtensionTests
    {
        private Geolocation _src;
        private Geolocation _dst;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _src = new Geolocation()
            {
                Latitude = 59.911491,
                Longitude = 10.757933
            };

            _dst = new Geolocation()
            {
                Latitude = 59.924718,
                Longitude = 10.6719404
            };
        }
        
        [Test]
        public void GetDistance_distance_between_same_location_expects_zero_distance()
        {
            var distanceInKm = _src.GetDistance(_src);
            Assert.AreEqual(0, distanceInKm);
        }
        
        [Test]
        public void GetDistance_distance_between_two_location_expects_in_unit_km()
        {
            var distanceInKm = _src.GetDistance(_dst);
            Assert.AreEqual(5.01, Math.Round(distanceInKm, 2));
        }
        
        [Test]
        public void GetDistanceInMeters_distance_between_two_location_expects_in_meters()
        {
            var distanceInMeters = _src.GetDistanceInMeters(_dst);
            Assert.AreEqual(5013, distanceInMeters);
        }
    }
}