using System;
using Backend.Template.Domain.Location;

namespace Backend.Template.Core.Extensions
{
    public static class GeoLocationExtension
    {
        private const double _radians = Math.PI / 180;

        public static int GetDistanceInMeters(this Geolocation src, Geolocation dst)
        {
            return (int) (src.GetDistance(dst) * 1000);
        }
        
        public static double GetDistance(this Geolocation src, Geolocation dst)
        {
            const int r = 6371;
            var dLat = GetRadians(dst.Latitude - src.Latitude);
            var dLon = GetRadians(dst.Longitude - src.Longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + 
                       Math.Cos(GetRadians(src.Latitude)) * Math.Cos(GetRadians(dst.Latitude)) * 
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            
            return 2 * r * Math.Asin(Math.Min(1, Math.Sqrt(a)));
        }

        private static double GetRadians(double val)
        {
            return _radians * val;
        }
    }
}