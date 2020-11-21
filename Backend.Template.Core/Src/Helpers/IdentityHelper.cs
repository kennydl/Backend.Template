using System;
using Backend.Template.Core.Attributes;
using Backend.Template.Core.Exceptions;

namespace Backend.Template.Core.Helpers
{
    [ScopedService]
    public class IdentityHelper
    {
        private static readonly DateTime _dateOffset = new DateTime(2020, 1, 1);
        private readonly long _hourOffset;
        
        public readonly DateTime HourlyTimestamp;

        public IdentityHelper()
        {
            var timeOffset = DateTime.UtcNow - _dateOffset;
            _hourOffset = (long) timeOffset.TotalHours;
            HourlyTimestamp = _dateOffset.AddHours(_hourOffset);
        }

        public string GetUniqueId(int count, uint numberOfHex = 5)
        {
            var maxHex = "0x" + new string('F', (int)numberOfHex);
            if (count > Convert.ToInt32(maxHex, 16))
            {
                throw new DefaultException(
                    "Too many entries on this hourly timestamp."
                );
            }

            var uniqueId = _hourOffset.ToString("X5") + "-" + count.ToString($"X{numberOfHex}");
            return uniqueId.ToLower();
        }
    }
}
